using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace Perpustakaan_kel11.View.User
{
	public partial class Terimakasih : System.Web.UI.Page
	{
		Models.Functions Con;
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


		protected void PrintBtn_Click(object sender, EventArgs e)
		{
			// Validate Total value
			if (string.IsNullOrEmpty(Total.InnerText))
			{
				// Handle empty or null Total value
				Response.Write("Invalid total amount. Total value is empty or null.");
				return;
			}

			// Remove non-numeric characters from Total value
			string totalCleaned = new string(Total.InnerText.Where(char.IsDigit).ToArray());

			// Validate cleaned Total value
			int jumlah;
			if (!int.TryParse(totalCleaned, out jumlah))
			{
				// Handle invalid input (not a valid integer)
				Response.Write("Invalid total amount. Total value: " + Total.InnerText);
				return;
			}

			// Check if Session["UserID"] is not null and is valid
			int userId;
			if (Session["UserID"] != null && int.TryParse(Session["UserID"].ToString(), out userId))
			{
				// Insert data into BillTbl
				using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\napit\\OneDrive\\Documents\\Perpustakaan_kel11.mdf;Integrated Security=True;Connect Timeout=30"))
				{
					string query = "INSERT INTO BillTbl (Tanggal_Tagihan, UserID, Jumlah) VALUES (@Tanggal_Tagihan, @UserID, @Jumlah)";
					SqlCommand command = new SqlCommand(query, connection);

					// Assuming you want to use the current date as the billing date
					DateTime tanggalTagihan = DateTime.Now.Date;

					command.Parameters.AddWithValue("@Tanggal_Tagihan", tanggalTagihan);
					command.Parameters.AddWithValue("@UserID", userId);
					command.Parameters.AddWithValue("@Jumlah", jumlah);

					try
					{
						connection.Open();
						command.ExecuteNonQuery();
						// Redirect to another page after successful insertion
						Response.Redirect("Terimakasih.aspx");
					}
					catch (Exception ex)
					{
						// Handle exceptions
						Response.Write("Error: " + ex.Message);
					}
				}
			}
			else
			{
				// Handle invalid or null UserID
				Response.Write("Invalid or null UserID.");
				return;
			}
		}

		protected void CnclBtn_Click(object sender, EventArgs e)
		{
			// Reset session data to null
			Session["BillData"] = null;

			// Get the previous total from session and convert it to string
			string previousTotalString = Session["Total"] as string;

			// Validate if previousTotalString is not null or empty
			if (!string.IsNullOrEmpty(previousTotalString))
			{
				// Convert the previousTotalString to integer
				int previousTotal;
				if (int.TryParse(previousTotalString, out previousTotal))
				{
					// Update the total with the previous total
					Total.InnerText = previousTotal.ToString();

					// Restore product quantities
					RestoreProductQuantities();
				}
				else
				{
					// Handle invalid format
					Total.InnerText = "0"; // Or any default value
				}
			}
			else
			{
				// Handle null or empty previousTotalString
				Total.InnerText = "0"; // Or any default value
			}

			// Redirect back to Billing.aspx
			Response.Redirect("Billing.aspx");
		}

		private void RestoreProductQuantities()
		{
			// Retrieve data from session
			DataTable billData = (DataTable)Session["BillData"];

			// Connect to the database and update product quantities
			using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\napit\\OneDrive\\Documents\\Perpustakaan_kel11.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"))
			{
				connection.Open();

				foreach (DataRow row in billData.Rows)
				{
					int productId = Convert.ToInt32(row["ID"]);
					int quantity = Convert.ToInt32(row["Jumlah"]);

					// Retrieve original quantity from session or database
					// You may need to modify this based on how you store original quantities

					// Restore product quantity
					string updateQuery = "UPDATE ProductTbl SET Jumlah = Jumlah + @Quantity WHERE Id = @ProductId";
					SqlCommand command = new SqlCommand(updateQuery, connection);
					command.Parameters.AddWithValue("@Quantity", quantity);
					command.Parameters.AddWithValue("@ProductId", productId);
					command.ExecuteNonQuery();
				}
			}
		}

	}
}
