using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
