using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpoilBlock.Models
{
    public partial class WOOPDbContext : DbContext
    {
        public WOOPDbContext()
        {
        }

        public WOOPDbContext(DbContextOptions<WOOPDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medium> Media { get; set; } = null!;
        public virtual DbSet<Woopuser> Woopusers { get; set; } = null!;
        public virtual DbSet<WoopuserMedium> WoopuserMedia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=WOOPConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WoopuserMedium>(entity =>
            {
                entity.HasOne(d => d.Media)
                    .WithMany(p => p.WoopuserMedia)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_WOOPUserMedia_Media_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WoopuserMedia)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_WOOPUserMedia_User_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
