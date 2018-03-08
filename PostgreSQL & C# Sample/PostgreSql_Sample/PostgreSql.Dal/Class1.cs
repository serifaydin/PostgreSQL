using Npgsql;
using System;
using System.Data;

namespace PostgreSql.Dal
{
    public class Class1
    {
        public void GetUser()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=my_demo; User Id=postgres; Password = 123;");
            DataSet dataSet = new DataSet();

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {

                throw;
            }

            NpgsqlDataAdapter add = new NpgsqlDataAdapter("select * from tblUser", connection);
            add.Fill(dataSet);

        }
    }
}