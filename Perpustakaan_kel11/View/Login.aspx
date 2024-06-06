<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Perpustakaan_kel11.View.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Asset/Lib/Bootstrap/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }

        .container-box {
            margin-top: 50px;
            background-color: #fff;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            padding: 20px;
            max-width: 600px;
            margin: 0 auto;
        }

        .card-img {
            max-width: 100%;
            height: auto;
            border-radius: 10px;
            margin-top: 10px;
        }

        h1 {
            padding-top:10px;
            color: #dc3545;
            font-weight: bold;
            text-align: center;
        }

        h3 {
            color: #dc3545;
            font-weight: bold;
            text-align: center;
        }

        .form-label {
            font-weight: bold;
            color: #495057;
        }

        .form-control {
            border-radius: 5px;
        }

        .btn-danger {
            background-color: #dc3545;
            border: none;
            border-radius: 5px;
            font-weight: bold;
        }

            .btn-danger:hover {
                background-color: #c82333;
            }

        .text-danger {
            color: #dc3545;
        }

        /* CSS untuk radio button di tengah */
        .form-group.text-center {
            text-align: center;
        }

            .form-group.text-center .form-check {
                display: inline-block;
            }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Menggunakan flexbox untuk card -->
        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
            <div class="container-box">
                <!-- Judul Perpustakaan -->
                <div class="row">
                    <div class="col-md-12">
                        <h3>Perpustakaan Kelompok 11</h3>
                    </div>
                </div>
                <!-- Header -->
                <div class="row">
                    <div class="col-md-12">
                        <img src="../Asset/Images/buku_perpustakaan.jpeg" class="card-img d-block mx-auto" />
                    </div>
                </div>
                <!-- Form Login -->
                <div class="row">
                    <div class="col-md-12">
                        <h1>Login</h1>
                        <div class="mb-3">
                            <label for="EmailId" class="form-label">Email address</label>
                            <asp:TextBox ID="EmailId" runat="server" CssClass="form-control" TextMode="Email" Required="true" />
                        </div>
                        <div class="mb-3">
                            <label for="UserPasswordTb" class="form-label">Password</label>
                            <asp:TextBox ID="UserPasswordTb" runat="server" CssClass="form-control" TextMode="Password" Required="true" />
                        </div>
                        <!-- Radio Button Role -->
                        <div class="mb-3 form-group text-center">
                            <!-- Menambahkan kelas text-center -->
                            <asp:RadioButton ID="UserRadio" runat="server" GroupName="Role" Text="User" CssClass="form-check" />
                            <!-- Menambahkan kelas form-check -->
                            <asp:RadioButton ID="AdminRadio" runat="server" GroupName="Role" Text="Admin" Checked="true" CssClass="form-check" />
                            <!-- Menambahkan kelas form-check -->
                        </div>
                        <!-- Tombol Login -->
                        <div class="mb-3 d-grid">
                            <asp:Label ID="InfoMsg" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:Button Text="Login" class="btn btn-danger btn-block" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
