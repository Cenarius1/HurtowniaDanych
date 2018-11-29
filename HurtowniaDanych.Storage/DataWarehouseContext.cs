using HurtowniaDanych.Advertisement.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// DbContext derived class
/// </summary>
namespace HurtowniaDanych.Storage {
    public class DataWarehouseContext : DbContext {
        //public DbSet<CarTopic> Cars { get; set; }

        public DbSet<Details> CarDetails { get; set; }

        public DbSet<Features> CarFeatures { get; set; }

        public DbSet<Schema> AdSchema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Table Splitting
            modelBuilder.Entity<Schema>().HasOne(a => a.VehicleEngine).WithOne(b => b.Schema).HasForeignKey<VehicleEng>(e => e.AdId);
            modelBuilder.Entity<Schema>().HasOne(a => a.MileageFromOdometer).WithOne(b => b.Schema).HasForeignKey<Mileages>(e => e.AdId);
            modelBuilder.Entity<Schema>().HasOne(a => a.Offers).WithOne(b => b.Schema).HasForeignKey<Offers>(e => e.AdId);

            modelBuilder.Entity<Schema>().ToTable("CarSchema");
            modelBuilder.Entity<VehicleEng>().ToTable("CarSchema");
            modelBuilder.Entity<Mileages>().ToTable("CarSchema");
            modelBuilder.Entity<Offers>().ToTable("CarSchema");
            base.OnModelCreating(modelBuilder);
        }
    }
}
