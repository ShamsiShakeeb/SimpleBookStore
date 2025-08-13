using KhatiExtendedADO;
using Microsoft.Extensions.Configuration;

namespace SimpleBookStore.DAL.ADO.Context
{
    public class StoreAdoContext : AdoProperties, IStoreAdoContext
    {
        private readonly IConfiguration _configuration;
        public StoreAdoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override string ConnectionString()
        {
            return _configuration.GetConnectionString("StoreConnection");
        }
    }
}
