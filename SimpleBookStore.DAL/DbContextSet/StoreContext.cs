using KhatiExtendedEF.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleBookStore.DAL.StoreEntity;

namespace SimpleBookStore.DAL.DbContextSet
{
    public class StoreContext : DatabaseContextIdentityUser<IStoreEntity, User>
    {
        private readonly IConfiguration _configuration;
        public StoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override string connectionString() => _configuration.GetConnectionString("StoreConnection");
    }
}
