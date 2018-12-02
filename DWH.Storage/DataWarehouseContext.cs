using DWH.Domain;
using System.Data.Entity;

namespace DWH.Storage {
    public class DataWarehouseContext : DbContext {
        public DbSet<LoadCarDetail> CarDetails { get; set; }

        public DataWarehouseContext() : base("DWH-Database1") {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<LoadCarDetail>().ToTable("CarDetails");
        }
    }
}
