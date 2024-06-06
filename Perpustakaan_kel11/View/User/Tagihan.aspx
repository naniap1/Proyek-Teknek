<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tagihan.aspx.cs" MasterPageFile="~/View/User/UserMaster.Master" Inherits="Perpustakaan_kel11.View.User.Terimakasih" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <style>
        .container {
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 15px;
            margin: 20px auto;
            background-color: #f8f9fa;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 600px;
        }

        .btn-danger {
            background-color: #dc3545;
            border-color: #dc3545;
            margin-left:130px;
        }

        .btn-warning {
            background-color: #ffc107; /* Warna tombol Cancel */
            border-color: #ffc107; /* Warna border tombol Cancel */
            float: left; /* Memindahkan tombol ke kiri */
            margin-left:60px;
        }

        .btn-danger:hover {
            background-color: #c82333;
            border-color: #bd2130;
        }

        /* Gaya untuk label */
        .form-label {
            color: #6c757d; /* Warna teks label */
            font-weight: bold; /* Tebal teks label */
        }
    </style>
    <div class="container">
        <h1 class="text-center">Struk Pembayaran</h1>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-5 offset-md-3">
                    <div class="row">
                        <div class="col">
                            <br />
                            <div class="mb-3">
                                <label for="NamaProduk" class="form-label">Produk : </label>
                                <span id="NamaProduk" runat="server"></span>
                            </div>

                            <div class="mb-3">
                                <label for="HargaProduk" class="form-label">Harga : </label>
                                <span id="HargaProduk" runat="server"></span>
                            </div>

                            <div class="mb-3">
                                <label for="JumlahProduk" class="form-label">Jumlah : </label>
                                <span id="JumlahProduk" runat="server"></span>
                            </div>

                            <div class="mb-3">
                                <label for="Total" class="form-label">Total :</label>
                                <span id="Total" runat="server"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col">
                    <asp:Button Text="Batal" class="btn btn-warning btn-block" runat="server" ID="CnclBtn" OnClick="CnclBtn_Click"  />
                </div>
                <div class="col">
                    <asp:Button Text="Bayar" class="btn btn-danger btn-block" runat="server" ID="PrintBtn" OnClick="PrintBtn_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
