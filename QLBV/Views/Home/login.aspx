<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta charset="utf-8">
    <title>:.. Đăng nhập hệ thống ..:</title>
    <!-- Stylesheets -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Droid+Sans:400,700">
    <!-- Optimize for mobile devices -->
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <link href="<%=ResolveUrl("~") %>login-admin/style-admin.css" rel="stylesheet" />

   
    <script src="<%=ResolveUrl("~") %>login/Scripts/jquery.min.js"></script>
    <script src="<%=ResolveUrl("~") %>login/Scripts/functions.js"></script>
	<!-- Bootstrap -->
	<script src="<%=ResolveUrl("~") %>login/Scripts/bootstrap.min.js"></script>
	<script src="<%=ResolveUrl("~") %>login/Scripts/eakroko.js"></script>
	<!-- Favicon -->
</head>
<body>
    <div id="header">
        <div class="page-full-width cf">
            <div class="fl" id="login-intro">
                <h1>Đăng nhập vào Hệ Thống</h1>
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
        <form id="login-form" method="post" class="nomagin" name="form" onsubmit="return CheckForm()">

            <p>
                <span class="login-password">Tài khoản</span>
                <input type="text" autofocus class="round full-width-input" id="cUser" name="cUser">
            </p>

            <p>
                <span class="login-password">Mật khẩu</span>
                <input type="password" class="round full-width-input" id="cPass" name="cPass">
            </p>

            <div style="text-align: right">

                <p><a href="#">Quên mật khẩu</a> || <a href="<%=ResolveUrl("~") %>home/register" style="text-align: center">Đăng ký</a></p>
                <input type="submit" class="button round blue ic-right-arrow" style="" value="Đăng nhập">
            </div>
            <br />
            <div class="information-box round" id="caution">Click nút "LOGIN" để tiếp tục, Xin vui lòng kiểm tra caps lock trước khi điền thông tin.</div>

        </form>

    </div>
    <div id="footer">

        <p>&copy; Copyright 2017 <a href="#">Nhật Team</a>. All rights reserved.</p>

    </div>

</body>
<script type="text/javascript">

    function CheckForm() {
        if ($("#cUser").val() == "") { alert("Vui lòng điền tên đăng nhập!"); $("#cUser").focus(); return false; }
        if ($("#cPass").val() == "") { alert("Vui lòng điền mật khẩu!"); $("#cPass").focus(); return false; }
        $.ajax({
            type: "post",
            url: "<%=ResolveUrl("~")%>Home/CheckLogin",
             data: $("form").serialize(),
             success: function (ok) {
                 if (ok == 1) {
                     $("#caution").html("Đăng nhập thành công, hệ thống sẽ tự chuyển");
                     location.href = "<%=ResolveUrl("~")%>home/index";
                 }  
                 else
                 {
                     alert(ok);
                 }
             }
        });
            return false;
        }
</script>
</html>
