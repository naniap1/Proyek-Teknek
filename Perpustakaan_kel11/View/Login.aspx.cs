using System;
using System.Data;
using Perpustakaan_kel11.Models;

namespace Perpustakaan_kel11.View
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Con = new Functions();
		}

		Models.Functions Con;
		public static string UName { get; set; } // Properti statis untuk menyimpan nama pengguna
		public static int UKey { get; set; } // Properti statis untuk menyimpan kunci pengguna

		protected void SaveBtn_Click(object sender, EventArgs e)
		{
			if (AdminRadio.Checked)
			{
				if (EmailId.Text == "Admin@gmail.com" && UserPasswordTb.Text == "Admin")
				{
					Response.Redirect("Admin/Dashboard.aspx");
				}
				else
				{
					InfoMsg.Text = "Invalid Admin!!";
				}
			}
			else
			{
				string Query = "SELECT UserId, Nama, Email, Alamat FROM UserTbl WHERE Email = '{0}' AND Password = '{1}'";
				Query = string.Format(Query, EmailId.Text, UserPasswordTb.Text);
				DataTable dt = Con.GetData(Query); // Panggil metode GetData untuk mendapatkan data dari database

				if (dt.Rows.Count == 0)
				{
					InfoMsg.Text = "Invalid User!!!";
				}
				else
				{
					UName = EmailId.Text;
					UKey = Convert.ToInt32(dt.Rows[0]["UserId"]); // Mengambil UserId dari hasil kueri

					// Set UKey ke dalam sesi
					Session["UserID"] = UKey;

					Response.Redirect("User/Billing.aspx");
				}
			}
		}


	}
}
