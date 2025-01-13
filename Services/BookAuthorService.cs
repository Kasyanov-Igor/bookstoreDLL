using bookstore.Models.Entities;
using bookstore.Services.Interfaces;

namespace bookstore.Services
{
	public class BookAuthorService : IBookAuthorService
	{
		private ADatabaseConnection _connection;

		public BookAuthorService(ADatabaseConnection connection)
		{
			_connection = connection;
		}
		
		public bool AddBookAuthor(BookAuthor bookAuthor)
		{
			try
			{
				this._connection.BookAuthors.Add(bookAuthor);
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
