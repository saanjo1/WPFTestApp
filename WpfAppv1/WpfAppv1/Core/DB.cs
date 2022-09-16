using Microsoft.EntityFrameworkCore;
using WpfAppv1.Models;

namespace WpfAppv1.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Category 1",
                    Order = 2,
                    Deleted = false,
                    Printer = "Test1"
                });

            modelBuilder.Entity<SubCategory>()
               .HasData(
               new SubCategory
               {
                   SubCategoryId = 1,
                   Name = "SubCategory 1",
                   Order = 2,
                   Deleted = false,
                   Printer = "Test1",
                   CategoryId = 1,
                   Tag = "Asd"
               });

            modelBuilder.Entity<Article>()
               .HasData(
               new Article
               {
                   Id = 1,
                   Name = "Article 1",
                   SubCategoryId = 1,
                   BarCode = "BarCode#1",
                   Price = "144",
               });
        }
    }

}