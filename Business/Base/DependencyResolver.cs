using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Core.DI;
using System.ComponentModel.Composition;
using Business.Contracts;
using Business.Implementations;
using Data.Contracts;
using Data.Implementations;
using Data.Base;
using Data;

namespace Business.Base
{
    [Export(typeof(Core.DI.IComponent))]
    public class DependencyResolver : Core.DI.IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserLogic, UserLogic>();
            registerComponent.RegisterType<IUserRepository, UserRepository>();

            registerComponent.RegisterType<ITaskLogic, TaskLogic>();
            registerComponent.RegisterType<ITaskRepository, TaskRepository>();
        }
    }
}
