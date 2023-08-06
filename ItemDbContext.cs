using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Item_Marketplace;

public partial class ItemDbContext : DbContext
{
    public ItemDbContext()
    {
    }

    public ItemDbContext(DbContextOptions<ItemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=marynapc;Database=ItemDb;Integrated Security=True;Trusted_Connection=True;User Id=user1; Password=sa; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.ToTable("Auction");

            entity.HasIndex(e => e.ItemId, "IX_Auction_ItemId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.Auctions).HasForeignKey(d => d.ItemId);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
