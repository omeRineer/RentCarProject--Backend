using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utility.Helpers.HashingHelper;
using Core.Utility.Result;
using Core.Utility.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash, out passwordSalt);
            var user = new User
            {
                UserEmail = userForRegisterDto.Email,
                UserFirstName = userForRegisterDto.FirstName,
                UserLastName = userForRegisterDto.LastName,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt,
                UserStatus = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Message.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.UserPasswordHash, userToCheck.UserPasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Message.SuccessfulLogin);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Message.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Message.AccessTokenCreated);
        }
    }
}
