using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado1
{
    class Program
    {

        static void Main(string[] args)
        {
            acssesCon();
            Console.ReadKey();
        }

        public static void SqlConnection()
        {
            string connectionString = @"Data Source=192.168.111.139;Initial Catalog=MCS;User ID=sa;Password=Ev4865";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            Console.WriteLine(con.Database);
            Console.WriteLine(con.DataSource);
            Console.WriteLine(con.State);


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from TablesModel";
            cmd.Connection = con;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Name {dr[1]}");
                Console.WriteLine($"Image {dr[4]}");
                Console.WriteLine();
            }

            con.Close();
            dr.Close();
        }
        public static void ODBCConnection()
        {
            
            string connectionString="Driver={SQL Server Native Client 11.0};Server=192.168.111.139;Database=MCS;Uid=sa;Pwd=Ev4865";

            OdbcConnection con = new OdbcConnection();
            con.ConnectionString = connectionString;

            Console.WriteLine(con.Database);
            Console.WriteLine(con.DataSource);
            Console.WriteLine(con.State);


            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = "select * from TablesModel";
            cmd.Connection = con;
            con.Open();
            OdbcDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"Name {dr[1]}");
                Console.WriteLine($"Image {dr[4]}");
                Console.WriteLine();
            }

            dr.Close();

            cmd.CommandText = "select count(*) from TablesModel";
            int Count = Int32.Parse(cmd.ExecuteScalar().ToString());
            Console.WriteLine("Count rows in TablesModel = {0}",Count);


        }
        public static void OLEConnection()
        {
            string connectionString = "Provider=SQLNCLI11;Server=192.168.111.139;Database=MCS;Uid=sa;Pwd=Ev4865";

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = connectionString;

            Console.WriteLine(con.Database);
            Console.WriteLine(con.DataSource);
            Console.WriteLine(con.State);


            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from TablesModel";
            cmd.Connection = con;
            con.Open();
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"Name {dr[1]}");
                Console.WriteLine($"Image {dr[4]}");
                Console.WriteLine();
            }

            dr.Close();

            cmd.CommandText = "select count(*) from TablesModel";
            int Count = Int32.Parse(cmd.ExecuteScalar().ToString());
            Console.WriteLine("Count rows in TablesModel = {0}", Count);


        }
        static void acssesCon()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=accessDb.accdb;Persist Security Info=False";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = connectionString;

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from TablesModel";
            cmd.Connection = con;
            con.Open();
            Console.WriteLine(con.State);
            var result = cmd.ExecuteScalar();
            Console.WriteLine(result);
            con.Close();
        }
    }
}
