using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infra.Persistence.Configs
{
    public abstract class ConnectionConfig : IDisposable
    {
        protected readonly SqlConnection _connection;

        protected ConnectionConfig(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _connection?.Dispose();
        }
    }
}