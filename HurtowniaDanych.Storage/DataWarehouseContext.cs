using HurtowaniaDanych.Domain;
using HurtowniaDanych.Advertisement.Models;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaDanych.Storage {
    public class DataWarehouseContext : DbContext {
        public DbSet<CarTopic> Cars { get; set; }

        public DbSet<Details> CarDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
