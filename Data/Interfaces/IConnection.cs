using Microsoft.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IConnection
    {
        public SqlConnection GetConnection();
    }
}
