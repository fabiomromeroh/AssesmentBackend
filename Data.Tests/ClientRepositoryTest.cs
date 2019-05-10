using Data.Base;
using Data.Contracts;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Data.Tests
{
    [TestClass]
    public class ClientRepositoryTest
    {
        private ITaskRepository Target { get; set; }
        private AssesmentContext context { get; set; }
        private List<UserTask> tasks { get; set; }

        [TestInitialize]
        public void OnInit()
        {
            this.tasks = new List<UserTask>()
            {
                Mock.Of<UserTask>(c => c.Name == "Task 1" &&
                c.UserID == 1 && 
                c.Checked == false &&
                c.TaskID == 1 &&
                c.Description == "Description of the task")
            };
            this.Target = Mock.Of<ITaskRepository>();
        }

        [TestMethod]
        public void GetTasksByUser_ReturnNull()
        {
            ////Arrange
            //var context = new Mock<AssesmentContext>();
            //context.Setup(x => x.UserTasks).Returns();

            ////Act
            //Mock.Get(this.Target).Setup(x => x.GetByUser(1)).Returns(this.tasks);
            //var client = this.Target.GetByUser(21312312);

            ////Assert
            //Assert.AreEqual(null, client);
        }

        //[TestMethod]
        //public void GetClientByID_ReturnClient()
        //{
        //    //Arrange

        //    //Act
        //    var client = this.Target.GetById("1");

        //    //Assert
        //    Assert.AreEqual("1", client.id);
        //}
    }
}
