using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class AGException : System.Exception
    {
        public AGException()
        {

        }
    }

    public class CustomException : System.Exception
    {
        public CustomException(String message) : base(message)
        {

        }

        //public virtual void HandleException(ExceptionContext context)
        //{
        //    throw context.Exception;
        //}
    }
}
