using bookstore.Models.Entities;
using bookstore.Services.Interfaces;

namespace bookstore.Services
{
	public class BookPublisherService : IBookPublisherService
	{
		private ADatabaseConnection _connection;

		public BookPublisherService(ADatabaseConnection connection)
		{
			this._connection = connection;
		}

		public bool AddBookPublisher(BookPublisher bookPublisher)
		{
			try
			{
				this._connection.BookPublisher.Add(bookPublisher);
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
