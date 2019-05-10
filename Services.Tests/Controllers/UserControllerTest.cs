using System;
using Business.Contracts;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Controllers;

namespace Services.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        //private ITaskLogic taskLogic { get; set; }
        //private IUserLogic userLogic { get; set; }
        public UserController Target { get; set; }

        [TestInitialize]
        public void OnInit()
        {
           var taskLogic = Mock.Of<ITaskLogic>();
           var userLogic = Mock.Of<IUserLogic>();

           this.Target = new UserController(userLogic, taskLogic);
        }

        [TestMethod]
        public void GetTasksByUser()
        {
            //Arrange

            //Act
            var tasks = this.Target.GetTasks();

            ////Assert
            //Mock.Get(this.taskLogic).Verify(x => x.GetByUser(It.IsAny<int>()), Times.Once());
        }
    }
}
