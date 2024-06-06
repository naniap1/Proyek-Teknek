using System;
using System.Data;
using Perpustakaan_kel11.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Perpustakaan_kel11.View.Admin
{
	public partial class User : System.Web.UI.Page
	{
		Models.Functions Con;

		protected void Page_Load(object sender, EventArgs e)
		{
			Con = new Models.Functions();
			ShowUsers();
		}

		public override void VerifyRenderingInServerForm(Control control)
		{

		}

		private void ShowUsers()
		{
			string Query = "select * from UserTbl";
			UserGV.DataSource = Con.GetData(Query);
			UserGV.DataBind();
		}

		protected void SaveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (UserPassTb.Value == "" || UEmailTb.Value == "" || UNameTb.Value == "" || PhoneTb.Value == "" || UserAddressTb.Value == "")
				{
					ErrMsg.InnerText = "Missing Data";
				}
				else
				{
					string UName = UNameTb.Value;
					string UEmail = UEmailTb.Value;
					string Password = HashPassword(UserPassTb.Value); // Hash the password
					string Phone = PhoneTb.Value;
					string Address = UserAddressTb.Value;

					string Query = "Insert Into UserTbl (Nama, Email, Password, No_Telepon, Alamat) values('{0}', '{1}' , '{2}' , '{3}' , '{4}')";
					Query = string.Format(Query, UName, UEmail, Password, Phone, Address);
					Con.SetData(Query);
					ShowUsers();
					ErrMsg.InnerText = "User Added!!!";
				}
			}
			catch (Exception Ex)
			{
				ErrMsg.InnerText = Ex.Message;
			}
		}

		private string HashPassword(string password)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

				// Convert byte array to a string
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
		int Key;
		protected void UserGv_SelectedIndexChanged(object sender, EventArgs e)
		{
			UNameTb.Value = UserGV.SelectedRow.Cells[2].Text;
			UEmailTb.Value = UserGV.SelectedRow.Cells[3].Text;
			UserPassTb.Value = UserGV.SelectedRow.Cells[4].Text;
			PhoneTb.Value = UserGV.SelectedRow.Cells[5].Text;
			UserAddressTb.Value = UserGV.SelectedRow.Cells[6].Text;
			if (UNameTb.Value == "")
			{
				Key = 0;
			}
			else
			{
				Key = Convert.ToInt32(UserGV.SelectedRow.Cells[1].Text);
			}
		}

		protected void DeleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (UserPassTb.Value == "")
				{
					ErrMsg.InnerText = "Missing Data";
				}
				else
				{
					string Query = "delete from UserTbl where UserId = {0}";
					Query = string.Format(Query, UserGV.SelectedRow.Cells[1].Text);
					Con.SetData(Query);
					ShowUsers();
					ErrMsg.InnerText = "User Deleted!!!";
				}
			}
			catch (Exception Ex)
			{
				ErrMsg.InnerText = Ex.Message;
			}
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (UserPassTb.Value == "" || UEmailTb.Value == "" || UNameTb.Value == "" || PhoneTb.Value == "" || UserAddressTb.Value == "")
				{
					ErrMsg.InnerText = "Missing Data";
				}
				else
				{
					string UName = UNameTb.Value;
					string UEmail = UEmailTb.Value;
					// Do not hash password for editing
					string Password = UserPassTb.Value;
					string Phone = PhoneTb.Value;
					string Address = UserAddressTb.Value;

					string Query = "update UserTbl set Nama = '{0}', Email = '{1}', Password = '{2}', No_Telepon = '{3}', Alamat = '{4}' where UserId = {5}";
					Query = string.Format(Query, UName, UEmail, Password, Phone, Address, UserGV.SelectedRow.Cells[1].Text);
					Con.SetData(Query);
					ShowUsers();
					ErrMsg.InnerText = "User Updated!!!";
				}
			}
			catch (Exception Ex)
			{
				ErrMsg.InnerText = Ex.Message;
			}
		}
	}
}
