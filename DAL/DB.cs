using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE;

namespace DAL
{
    public class DB : DbContext
    {
        public DB() : base("constr")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CustomerApply> CustomerApplies { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccessRole> userAccessRoles { get; set; }
        public DbSet<UserGroup> userGroups { get; set; }
        public DbSet<Trust> Trusts { get; set; }
        public DbSet<TrustGroup> trustGroups { get; set; }



    }
}
