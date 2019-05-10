using Core.Validators;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;

namespace Services
{
    [Authorize]
    public class ApiControllerBase : ApiController
    {
        protected readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Response ResponseResult { get; set; }

        protected IHttpActionResult GetHttpResponse(Func<IHttpActionResult> codeToExecute)
        {
            IHttpActionResult response = null;
            ResponseResult = new Response()
            {
                Success = true,
                Errors = new List<ValidatorResult>()
            };

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (SecurityException ex)
            {
                logger.Error(ex.Message, ex);
                response = StatusCode(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                response = InternalServerError(ex);
            }

            return response;
        }
    }
}