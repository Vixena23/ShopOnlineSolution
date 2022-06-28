using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;

namespace ShopOnline.Api.IntegrationTests
{
    //if we want testing with test database! 
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=ShopOnlineTest;Trusted_Connection=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

            public ShopOnlineDbContext CreateContext()
            => new ShopOnlineDbContext(
                new DbContextOptionsBuilder<ShopOnlineDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}
