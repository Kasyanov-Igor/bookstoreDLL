using bookstore.Models.Domains;
using bookstore.Models.Entities;
using bookstore.Services.Interfaces;

namespace bookstore.Services
{
	public class UserService : IUserService
	{
		private ADatabaseConnection _databaseConnection;

		private readonly IFactoryMapper _factoryMapper;

		public UserService(ADatabaseConnection aDatabaseConnection, IFactoryMapper factoryMapper)
		{
			this._databaseConnection = aDatabaseConnection;
			this._factoryMapper = factoryMapper;
		}

		public bool AddUser(User user)
		{
			try
			{
				User? foundUser = this.FindUser(user);

				if (foundUser == null)
				{
					this._databaseConnection.Users.Add(user);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public User? FindUser(User user)
		{
			try
			{
				return this._databaseConnection.Users.Where(usr =>
				usr.Login == user.Login &&
				usr.Password == user.Password).FirstOrDefault();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return null;
		}

		public bool DeleteUser(User user)
		{
			try
			{
				User? foundUser = this.FindUser(user);

				if (foundUser != null)
				{
					this._databaseConnection.Users.Remove(foundUser);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public bool BuyBook(User user, Book book)
		{
			DTOUser domainUser = this._factoryMapper.GetMapperConfig().CreateMapper().Map<DTOUser>(user);  ///< Data entry into the domain model.

			domainUser.Wallet = new Wallet() { BalanceUser = 1000 };

			try
			{
				if (domainUser.Wallet.BalanceUser >= book.CostPrice)
				{
					domainUser.Wallet.BalanceUser -= book.CostPrice; ///< Write off funds from the balance.

					PurchaseHistory history = new PurchaseHistory() { User = user, Book = book, DatePurchase = DateTime.Now };

					PurchasedBooks books = this._factoryMapper.GetMapperConfig().CreateMapper().Map<PurchasedBooks>(history);  ///< Data entry into the domain model.

					this._databaseConnection.PurchaseHistory.Add(history);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public bool IdentificationUser(DTOUser domainUser)
		{
			List<DTOUser> domainUsers = new List<DTOUser>();

			foreach (var user in this._databaseConnection.Users)
			{
				domainUsers.Add(this._factoryMapper.GetMapperConfig().CreateMapper().Map<DTOUser>(user));  ///< Data entry into the domain model.
			}

			try
			{
				return domainUsers.Any(log => log.Login == domainUser.Login); ///< Checking the presence of elements. 
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}
	}
}
