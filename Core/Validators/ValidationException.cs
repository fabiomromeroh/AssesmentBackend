using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class ValidationException : CustomException
    {
        private const String DEFAULT_MESSAGE = "Validacion del negocio.";

        public List<ValidatorResult> ValidationResultsLog { get; set; }

        public ValidationException() : base(DEFAULT_MESSAGE) { }

        public ValidationException(List<ValidatorResult> validationResultsLog) : base(DEFAULT_MESSAGE)
        {
            this.ValidationResultsLog = validationResultsLog;
        }

        //public override void HandleException(ExceptionContext context)
        //{
        //    context.ExceptionHandled = true;
        //}
    }

}
