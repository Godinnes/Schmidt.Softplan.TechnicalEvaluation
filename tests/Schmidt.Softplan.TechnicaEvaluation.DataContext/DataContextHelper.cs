using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Schmidt.Softplan.TechnicaEvaluation.DataContext
{
    public static class DataContextHelper
    {
        public static TDBContext CreateContextHelper<TDBContext>()
            where TDBContext : DbContext
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<TDBContext>()
                    .UseSqlite("FullUri=file::memory:?cache=shared;")
                    .UseInternalServiceProvider(serviceProvider)
                    .Options;

            var constructor = typeof(TDBContext).GetConstructors(BindingFlags.Public | BindingFlags.Instance)[0];
            return (TDBContext)constructor.Invoke(new object[] { options });
        }
        public static SqliteConnection CreateInMemoryDatabase()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "memory", Mode = SqliteOpenMode.Memory, Cache = SqliteCacheMode.Shared };
            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);

            connection.Open();

            return connection;
        }
    }
}
