using ConsoleLesha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;

namespace ConsoleLesha
{
    internal class WSContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; }
        public DbSet<HelmetProduct> HelmetProducts { get; set; }
        public DbSet<SkiBootsProduct> SkiBootsProducts { get; set; }
        public DbSet<SkiPoleProduct> SkiPoleProducts { get; set; }
        public DbSet<SkiProduct> SkiProducts { get; set; }

        //public WSContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string pathToJsonFile = "appsettings.json";

            string jsonContent = File.ReadAllText(pathToJsonFile);

            JsonDocument jsonObject = JsonDocument.Parse(jsonContent);

            JsonElement root = jsonObject.RootElement;

            if (root.TryGetProperty("ConnectionStrings", out JsonElement connectionStrings))
            {
                if (connectionStrings.TryGetProperty("DefaultConnection", out JsonElement defaultConnection))
                {
                    string connectionString = defaultConnection.GetString();
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }

            jsonObject.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTptMappingStrategy();
            modelBuilder.Entity<User>()
                        .HasMany(l => l.Cart)
                        .WithOne(t => t.User)
                        .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<HelmetProduct>().ToTable("HelmetProduct");
            modelBuilder.Entity<SkiBootsProduct>().ToTable("SkiBootsProduct");
            modelBuilder.Entity<SkiPoleProduct>().ToTable("SkiPoleProduct");
            modelBuilder.Entity<SkiProduct>().ToTable("SkiProduct");

        }

    }
}


/*            modelBuilder.Entity<Product>().Property(u => u.Id).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(t => t.Status).HasConversion<string>();*/




