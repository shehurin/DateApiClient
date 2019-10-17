using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebApi.Loger
{
    public class Loger
    {
        SqlDataAdapter adapter;
        DataSet dataset;
        SqlCommandBuilder commandBuilder;
        string sqlConnectionString = "Data Source=COMPUTER\\SQLEXPRESS;Initial Catalog=DateDB;Integrated Security=True";
        string sql = "select * from [ClientLog]";

        public Loger()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                dataset = new DataSet();
                adapter.Fill(dataset);
            }
        }

        public void AddLog(LogEntity log)
        {
            DataRow row = dataset.Tables[0].NewRow();
            row["RequestMethod"] = log.RequestMethod;
            row["Response"] = log.Response;
            row["DateOfRequest"] = log.DateOfRequest;
            row["Request"] = log.Request;
            dataset.Tables[0].Rows.Add(row);
        }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dataset);
            }
        }
    }
}
