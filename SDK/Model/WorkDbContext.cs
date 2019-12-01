using MySql.Data.Entity;
using SDK.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST.Model
{
    public class DbInitialier : CreateDatabaseIfNotExists<WorkDbContext>
    {
        protected override void Seed(WorkDbContext context)
        {
            base.Seed(context);
        }
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WorkDbContext : DbContext
    {
        public WorkDbContext() : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DbInitialier());
        }


        public IEnumerable<Employee> GetEmployees()
        {
            return Employees.Include(x => x.Enterprise).ToList();
        }


        public IEnumerable<Enterprise> GetEnterprises()
        {
            return Enterprises.ToList();
        }
        public IEnumerable<User> GetUsers()
        {
            return Users.ToList();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
