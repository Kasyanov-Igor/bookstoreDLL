using bookstore.Models.Entities;

namespace bookstore.Services.Interfaces
{
	public interface IBookService
	{
		/*!
		* @brief Creates a book and returns it
		* @return returns realisation of book
		*/
		public Book CreateBook();

        /*! 
		* @brief Adding book to our database.
		* @param[in] book - class instance to add.
		* @return True - book added; False - book not added.
		*/
        public bool AddBook(Book book);

		/*! 
		* @brief Searches for a book by its name.
		* @return The first matching book found, or null if no match is found.
		*/
		public Book? SearchByName(string name);

		/*!
		* @brief Seaches for the books by authors name.
		* @return List of books which were found by the authors name.
		*/
        List<Book> SearchByAuthor();

        /*!
		* @brief Seaches for the books by genre.
		* @return List of books which were found by the genre.
		*/
        List<Book> SearchByGenre(string genreName);

		/*!
		* @brief Gets the Top 10 best sold books.
		* @return Top 10 most sold books.
		*/
        List<Book> GetBestsellers(string time);

        /*! 
		* @brief Retrieves a list of newly added books from the last month.
		* @return A list of books that were added to the database within the last month.
		*/
        public List<Book> GetNewBooks();

		/*! 
		* @brief Deleting books in our database.
		* @param[in] book - class instance to delete.
		* @return True - book deleted; False - book not deleted.
		*/
		public bool DeleteBook(Book book);
	}
}