<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div id="screen"></div>
<div id="popup" class="popup halp">
    <div id="main">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-th"></i></span>
                        <h5>Đổi mật khẩu</h5>
                        <span class="btn-danger btn" style="float: right" onclick="HidePopup();">X</span>
                    </div>
                    <div class="widget-content nopadding">
                        <form method="post" name="_form" id="_form" class="form-horizontal" onsubmit="return CapNhat();">
                            <table class="table table-bordered table-invoice">
                                <tbody>
                                    <tr>
                                        <td class="tright" style="width: 30%">Tài khoản <span class="f-red">(*)</span> :
                                        </td>
                                        <td style="width: 70%">
                                            <input type="text" class="span10" disabled required id="cUser" name="cUser" value="<%=ViewData["cUser"] %>">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright">Mật khẩu cũ<span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="password" class="span10" id="cPass" onchange="CheckPass(this.value)" name="cPass">
                                            <strong id="testpass"></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright">Mật khẩu mới<span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="password" class="span10" onkeyup="ChangePass()" id="cPassNew" name="cPassNew">
                                            <span id="result"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright">Nhập lại mật khẩu<span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="password" class="span10" onchange="CheckPassNew(this.value)" id="cPassRepNew" name="cPassRepNew">
                                              <strong id="testpassnew"></strong>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="tcenter" colspan="4">
                                            <input type="hidden" value="<%=ViewData["id"] %>" name="id" id="id" />
                                            <button type="submit" class="btn btn-primary" id="btn-submit">Cập nhật</button>
                                            <a class="btn btn-danger" onclick="HidePopup();">Thoát</a>
                                        </td>

                                    </tr>
                                </tbody>
                            </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>

<script type="text/javascript">
    function CheckPass(val) {
        $.post("/user/CheckPass", "pass=" + val, function (data) {
            if (data == 1) {
                $("#testpass").html(' <span class="btn btn-primary"><i class=" icon-ok"></i></span>');
            }
            else {
                $("#testpass").html(' <span class="btn btn-danger "><i class=" icon-remove"></i></span>');
                $("#cPass").val("");
                $("#cPass").focus();
            }
        });
    }
    function ChangePass() {
        $('#result').html(checkStrength($('#cPassNew').val()));
    }
    function checkStrength(password) {
        var strength = 0;
        if (password.length < 6) {
            $('#result').removeClass()
            $('#result').addClass('btn btn-danger')
            return '<i class="icon-remove"></i>';
        }
        if (password.length > 7) strength += 1;
        if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) strength += 1;
        if (password.match(/([!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1;
        if (password.match(/(.*[!,%,&,@,#,$,^,*,?,_,~].*[!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1;
        $("#streng_pass").val(strength);
        if (strength < 2) {
            $('#result').removeClass()
            $('#result').addClass('btn btn-warning')
            return '<i class="icon-remove"></i>';
        } else if (strength == 2) {
            $('#result').removeClass()
            $('#result').addClass('btn btn-primary')
            return '<i class=" icon-ok"></i>';
        } else {
            $('#result').removeClass()
            $('#result').addClass('btn btn-success')
            return '<i class=" icon-ok"></i> ';
        }

    }
    function CheckPassNew(val) {
        if ($("#cPassRepNew").val() == $("#cPassNew").val()) {
            $("#testpassnew").html(' <span class="btn btn-primary"><i class=" icon-ok"></i></span>');
        }
        else {
            $("#testpassnew").html(' <span class="btn btn-danger "><i class=" icon-remove"></i></span>');
            $("#cPassRepNew").val("");
            $("#cPassRepNew").focus();
        }
    }
    function CapNhat() {
        $.ajax({
            type: "post",
            url: "<%=ResolveUrl("~")%>user/updatepass",
            data: $("#_form").serialize(),
            success: function (ok) {
                if (ok == 1) {
                    AlertAction("Đã đổi thành công!");
                    HidePopup();
                } else {
                    alert(ok);
                }
            }
        });
        return false;
    }
</script>

