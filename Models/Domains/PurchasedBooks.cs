using bookstore.Models.Entities;

namespace bookstore.Models.Domains
{
	public class PurchasedBooks
	{
		public User User { get; set; } = null!;

		public Book Book { get; set; } = null!;
	}
}
