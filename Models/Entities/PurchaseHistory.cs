namespace bookstore.Models.Entities
{
	public class PurchaseHistory
	{
		public int Id { get; set; }

		public User User { get; set; } = null!;

		public Book Book { get; set; } = null!;

		public DateTime DatePurchase { get; set; }
	}
}
