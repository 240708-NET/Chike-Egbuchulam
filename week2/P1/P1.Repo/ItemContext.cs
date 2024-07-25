using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using P1.Models;

namespace P1.Repo
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Owner> Owners => Set<Owner>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = "Server=localhost;User=SA;Password=NotPassword123!;Database=Items;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }


}