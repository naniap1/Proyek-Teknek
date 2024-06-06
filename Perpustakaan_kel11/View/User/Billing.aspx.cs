using Perpustakaan_kel11.View.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perpustakaan_kel11.View.User
{
	public partial class Billing : System.Web.UI.Page
	{
		Models.Functions Con;
		DataTable dt = new DataTable();
		int UserID = Login.UKey;
		protected void Page_Load(object sender, EventArgs e)
		{
			Con = new Models.Functions();
			ShowProducts();

			if (!this.IsPostBack)
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[5]{
					new DataColumn("ID"),
					new DataColumn("Produk"),
					new DataColumn("Harga"),
					new DataColumn("Jumlah"),
					new DataColumn("Total")
				});

				ViewState["Bill"] = dt;
				this.BindGrid();
			}
		}

		protected void BindGrid()
		{
			BillGV.DataSource = (DataTable)ViewState["Bill"];
			BillGV.DataBind();
		}

		public static int Amount;
		public override void VerifyRenderingInServerForm(Control control)
		{

		}

		int Key = 0;
		int Stock;

		private void ShowProducts()
		{
			string Query = "select Id as Id, Nama as Nama, Kategori as Kategori, Harga as Harga, Jumlah as Jumlah from ProductTbl";
			ProductGV.DataSource = Con.GetData(Query);
			ProductGV.DataBind();
		}

		int n = 0;
		protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
		{
			PNameTb.Value = ProductGV.SelectedRow.Cells[2].Text;
			//CategoryCb.SelectedValue = ProductGV.SelectedRow.Cells[3].Text;
			PrPriceTb.Value = ProductGV.SelectedRow.Cells[4].Text;
			Stock = Convert.ToInt32(ProductGV.SelectedRow.Cells[5].Text);

			if (PNameTb.Value == "")
			{
				Key = 0;
			}
			else
			{
				Key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
			}
		}

		private void UpdateStock()
		{

			int newQty;
			newQty = Convert.ToInt32(ProductGV.SelectedRow.Cells[5].Text) - Convert.ToInt32(PrQtyTb.Value);
			string Query = "update ProductTbl set Jumlah = '{0}'  where Id = {1}";
			Query = string.Format(Query, newQty, ProductGV.SelectedRow.Cells[1].Text);
			Con.SetData(Query);
			ShowProducts();
			ErrMsg.InnerText = "Quantity Updated!!!";
		}


		int GrdTotal = 0;
		protected void AddToBillBtn_Click(object sender, EventArgs e)
		{
			int total = Convert.ToInt32(PrQtyTb.Value) * Convert.ToInt32(PrPriceTb.Value);
			DataTable dt = (DataTable)ViewState["Bill"];
			dt.Rows.Add(BillGV.Rows.Count + 1,
				PNameTb.Value.Trim(),
				PrPriceTb.Value.Trim(),
				PrQtyTb.Value.Trim(),
				total
				);

			ViewState["Bill"] = dt;
			this.BindGrid();
			UpdateStock();

			// Akumulasi total pesanan dari semua item yang ditambahkan ke tagihan
			GrdTotal += total;

			GrdTotTb.InnerText = "Rp. " + GrdTotal;
			PNameTb.Value = string.Empty;
			PrPriceTb.Value = string.Empty;
			PrQtyTb.Value = string.Empty;

			// Setelah item ditambahkan ke bill, panggil fungsi untuk mengatur tampilan awal
			SetInitialView();
		}


		private void SetInitialView()
		{
			// Sembunyikan inputan produk dan tombol "Tambahkan ke Bill"
			ProductGV.Visible = false;
			PNameTb.Visible = false;
			PrPriceTb.Visible = false;
			PrQtyTb.Visible = false;
			AddToBillBtn.Visible = false;

			// Tampilkan tombol "Cetak Tagihan"
			PrintBtn.Visible = true;
		}

		protected void PrintBtn_Click(object sender, EventArgs e)
		{
			// Extract necessary data
			DataTable billData = (DataTable)ViewState["Bill"];
			string total = GrdTotTb.InnerText;

			// Store data in session to pass to Terimakasih.aspx
			Session["BillData"] = billData;
			Session["Total"] = total;

			// Redirect to Terimakasih.aspx
			Response.Redirect("Tagihan.aspx");
		}

		protected void ResetBtn_Click(object sender, EventArgs e)
		{
			// Clear input fields
			PNameTb.Value = string.Empty;
			PrPriceTb.Value = string.Empty;
			PrQtyTb.Value = string.Empty;

			// Reset total
			GrdTotal = 0;
			GrdTotTb.InnerText = "Rp. " + GrdTotal;

			// Show input fields and "Add to Bill" button
			ShowForm();
		}


		private void ShowForm()
		{
			// Tampilkan inputan produk dan tombol "Tambahkan ke Bill"
			ProductGV.Visible = true;
			PNameTb.Visible = true;
			PrPriceTb.Visible = true;
			PrQtyTb.Visible = true;
			AddToBillBtn.Visible = true;

			// Sembunyikan tombol "Cetak Tagihan"
			PrintBtn.Visible = false;
		}

	}
}