using Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data.Base
{
    public class AssesmentContext : DbContext, IContext
    {

        public AssesmentContext(): base("AssesmentDBContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 120;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

    }
}
