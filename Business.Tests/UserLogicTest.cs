using System;
using Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Business.Tests
{
    [TestClass]
    public class UserLogicTest
    {

        private ITaskRepository taskRepository;
        private TaskLogic Target { get; set; }

        [TestInitialize]
        public void OnInit()
        {
            this.taskRepository = Mock.Of<ITaskRepository>();

            this.Target = new TaskLogic(this.taskRepository);
        }

        [TestMethod]
        public void GetAllTasksByUser_ExecuteOnce()
        {
            //Arrange

            //Act
            this.Target.GetByUser(It.IsAny<int>());

            //Assert
            Mock.Get(this.taskRepository).Verify(x => x.GetByUser(It.IsAny<int>()), Times.Once());
        }


    }
}
