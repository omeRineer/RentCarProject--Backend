using Core.Utility.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file, string fileType);
        IResult Delete(string file);
        IDataResult<string> FileControl(IFormFile file, string[] fileExtention);
        IDataResult<string[]> FileExtensionRotates(string FileType);
    }
}
