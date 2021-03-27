using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Result
{
    public class ErrorResult:Result,IResult
    {
        public ErrorResult():base(false)
        {

        }
        public ErrorResult(string message):base(false,message)
        {

        }
    }
}
