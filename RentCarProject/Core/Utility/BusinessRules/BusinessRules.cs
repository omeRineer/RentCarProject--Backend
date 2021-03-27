using Core.Utility.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.BusinessRules
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
