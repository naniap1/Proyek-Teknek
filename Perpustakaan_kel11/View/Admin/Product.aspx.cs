using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perpustakaan_kel11.View.Admin
{
	public partial class Product : System.Web.UI.Page
	{
		Models.Functions Con;
		protected void Page_Load(object sender, EventArgs e)
		{
			Con = new Models.Functions();
			if (!IsPostBack)
			{
				GetCategories(); // Memanggil metode GetCategories() hanya saat halaman tidak dipost kembali
				ShowProducts();
			}
		}

		public override void VerifyRenderingInServerForm(Control control)
		{

		}
		private void ShowProducts()
		{
			string Query = "select * from ProductTbl";
			ProductGV.DataSource = Con.GetData(Query);
			ProductGV.DataBind();
		}

		private void GetCategories()
		{
			String Query = "Select * from CategoryTbl";
			DataTable categoriesData = Con.GetData(Query);
			CategoryCb.DataTextField = "CatName"; // Gunakan nama kolom dari tabel CategoryTbl untuk nama kategori
			CategoryCb.DataValueField = "CatId";   // Gunakan nama kolom dari tabel CategoryTbl untuk ID kategori
			CategoryCb.DataSource = categoriesData;
			CategoryCb.DataBind();
		}



		protected void SaveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PNameTb.Value == "" || CategoryCb.DataTextField == "" || PriceTb.Value == "" || ProdQtyTb.Value == "")
				{
					ErrMsg.InnerText = "Missing Data";
				}
				else
				{
					string PName = PNameTb.Value;
					string PrCat = CategoryCb.SelectedValue;
					string Price = PriceTb.Value;
					string Qty = ProdQtyTb.Value;
					string LDate = LchDate.Value;

					string Query = "Insert Into ProductTbl values('{0}', '{1}' , {2} , {3} , '{4}')";
					Query = string.Format(Query, PName, PrCat, Price, Qty, LDate);
					Con.SetData(Query);
					ShowProducts();
					ErrMsg.InnerText = "Product Added!!!";
				}
			}
			catch (Exception Ex)
			{
				ErrMsg.InnerText = Ex.Message;
			}
		}

		protected void DeleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PNameTb.Value == "")
				{
					ErrMsg.InnerText = "Missing Data";
				}
				else
				{


					string Query = "delete from ProductTbl  where Id = {0}";
					Query = string.Format(Query, ProductGV.SelectedRow.Cells[1].Text);
					Con.SetData(Query);
					ShowProducts();
					ErrMsg.InnerText = "Product Deleted!!!";
				}
			}
			catch (Exception Ex)
			{
				ErrMsg.InnerText = Ex.Message;
			}
		}

		int Key = 0;
		protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
		{
			PNameTb.Value = ProductGV.SelectedRow.Cells[2].Text;
			CategoryCb.SelectedValue = ProductGV.SelectedRow.Cells[3].Text;
			PriceTb.Value = ProductGV.SelectedRow.Cells[4].Text;
			ProdQtyTb.Value = ProductGV.SelectedRow.Cells[5].Text;
			LchDate.Value = ProductGV.SelectedRow.Cells[6].Text;
			if (PNameTb.Value == "")
			{
				Key = 0;
			}
			else
			{
				Key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
			}
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PNameTb.Value == "" || CategoryCb.DataTextField == "" || PriceTb.Value == "" || ProdQtyTb.Value == "")
				{
					ErrMsg.InnerText = "Missing Data";
				}
				else
				{
					string PName = PNameTb.Value;
					string PrCat = CategoryCb.SelectedValue;
					string Price = PriceTb.Value;
					string Qty = ProdQtyTb.Value;
					string LDate = LchDate.Value;

					string Query = "update ProductTbl set Nama = '{0}', Kategori ={1}  ,Harga = {2} , Jumlah =  {3} , Tahun_Terbit = '{4}' where Id = {5}";
					Query = string.Format(Query, PName, PrCat, Price, Qty, LDate, ProductGV.SelectedRow.Cells[1].Text);
					Con.SetData(Query);
					ShowProducts();
					ErrMsg.InnerText = "Product Updated!!!";
				}
			}
			catch (Exception Ex)
			{
				ErrMsg.InnerText = Ex.Message;
			}
		}
	}
}