using System;
using Microsoft.EntityFrameworkCore;

namespace P1.Repo
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        public ItemContext( DbContextOptions<ItemContext> options) : base( options ){}

    }


}