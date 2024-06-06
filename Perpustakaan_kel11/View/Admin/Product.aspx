<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Perpustakaan_kel11.View.Admin.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Tambahkan gaya CSS kustom di sini */
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }

        .container {
            padding-top: 50px;
        }

        .header {
            margin-bottom: 20px;
            text-align: center;
            display: flex; /* Menggunakan flexbox */
            align-items: center; /* Mengatur item untuk selalu berada di tengah vertikal */
        }

        .header img {
            width: 80px;
            margin-bottom: 10px;
            margin-right: 10px; /* Memberikan jarak antara img dan h4 */
        }

        .header h4 {
            color: #dc3545;
            font-weight: bold;
            margin: 0; /* Menghilangkan margin yang default */
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-label {
            font-weight: bold;
            color: #495057;
        }

        .form-control {
            border-radius: 5px;
        }

        .btn {
            border-radius: 5px;
            font-weight: bold;
        }

        #ErrMsg {
            margin-bottom: 20px;
            font-weight: bold;
        }

        .table-hover tbody tr:hover {
            background-color: #f8f9fa;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 header">
                <img src="../../Asset/Images/books-stack-of-three.png" alt="Product Icon" />
                <h4>Kelola Produk</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 class="text-danger">Detail Produk</h2>
                <div class="form-group">
                    <label for="PNameTb" class="form-label">Nama Produk</label>
                    <input type="text" class="form-control" id="PNameTb" runat="server">
                </div>

                <div class="form-group">
                    <label for="CategoryCb" class="form-label">Kategori Produk</label>
                    <asp:DropDownList ID="CategoryCb" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="PriceTb" class="form-label">Harga Produk</label>
                    <input type="text" class="form-control" id="PriceTb" runat="server">
                </div>

                <div class="form-group">
                    <label for="ProdQtyTb" class="form-label">Jumlah Produk</label>
                    <input type="text" class="form-control" id="ProdQtyTb" runat="server">
                </div>

                <div class="form-group">
                    <label for="LchDate" class="form-label">Tahun Terbit</label>
                    <input type="date" class="form-control" id="LchDate" runat="server">
                </div>

                <label id="ErrMsg" runat="server" class="text-danger"></label>
                <br />
                <asp:Button Text="Edit" CssClass="btn btn-primary btn-block" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                <asp:Button Text="Add" CssClass="btn btn-warning btn-block" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                <asp:Button Text="Delete" CssClass="btn btn-danger btn-block" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
            </div>
            <div class="col-md-8">
                <asp:GridView runat="server" CssClass="table table-hover" ID="ProductGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
