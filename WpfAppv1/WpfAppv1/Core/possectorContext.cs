using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WpfAppv1.Models;

namespace WpfAppv1.Core
{
    public partial class possectorContext : DbContext
    {
        public possectorContext()
        {
        }

        public possectorContext(DbContextOptions<possectorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
       
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=possector;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ReturnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_Id");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.SubCategoryId);
            });

            

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.StorageId, "IX_Storage_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.StorageId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            });

           
            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Category_Id");

                entity.HasIndex(e => e.StorageId, "IX_Storage_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.StorageId);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
