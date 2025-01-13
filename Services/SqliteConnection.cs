using bookstore.Models.Entities;
using bookstore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Services
{
	public class SqliteConnection : ADatabaseConnection
	{
		public const string _DATABASE_NAME = "../BookStore.db";

		protected override string ReturnConnectionString()
		{
			return $"Data Source={_DATABASE_NAME}";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(this.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookAuthor) 
                .WithMany()
                .HasForeignKey(b => b.BookAuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
