using bookstore.Models.Entities;

namespace bookstore.Services.Interfaces
{
	public interface IBookAuthorService
	{

		/*!
		 * @brief Method to add a book author.
		 * @param[in] bookAuthor - The author of the book.
		 * @return True - if the addition was successful; False - otherwise.
		 */
		public bool AddBookAuthor(BookAuthor bookAuthor);
	}
}
