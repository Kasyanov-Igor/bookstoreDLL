using bookstore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Services.Interfaces
{
	public abstract class ADatabaseConnection : DbContext
	{
		protected abstract string ReturnConnectionString();

		protected string ConnectionString { get; private set; }

		public DbSet<Book> Books => Set<Book>();

		public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();

		public DbSet<BookGenre> BookGenres => Set<BookGenre>();

		public DbSet<BookPublisher> BookPublisher => Set<BookPublisher>();

		public DbSet<PurchaseHistory> PurchaseHistory => Set<PurchaseHistory>();

		public DbSet<User> Users => Set<User>();

		public DbSet<Wallet> Wallets => Set<Wallet>();

		public ADatabaseConnection()
		{
			this.ConnectionString = this.ReturnConnectionString();
			this.Database.EnsureCreated();
		}
	}
}
