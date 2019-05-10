using Data.Base;
using Data.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class TaskRepository: BaseRepository<UserTask>, ITaskRepository
    {

        public List<UserTask> GetByUser(int userId)
        {
            using (AssesmentContext Context = new AssesmentContext())
            {
                return Context.UserTasks.Where(t => t.UserID == userId).ToList();
            };
        }
    }
}
