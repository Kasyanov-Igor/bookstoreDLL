using bookstore.Models.Domains;
using bookstore.Models.Entities;

namespace bookstore.Services.Interfaces
{
	public interface IUserService
	{
		public bool AddUser(User user);

		public User? FindUser(User user);

		public bool DeleteUser(User user);

		/*! 
		* @brief Buying a book, charging money from the user's balance.
		* @param[in] book - purchasable record.
		* @param[in] user - book buyer.
		* @return True - book purchased; False - book not purchased.
		*/
		public bool BuyBook(User user, Book book);

		/*! 
		* @brief Checking the presence of a user in the database.
		* @param[in] user - whose data is being verified.
		* @return True - user login matches; False - user login not matches.
		*/
		public bool IdentificationUser(DTOUser domainUser);
	}
}
