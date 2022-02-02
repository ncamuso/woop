using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Spoil_Block.Models
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

        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMedium> UserMedia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=WOOPConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserMedium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.UserMedia)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_UserMedia_Media_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMedia)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_UserMedia_User_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
