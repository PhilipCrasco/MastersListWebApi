using ClassLibrary.model;
using ClassLibrary.model.Masterlist;
using ClassLibrary.model.PoSummary;
using Microsoft.EntityFrameworkCore;
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

        public virtual DbSet<ItemCode> ItemCodes { get; set; }
        public virtual DbSet<Uom> Uoms { get; set; }
        public virtual DbSet<VendorName> VendorNames { get; set; }

        public virtual DbSet<PoSummary> PoSummaries { get; set; }



    }
}
