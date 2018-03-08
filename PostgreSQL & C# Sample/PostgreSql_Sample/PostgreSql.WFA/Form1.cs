using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSql.WFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataDoldur();
        }

        public void DataDoldur()
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

            string sql = "SELECT * FROM public.\"tblUser\"";

            NpgsqlDataAdapter add = new NpgsqlDataAdapter(sql, connection);
            add.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
            connection.Close();


        }
    }
}