<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta charset="utf-8">
    <title>:.. Đăng ký tài khoản..:</title>
    <!-- Stylesheets -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Droid+Sans:400,700">
    <!-- Optimize for mobile devices -->
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <link href="<%=ResolveUrl("~") %>login-admin/style-admin.css" rel="stylesheet" />
</head>
<body>
    <div id="header">
        <div class="page-full-width cf">
            <div class="fl" id="login-intro">
                <h1>Đăng ký tài khoản</h1>
                <h5>Để sử dụng phần mềm</h5>
            </div>
            <!-- login-intro -->
            <!-- Change this image to your own company's logo -->
            <!-- The logo will automatically be resized to 39px height. -->
            <a class="fr" id="company-branding" href="#">
                <%-- <img alt="Techlife Company" src="images/logo.png" alt=""></a>--%>
        </div>
        <!-- end full-width -->
    </div>
    <div id="content">
        <form id="login-form" method="POST">

            <p>
                <label for="login-username">Tài khoản</label>
                <input type="text" class="round full-width-input" id="register-username">
            </p>

            <p>
                <label for="login-password">Mật khẩu</label>
                <input type="password" class="round full-width-input" id="register-password">
            </p>
            <p>
                <label for="login-password">Nhập lại mật khẩu</label>
                <input type="password" class="round full-width-input" id="register-passwordretype">
            </p>
            <p>
                <label for="login-password">Mã giới thiệu</label>
                <input type="password" class="round full-width-input" id="register-code">
            </p>
            <div style="text-align: right">
                <a class="button round blue " href="<%=ResolveUrl("~") %>home/register" style="text-align: center">Đăng ký</a>
            </div>


        </form>

    </div>
    <div id="footer">

        <p>&copy; Copyright 2017 <a href="#">Nhật Team</a>. All rights reserved.</p>

    </div>

</body>
</html>
