using bookstore.Models.Entities;

namespace bookstore.Models.Domains
{
	public class DTOUser
	{
		public string Login { get; set; } = null!;

		public Wallet Wallet { get; set; } = null!;
	}
}
