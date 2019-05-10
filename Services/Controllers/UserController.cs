using Business.Contracts;
using Core.Validators;
using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace Services.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserLogic userLogic;
        private readonly ITaskLogic taskLogic;

        public UserController(IUserLogic userLogic, ITaskLogic taskLogic)
        {
            this.userLogic = userLogic;
            this.taskLogic = taskLogic;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/users/login")]
        public IHttpActionResult Login(UserModel userModel)
        {
            return GetHttpResponse(() =>
            {
                try
                {
                    var user = this.userLogic.Login(userModel.Email, userModel.Password);

                    UserModel model = new UserModel();

                    if (user != null)
                    {

                        FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<String, String>("grant_type", "password"),
                            new KeyValuePair<String, String>("username", user.Email),
                            new KeyValuePair<String, String>("userid", user.UserID.ToString()),

                        });

                        string baseURL = HttpContext.Current.Request.Url.Authority;

                        HttpClient client = new HttpClient();
                        HttpRequestMessage tokenRequest = new HttpRequestMessage()
                        {
                            RequestUri = new Uri("http://" + baseURL + "/token"),
                            Method = HttpMethod.Post
                        };
                        tokenRequest.Content = content;

                        tokenRequest.Headers.Add("Accept", "application/json");

                        HttpResponseMessage responseToken = client.SendAsync(tokenRequest).Result;

                        if (responseToken.IsSuccessStatusCode)
                        {
                            var token = responseToken.Content.ReadAsAsync<TokenModel>().Result;
                            model.TokenAccess = token.AccessToken;
                            model.Email = user.Email;
                            model.Name = user.Name;

                        }
                        else
                        {
                            ResponseResult.Success = false;
                            ResponseResult.Errors.Add(new ValidatorResult() { Code = 0, Message = "Usuario y/o Contraseña incorrectos." });
                        }
                    }
                    else
                    {
                        ResponseResult.Success = false;
                        ResponseResult.Errors.Add(new ValidatorResult() { Code = 0, Message = "Usuario y/o Contraseña incorrectos." });
                    }

                    ResponseResult.Data = model;

                }
                catch (ValidationException e)
                {
                    ResponseResult.Success = false;
                    ResponseResult.Errors = e.ValidationResultsLog;
                }


                return Ok(ResponseResult);

            });


        }

        [Route("api/user/tasks")]
        public IHttpActionResult GetTasks()
        {
            return GetHttpResponse(() =>
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var userId = Convert.ToInt32(identity.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value);

                var tasks = this.taskLogic.GetByUser(userId);

                return Ok(tasks);
            });
        }

        [Route("api/user/task/update")]
        [HttpPost]
        public IHttpActionResult UpdateTask(UserTask userTask)
        {
            return GetHttpResponse(() =>
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var userId = Convert.ToInt32(identity.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value);
                userTask.UserID = userId;
                if (userTask.TaskID == 0)
                    this.taskLogic.Add(userTask);
                else
                {
                    userTask.LastUpdate = DateTime.Now;
                    this.taskLogic.Update(userTask);
                }
                    

                return Ok();
            });
        }

        [Route("api/user/task/remove/{id}")]
        [HttpDelete]
        public IHttpActionResult RemoveTask(int id)
        {
            return GetHttpResponse(() =>
            {
                this.taskLogic.RemoveById(id);

                return Ok();
            });
        }
    }
}