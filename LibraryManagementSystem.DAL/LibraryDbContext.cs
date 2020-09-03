using LibraryManagementSystem.DAL.Models;
using System.Data.Entity;

namespace LibraryManagementSystem.DAL
{
    public class LibraryDbContext : DbContext
    {
        public readonly LibraryDbContext _context;
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Role> Roles { get; set; }

        public LibraryDbContext() : base("DbConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>()
                .HasRequired(r => r.Book)
                .WithRequiredDependent(b => b.Rent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Dimensions)
                .WithRequiredDependent(d => d.Book)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
