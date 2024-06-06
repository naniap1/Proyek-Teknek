using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Perpustakaan_kel11.View.Admin
{
	public partial class Dashboard : System.Web.UI.Page
	{
		Models.Functions Con;
		protected void Page_Load(object sender, EventArgs e)
		{
			Con = new Models.Functions();
			GetProducts();
			GetCategories();
			SumSell();
			GetUsers();
		
		}




		private void GetProducts()
		{
			// Query untuk mengambil jumlah produk dari database
			string query = "SELECT COUNT(*) AS Jumlah FROM ProductTbl";
			PNumTb.InnerText = Con.GetData(query).Rows[0][0].ToString();
			PNumTb.DataBind();
		}

		private void GetCategories()
		{
			// Query untuk mengambil jumlah produk dari database
			string query = "SELECT COUNT(*) AS Jumlah FROM CategoryTbl";
			CatNumTb.InnerText = Con.GetData(query).Rows[0][0].ToString();
			CatNumTb.DataBind();
		}

		private void SumSell()
		{
			// Query untuk mengambil jumlah produk dari database
			string query = "SELECT Sum(Jumlah)  FROM BillTbl";
			FinanceTb.InnerText ="Rp. " + Con.GetData(query).Rows[0][0].ToString();
			FinanceTb.DataBind();
		}

		private void GetUsers()
		{
			// Query untuk mengambil jumlah produk dari database
			string query = "SELECT COUNT(*) AS Jumlah FROM UserTbl";
			UserNumTb.InnerText = Con.GetData(query).Rows[0][0].ToString();
			UserNumTb.DataBind();
		}





		protected void UserCb_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}