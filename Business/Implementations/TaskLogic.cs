using Business.Contracts;
using Data;
using Data.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TaskLogic: BaseLogic<UserTask, TaskRepository>, ITaskLogic
    {
        private readonly ITaskRepository taskRepository;

        public TaskLogic(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public List<UserTask> GetByUser(int userId)
        {
            return this.taskRepository.GetByUser(userId);
        }
    }
}
