using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf08EntityFramework.Models;

namespace Wpf08EntityFramework.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public ApplicationDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=myBooks.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasIndex(u => u.BookId)
                .IsUnique();
            builder.Entity<Book>().HasData(new Book { BookId = 1, Title = "Společenstvo prstenu", Pages = 300 });
        }
    }
}
