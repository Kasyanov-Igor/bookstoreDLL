using bookstore.Services.Interfaces;

namespace bookstore.Services
{
	public class FactoryMapper : IFactoryMapper
	{
		private MapperConfig mapperConfig;

		public FactoryMapper() => mapperConfig = new MapperConfig();

		public MapperConfig GetMapperConfig()
		{
			return mapperConfig;
		}
	}
}
