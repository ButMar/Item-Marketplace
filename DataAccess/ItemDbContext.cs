using System;
using Item_Marketplace.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Item_Marketplace.DataAccess
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options) { }

        public DbSet<Item> Item { get; set; }
        public DbSet<Auction> Auction { get; set; }

    }
}
