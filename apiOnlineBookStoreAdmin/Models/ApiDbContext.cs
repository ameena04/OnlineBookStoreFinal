using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiOnlineBookStoreAdmin.Models;

namespace apiOnlineBookStoreAdmin.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {

        }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publication>()
                .HasIndex(u => u.PublicationName)
                .IsUnique();


            modelBuilder.Entity<BookCategory>()
                .HasIndex(u => u.BookCategoryName)
                .IsUnique();
                                 
            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(e => e.PublicationName)
                .HasColumnName("PublicationName")
                .HasMaxLength(30)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorName)
                .HasColumnName("AuthorName")
                .HasMaxLength(30)
                .IsUnicode(false);
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.Property(e => e.BookCategoryName)
                .HasColumnName("BookCategoryName")
                .HasMaxLength(30)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookName)
                .HasColumnName("BookName")
                .HasMaxLength(30)
                .IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<Customer>()
               .HasIndex(u => u.UserName)
               .IsUnique();

            modelBuilder
              .Entity<Admin>()
              .HasIndex(u => u.AdminUserName)
              .IsUnique();


            modelBuilder.Entity<OrderBook>
                (build =>
                {
                    build.HasKey(b => new { b.OrderId, b.BookId });
                }
                );


        }


     

    }
}

