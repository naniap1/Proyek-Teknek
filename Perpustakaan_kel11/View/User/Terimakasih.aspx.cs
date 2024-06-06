using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Perpustakaan_kel11.View.User
{
	public partial class Terimakasih1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Retrieve data passed from Billing.aspx
				var billData = (DataTable)Session["BillData"];
				// Calculate total from all items in the bill
				var total = CalculateTotal(billData);

				// Bind data to the respective fields
				NamaProduk.InnerText = GetProductNames(billData);
				HargaProduk.InnerText = GetProductPrices(billData);
				JumlahProduk.InnerText = GetProductQuantities(billData);

				Total.InnerText = total.ToString(); // Display the calculated total

				// Tampilkan nama pengguna di halaman terima kasih
				string username = GetLoggedInUserName();
				lblNamaUser.InnerText = username; // Update lblNamaUser with the username
			}
		}

		private int CalculateTotal(DataTable billData)
		{
			int total = 0;
			foreach (DataRow row in billData.Rows)
			{
				total += Convert.ToInt32(row["Total"]);
			}
			return total;
		}

		private string GetProductNames(DataTable billData)
		{
			return string.Join(", ", billData.AsEnumerable().Select(row => row.Field<string>("Produk")).ToArray());
		}

		// Method to get concatenated product prices
		private string GetProductPrices(DataTable billData)
		{
			return string.Join(", ", billData.AsEnumerable().Select(row => row.Field<string>("Harga")).ToArray());
		}

		// Method to get concatenated product quantities
		private string GetProductQuantities(DataTable billData)
		{
			return string.Join(", ", billData.AsEnumerable().Select(row => row.Field<string>("Jumlah")).ToArray());
		}

		// Method to get the name of the logged-in user

		private string GetLoggedInUserName()
		{
			string username = string.Empty;
			if (Session["UserID"] != null && int.TryParse(Session["UserID"].ToString(), out int userID))
			{
				string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\napit\\OneDrive\\Documents\\Perpustakaan_kel11.mdf;Integrated Security=True;Connect Timeout=30;";
				string query = "SELECT Nama FROM UserTbl WHERE UserId = @UserID";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@UserID", userID);
						connection.Open();
						object result = command.ExecuteScalar();
						if (result != null)
						{
							username = result.ToString();
						}
					}
				}
			}
			return username;
		}


		// Method to get the UserID associated with the bill from the session
		private int GetBillUserID()
		{
			int userID = 0;
			if (Session["BillUserID"] != null)
			{
				userID = Convert.ToInt32(Session["BillUserID"]);
			}
			return userID;
		}

		protected void CnclBtn_Click(object sender, EventArgs e)
		{
			// Redirect to Billing.aspx when Cancel button is clicked
			Response.Redirect("Billing.aspx");
		}

		protected void PrintBtn_Click(object sender, EventArgs e)
		{
			// Ambil nama pengguna dari metode GetLoggedInUserName()
			string username = GetLoggedInUserName();

			// Ambil nilai dari elemen HTML pada halaman Terimakasih
			string namaProduk = NamaProduk.InnerText;
			string hargaProduk = HargaProduk.InnerText;
			string jumlahProduk = JumlahProduk.InnerText;
			string total = Total.InnerText;

			// Buat sebuah dokumen PDF
			var document = new iTextSharp.text.Document();
			var memoryStream = new System.IO.MemoryStream();
			var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);

			// Buka dokumen
			document.Open();

			// Tambahkan konten ke dokumen
			// Membuat tabel untuk menyimpan informasi pesanan
			PdfPTable table = new PdfPTable(2); // 2 kolom untuk judul dan nilai

			// Set properti untuk tabel
			table.WidthPercentage = 100; // Menentukan lebar tabel dalam persentase

			// Menambahkan sel-sel ke tabel untuk setiap informasi pesanan
			table.AddCell(new PdfPCell(new Phrase("Informasi Pesanan", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD))));
			table.AddCell(new PdfPCell(new Phrase(""))); // Sel kosong sebagai pembatas

			table.AddCell(new PdfPCell(new Phrase("Nama Produk")));
			table.AddCell(new PdfPCell(new Phrase(namaProduk)));

			table.AddCell(new PdfPCell(new Phrase("Harga")));
			table.AddCell(new PdfPCell(new Phrase("Rp." + hargaProduk)));

			table.AddCell(new PdfPCell(new Phrase("Jumlah")));
			table.AddCell(new PdfPCell(new Phrase(jumlahProduk)));

			table.AddCell(new PdfPCell(new Phrase("Total")));
			table.AddCell(new PdfPCell(new Phrase("Rp. " + total)));

			// Tambahkan informasi tanggal dan jam pesanan
			DateTime waktuSekarang = DateTime.Now;
			table.AddCell(new PdfPCell(new Phrase("Tanggal dan Jam Pesanan")));
			table.AddCell(new PdfPCell(new Phrase(waktuSekarang.ToString())));

			// Tambahkan tabel ke dokumen
			document.Add(table);



			// Tutup dokumen
			document.Close();

			// Bersihkan konten respons dan atur tipe konten serta header untuk PDF
			Response.Clear();
			Response.ContentType = "application/pdf";
			Response.AddHeader("content-disposition", "attachment;filename=Terimakasih.pdf");

			// Tulis konten PDF ke aliran keluaran respons
			Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
			Response.OutputStream.Flush();
			Response.End();
		}

	}
}
