using Core.Entities;
using Infrastructure.Migrations.DbApp;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options)
           : base(options)
        {
        }
        public DbSet<Books> Book { get; set; }

        public DbSet<Authors> Author { get; set; }
        public DbSet<Category> category { get; set; }

        public DbSet<MessageUsers> MessageUsers { get; set; }
        public DbSet<Basket> basket { get; set; }
        public DbSet<BookBasket> BookBasket { get; set; }
        public DbSet<bookMarkBook> bookMarkBook  { get; set; }
        public DbSet<BookMark> bookMark  { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Authors>().HasKey(x => x.AuthorId);
            builder.Entity<Category>().HasKey(x => x.categoryId);
            builder.Entity<Category>().Property(x => x.categoryId).ValueGeneratedNever();
            builder.Entity<Basket>().Property(x => x.BasketId);
            builder.Entity<BookBasket>().Property(x => x.Id);
            builder.Entity<bookMarkBook>().Property(x => x.Id);
            builder.Entity<BookMark>().Property(x => x.BookMarkId);
            builder.Entity<Authors>().HasMany(x => x.Books).WithOne(x => x.Authors).HasForeignKey(x => x.AuthorId).HasPrincipalKey(x => x.AuthorId);
            builder.Entity<Category>().HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).HasPrincipalKey(x => x.categoryId);
            builder.Entity<MessageUsers>().HasKey(x => x.MessageId);
            builder.ApplyConfigurationsFromAssembly(typeof(DbAppContext).Assembly);

        }
    }
}
