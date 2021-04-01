using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Message
    {
        //CAR
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";

        //BRAND
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";

        //COLOR
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        //USER
        public static string UserRegistered = "Üye olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        //CUSTOMER

        //RENT

        //CAR IMAGE
        public static string ImageAdded = "Resim eklendi";
        public static string ImageDeleted = "Resim silindi";
        public static string ImageUpdated = "Resim güncellendi";

        public static string ImageAddedError = "Resim eklenemedi";
        public static string ImageDeletedError = "Resim silinemedi";
        public static string ImageUpdatedError = "Resim güncellenemedi";

        //AUTHORİZATİON
        public static string AuthorizationDenied = "Yetki reddedildi";
    }
}
