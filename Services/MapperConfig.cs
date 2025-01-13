using AutoMapper;
using bookstore.Models.Domains;
using bookstore.Models.Entities;

namespace bookstore.Services
{
	public class MapperConfig : Profile
	{
		public static object InitializeAutomapper()
		{
			throw new NotImplementedException();
		}

		/*! 
		* @brief Create map Mapper by field.
		*/
		public MapperConfig()
		{
			CreateMap<User, DTOUser>().ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login));
			CreateMap<PurchaseHistory, PurchasedBooks>().ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
					.ForMember(dest => dest.Book, act => act.MapFrom(src => src.Book));
		}

		/*! 
		* @brief Create Configuration Mapper.
		* @return IMapper - Mapper Configuration.
		*/
		public IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>());
			return config.CreateMapper();
		}
	}
}
