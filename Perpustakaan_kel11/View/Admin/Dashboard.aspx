<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Perpustakaan_kel11.View.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2 class="text-center text-danger mt-3">Dashboard Admin</h2>
                <hr class="bg-danger">
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-4">
                <div class="card bg-danger rounded">
                    <div class="card-body">
                        <div class="d-flex justify-content-center">
                            <img src="../../Asset/Images/rak_buku.png" style="width: 65px;" />
                        </div>
                        <h3 class="text-center text-white mt-3">Jumlah Produk</h3>
                        <h1 class="text-center text-white" runat="server" id="PNumTb">...</h1>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-warning rounded">
                    <div class="card-body">
                        <div class="d-flex justify-content-center">
                            <img src="../../Asset/Images/books-stack-of-three.png" style="width: 65px;" />
                        </div>
                        <h3 class="text-center text-white mt-3">Jumlah Kategori</h3>
                        <h1 class="text-center text-white" runat="server" id="CatNumTb">...</h1>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card bg-primary rounded">
                    <div class="card-body">
                        <div class="d-flex justify-content-center">
                            <img src="../../Asset/Images/rupiah.png" style="width: 65px;" />
                        </div>
                        <h3 class="text-center text-white mt-3">Keuangan</h3>
                        <h1 class="text-center text-white" runat="server" id="FinanceTb">...</h1>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-4 offset-md-4">
                <div class="card bg-danger rounded">
                    <div class="card-body">
                        <div class="d-flex justify-content-center">
                            <img src="../../Asset/Images/user.png" style="width: 65px;" />
                        </div>
                        <h3 class="text-center text-white mt-3">Jumlah User</h3>
                        <h1 class="text-center text-white" runat="server" id="UserNumTb">...</h1>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-12 d-flex justify-content-center">
                <img src="../../Asset/Images/perpustakaan.jpg" style="height: 450px;" />
            </div>
        </div>
    </div>
</asp:Content>

