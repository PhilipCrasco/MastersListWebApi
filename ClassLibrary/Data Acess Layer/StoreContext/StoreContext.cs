using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using ClassLibrary.Data_Acess_Layer.model.Receiving;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.model;
using ClassLibrary.model.Masterlist;
using ClassLibrary.model.PoSummary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Persistence
{
    public  class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }



        //UserModel

        public virtual DbSet<Users> users { get; set; }
        public virtual DbSet<Roles> Role { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<MainMenu> Mainmenu { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<UserRoleModule> UserRolermodule { get; set; }

        //MasterFile

        public virtual DbSet<ItemCode> ItemCodes { get; set; }
        public virtual DbSet<Uom> Uoms { get; set; }
        public virtual DbSet<VendorName> VendorNames { get; set; }

        public virtual DbSet<PoSummary> PoSummaries { get; set; }

        public virtual DbSet<Warehouse_Receiving> WarehouseRecieve { get; set; }

        public virtual DbSet<Warehouse_Reject> WareHouseReject { get; set; }

        public virtual DbSet<Customer> Customers { get; set;  }
        public virtual DbSet <ItemCategory> ItemCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DevConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
