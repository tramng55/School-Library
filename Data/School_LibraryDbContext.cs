using Microsoft.EntityFrameworkCore;
using School_Library.Models;
using System;

namespace School_Library.Data
{
    public class School_LibraryDbContext: DbContext
    {
        public School_LibraryDbContext(DbContextOptions<School_LibraryDbContext> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAssignment> BookAssignments { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Checkin_out> Checkin_outs { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<BookAssignment>().ToTable("BookAssignment");
            modelBuilder.Entity<Borrow>().ToTable("Borrow");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Checkin_out>().ToTable("Checkin_out");
            modelBuilder.Entity<Producer>().ToTable("Producer");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}
