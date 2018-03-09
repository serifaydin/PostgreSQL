using Npgsql;
using System.Data;

namespace PostgreSQL.Service
{
    public class StateConnection
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=my_demo; User Id=postgres; Password = 123;");

        protected NpgsqlConnection ConnectionOpen()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        protected void ConnectionClosed()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}