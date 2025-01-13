using bookstore.Models.Entities;
using bookstore.Services.Interfaces;

namespace bookstore.Services
{
	public class BookGenreService : IBookGenreService
	{
		private ADatabaseConnection _connection;

		public BookGenreService(ADatabaseConnection connection)
		{
			_connection = connection;
		}

		public bool AddBookGenre(BookGenre bookGenre)
		{
			try
			{
				this._connection.BookGenres.Add(bookGenre);
				this._connection.SaveChanges();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}

			return false;
		}
	}
}
