using bookstore.Services.Interfaces;
using bookstore.Models.Entities;

namespace bookstore.Services
{
	public class BookService : IBookService
	{
		private readonly ADatabaseConnection _connection; ///< Database connection

		public BookService(ADatabaseConnection connection)
		{
			this._connection = connection;
		}

		public Book CreateBook()
		{
			Console.Clear();

			Book book = new Book();

			Console.WriteLine("Whats the name of the book?");
			book.Name = Console.ReadLine().ToLower();
			Console.Clear();

			Console.WriteLine("Whats the first name of the author?");
			BookAuthor author = new BookAuthor();
			author.FirstName = Console.ReadLine().ToLower();
			Console.WriteLine("Whats the last name of the author?");
			author.LastName = Console.ReadLine().ToLower();
			book.BookAuthor = author;
			Console.Clear();

			Console.WriteLine("Whats the name of the books publisher?");
			book.BookPublisher = new BookPublisher() { Name = Console.ReadLine().ToLower() };
			Console.Clear();

			Console.WriteLine("How many pages does the book have?");
			book.CountPages = Convert.ToUInt32(Console.ReadLine());
			Console.Clear();

			Console.WriteLine("What genre is the book?");
			book.BookGenre = new BookGenre() { Name = Console.ReadLine().ToLower() };
			Console.Clear();

			Console.WriteLine("In what data was this book published?");

			DateTime dateTime = Convert.ToDateTime(Console.ReadLine());

			book.PublicationYear = dateTime;
			Console.Clear();

			Console.WriteLine("How much is the cost price of the book?");

			book.CostPrice = Convert.ToUInt32(Console.ReadLine());

			Console.Clear();

			Console.WriteLine("How much is the selling price of the book?");

			book.SellingPrice = Convert.ToUInt32(Console.ReadLine());

			Console.Clear();

			Console.WriteLine("Whats the date of the books receipt?");

			dateTime = Convert.ToDateTime(Console.ReadLine());

			book.DateOfReceiptOfBook = dateTime;

			Console.Clear();

			Console.WriteLine("Is that book a continuation? true or false");

			book.IsContinuation = Convert.ToBoolean(Console.ReadLine().ToLower());
			Console.Clear();

			return book;
		}

		public bool AddBook(Book book)
		{
			try
			{
				this._connection.Books.Add(book);
				this._connection.SaveChanges();

				Console.WriteLine("Book added successfully!");

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return false;
		}

		public Book? SearchByName(string name)
		{
			return _connection.Books
					   .Where(vr => vr.Name == name)
					   .FirstOrDefault();
		}

		public List<Book> SearchByAuthor()
		{
			Console.Clear();

			Console.WriteLine("What is the full author's name?");
			string authorFullName = Console.ReadLine().ToLower();

			List<Book> books = _connection.Books.ToList();
			List<BookAuthor> authors = _connection.BookAuthors.ToList();

			var booksWithAuthors = books
				.Where(book => book.BookAuthorId.HasValue)
				.Join(authors,
					  book => book.BookAuthorId.Value,
					  author => author.Id,
					  (book, author) => new
					  {
						  book.Name,
						  AuthorFullName = author.FirstName + " " + author.LastName,
						  book.LastSoldDate,
						  book
					  })
				.Where(x => x.AuthorFullName.Contains(authorFullName, StringComparison.OrdinalIgnoreCase))
				.ToList();

			return booksWithAuthors.Select(x => x.book).ToList();
		}

		public List<Book> SearchByGenre(string genreName)
		{
			return _connection.Books
					   .Where(b => b.BookGenre.Name.Contains(genreName, StringComparison.OrdinalIgnoreCase))
					   .ToList();
		}

		public List<Book> GetNewBooks()
		{
			DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
			return _connection.Books
					   .Where(vr => vr.DateOfReceiptOfBook >= oneMonthAgo)
					   .ToList();
		}

		public bool DeleteBook(Book book)
		{
			try
			{
				this._connection.Books.Remove(book);
				this._connection.SaveChanges();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return false;
		}

		/*!
		* @brief Gets the Top 10 best sold books based on the given time frame.
		* @param[in] time - The time range ("day", "month", "year").
		* @return Top 10 most sold books within the specified time frame.
		*/
		public List<Book> GetBestsellers(string time)
		{
			DateTime now = DateTime.Now;
			DateTime startDate;

			switch (time.ToLower())
			{
				case "day":
					startDate = now.Date;
					break;
				case "month":
					startDate = new DateTime(now.Year, now.Month, 1);
					break;
				case "year":
					startDate = new DateTime(now.Year, 1, 1);
					break;
				default:
					Console.WriteLine("Invalid time range. Please choose 'day', 'month', or 'year'.");
					return new List<Book>();
			}

			return _connection.Books.Where(book => book.LastSoldDate >= startDate).OrderByDescending(book => book.SalesCount)
				.Take(10).ToList();
		}
	}
}
