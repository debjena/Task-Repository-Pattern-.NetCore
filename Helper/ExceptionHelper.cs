using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Repo_Pattern
{
    public static class ExceptionHelper
    {
        public static object ErrorDetails(Exception ex)
        {
            return new
            {
                error = new
                {
                    code = ex.HResult,
                    message = ex.Message
                }
            };
        }
    }
}
