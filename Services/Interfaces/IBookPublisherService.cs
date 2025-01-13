using bookstore.Models.Entities;

namespace bookstore.Services.Interfaces
{
	public interface IBookPublisherService
	{
		/*!
		* @brief Method to add book publisher.
		* @param[in] bookPublisher - The book publisher object.
		* @return True - if the addition was successful; False - otherwise.
		*/
		public bool AddBookPublisher(BookPublisher bookPublisher);
	}
}
