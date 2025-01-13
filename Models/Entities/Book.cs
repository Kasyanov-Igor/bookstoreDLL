using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Models.Entities
{
	public class Book
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public virtual BookAuthor BookAuthor { get; set; } = null!;

        public BookPublisher BookPublisher { get; set; } = null!;

		public uint CountPages { get; set; }

		public BookGenre BookGenre { get; set; } = null!;

		public DateTime PublicationYear { get; set; }

		public int? BookAuthorId { get; set; }

        public uint CostPrice { get; set; }

		public uint SellingPrice { get; set; }

		public DateTime DateOfReceiptOfBook { get; set; }

		public bool IsContinuation { get; set; }

        public int SalesCount { get; set; }

        public DateTime LastSoldDate { get; set; } ///< Date of the most recent sale
    }
}
