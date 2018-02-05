using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveIt
{
    public class EntitySaveItContext : DbContext
    {
        public EntitySaveItContext()
            : base("name=EntitySaveItContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Payee> Payees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            //this.Configuration.ProxyCreationEnabled = false;
        }


    }
}
