<%@ Page Title="" Language="C#" MasterPageFile="~/View/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="Perpustakaan_kel11.View.User.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintPanel() {
            var PGrid = document.getElementById('<%=BillGV.ClientID%>');

            PGrid.border = 0;
            var Pwin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar=0, scrolbars=1, status=0, resizeable =1 ');
            Pwin.document.write(PGrid.outerHTML);
            Pwin.document.close();
            Pwin.focus();
            Pwin.print();
            Pwin.close();
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 ">
                <div class="row">
                    <div class="col">
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Nama Produk</label>
                            <input type="text" class="form-control" id="PNameTb" runat="server" required="required">
                        </div>

                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Harga Produk</label>
                            <input type="text" class="form-control" id="PrPriceTb" runat="server" required="required">
                        </div>

                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Jumlah Produk</label>
                            <input type="text" class="form-control" id="PrQtyTb" runat="server" required="required">
                        </div>
                    </div>

                    <div class="col">

                        <img src="../../Asset/Images/rupiah.png" style="width: 100px;" /><br /><br /><br /><br />

                        <label id="ErrMsg" runat="server" class="text-danger"></label>
                        <br />
                        <asp:Button Text="Masukkan Ke Tagihan" class="btn btn-warning" runat="server" ID="AddToBillBtn" OnClick="AddToBillBtn_Click" />
                        <asp:Button Text="Tambah Pesanan" class="btn btn-danger" runat="server" ID="ResetBtn" OnClick="ResetBtn_Click" />
                    </div>

                </div>

                <div class="row">
                    <div class="col">
                        <asp:GridView runat="server" class="table table-hover" ID="ProductGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged">
                        </asp:GridView>
                    </div>
                </div>
            </div>


            <div class="col-md-7">
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col">
                        <h1 class="text-warning pl-2">Client Billing</h1>
                    </div>
                </div>

                <div class="'row">
                    <asp:GridView ID="BillGV" class="table" runat="server">

                    </asp:GridView>
                </div>
                <div class="row">
                    <div class="col"></div>
                    <div class="col"><h3 id="GrdTotTb" class="text-danger" runat="server"></h3></div>
                    <div class="col d-grid"><asp:Button Text="Bayar" class="btn btn-danger btn-block" runat="server" ID="PrintBtn" OnClick="PrintBtn_Click" /></div>
                </div>

            </div>
        </div>
    </div>
    </asp:Content>


