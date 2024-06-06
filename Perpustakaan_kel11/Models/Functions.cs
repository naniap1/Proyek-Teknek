using System;
using System.Data;
using System.Data.SqlClient;

namespace Perpustakaan_kel11.Models
{
	public class Functions
	{
		private SqlConnection Con;
		private SqlCommand cmd;
		private DataTable dt;
		string ConnString;

		public Functions()
		{
			ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\napit\OneDrive\Documents\Perpustakaan_kel11.mdf;Integrated Security=True;Connect Timeout=30";
			Con = new SqlConnection(ConnString);
			cmd = new SqlCommand();
			cmd.Connection = Con;
		}

		public string GetConnectionString()
		{
			return ConnString;
		}

		public DataTable GetData(string Query, System.Collections.Generic.Dictionary<string, object> dictionary)
		{
			dt = new DataTable();
			if (Con.State == ConnectionState.Closed)
			{
				Con.Open();
			}
			cmd.CommandText = Query;
			SqlDataReader reader = cmd.ExecuteReader();
			dt.Load(reader);
			reader.Close();
			Con.Close();
			return dt;
		}

		public int SetData(string Query)
		{
			int Cnt = 0;
			if (Con.State == ConnectionState.Closed)
			{
				Con.Open();
			}
			cmd.CommandText = Query;
			Cnt = cmd.ExecuteNonQuery();
			Con.Close();
			return Cnt;
		}

		public DataTable GetData(string query)
		{
			dt = new DataTable();
			if (Con.State == ConnectionState.Closed)
			{
				Con.Open();
			}
			cmd.CommandText = query;
			SqlDataReader reader = cmd.ExecuteReader();
			dt.Load(reader);
			reader.Close();
			Con.Close();
			return dt;
		}


	}
}
