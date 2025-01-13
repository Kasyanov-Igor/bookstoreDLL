using bookstore.Models.Entities;

namespace bookstore.Services.Interfaces
{
	public interface IBookGenreService
	{

		/*!
		* @brief Adding genres to our database.
		* @param[in] bookGenre - class instance to add.
		* @return True - book genre added; False - book genre not added.
		*/
		public bool AddBookGenre(BookGenre bookGenre);
	}
}
