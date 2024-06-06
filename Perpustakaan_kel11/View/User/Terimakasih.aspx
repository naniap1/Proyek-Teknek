<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Terimakasih.aspx.cs" Inherits="Perpustakaan_kel11.View.User.Terimakasih1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Terima Kasih</title>
    <style>
        /* CSS untuk tampilan lebih menarik */
        body {
            font-family: Arial, sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-top: 5px solid #4CAF50; /* Warna hijau cerah untuk border atas */
        }

        h1 {
            text-align: center;
            color: #333;
        }

        h3 {
            color: #666;
        }

        p {
            margin-bottom: 10px;
        }

        .box {
            border: 1px solid #ddd;
            padding: 15px;
            border-radius: 6px;
            margin-top: 20px;
            background-color: #f9f9f9; /* Warna latar belakang box */
        }

        /* CSS untuk tombol */
/* CSS untuk tombol */
.btn {
    margin-top:10px;
    display: inline-block;
    font-weight: 400;
    color: #212529;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: .25rem;
    transition: color .15s ease-in-out, background-color .15s ease-in-out, border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}

/* CSS untuk tombol Kembali */
.btn-warning {
    color: #212529;
    background-color: #ffc107;
    border-color: #ffc107;
    width: 100%; /* Mengatur lebar tombol menjadi 100% */
    margin-bottom: 10px; /* Menambahkan margin bawah untuk jarak */
}

.btn-warning:hover {
    color: #212529;
    background-color: #e0a800;
    border-color: #d39e00;
}

/* CSS untuk tombol Bayar */
.btn-danger {
    color: #fff;
    background-color: #dc3545;
    border-color: #dc3545;
    width: 100%; /* Mengatur lebar tombol menjadi 100% */
}

.btn-danger:hover {
    color: #fff;
    background-color: #c82333;
    border-color: #bd2130;
}

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Terima Kasih!</h1>
            <div class="box">
                <h3>Terima kasih, <span id="lblNamaUser" runat="server"></span>, telah melakukan pembelian:</h3>
                <p><strong>Produk:</strong> <span id="NamaProduk" runat="server"></span></p>
                <p><strong>Harga:</strong> <span id="HargaProduk" runat="server"></span></p>
                <p><strong>Jumlah:</strong> <span id="JumlahProduk" runat="server"></span></p>
                <p><strong>Total:</strong> Rp. <span id="Total" runat="server"></span></p>
            </div>
            <div class="row mt-3">
    <div class="col">
        <asp:Button Text="Kembali" class="btn btn-warning btn-block" runat="server" ID="CnclBtn" OnClick="CnclBtn_Click" />
    </div>
    <div class="col">
        <asp:Button Text="Print" class="btn btn-danger btn-block" runat="server" ID="PrintBtn" OnClick="PrintBtn_Click" />
    </div>
</div>

        </div>
    </form>
</body>
</html>
