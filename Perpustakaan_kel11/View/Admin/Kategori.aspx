<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="Perpustakaan_kel11.View.Admin.Kategori" %>

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
            display: flex;
            align-items: flex-start; /* Mengatur agar elemen berada di sudut kiri */
            justify-content: center;
        }

        .header img {
            width: 80px;
            margin-right: 10px;
        }

        .header h4 {
            color: #dc3545;
            font-weight: bold;
            margin: 0; /* Menghapus margin agar tidak ada spasi di atas dan bawah */
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
                <img src="../../Asset/Images/books-stack-of-three.png" alt="Category Icon" />
                <h4>Kelola Kategori</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 class="text-danger">Detail Kategori</h2>
                <div class="form-group">
                    <label for="CatNameTb" class="form-label">Nama Kategori</label>
                    <input type="text" class="form-control" id="CatNameTb" runat="server">
                </div>

                <div class="form-group">
                    <label for="CatRemarkTb" class="form-label">Komentar Kategori</label>
                    <input type="text" class="form-control" id="CatRemarkTb" runat="server">
                </div>
               
                <br /><br />
                <label id="ErrMsg" runat="server" class="text-danger"></label><br />
                <asp:Button Text="Edit" CssClass="btn btn-primary btn-block" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                <asp:Button Text="Add" CssClass="btn btn-warning btn-block" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                <asp:Button Text="Delete" CssClass="btn btn-danger btn-block" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
            </div>
            <div class="col-md-8">
                <asp:GridView runat="server" CssClass="table table-hover" ID="CategoryGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoryGV_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
