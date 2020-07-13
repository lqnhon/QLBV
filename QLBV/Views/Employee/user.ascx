<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="screen"></div>
<div id="popup" class="popup halp">
    <div id="main">
        <div class="row-fluid">
            <div class="span12">

                <div class="widget-box" style="margin-top: 0px; margin-bottom: 0px;">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-th"></i></span>
                        <h5>Thông tin tài khoản nhân viên</h5>
                        <span class="btn-danger btn" style="float: right" onclick="HidePopup();">X</span>
                    </div>
                   
                    <div class="widget-content nopadding">
                        
                        <form method="post" name="_form" id="_form" class="form-horizontal" onsubmit="return CapNhat();">
                            <span class="tcenter" style="margin-left:69px; color:red"><%=ViewData["cWarning"] %></span>
                            <hr style="margin:0px" />
                            <table class="table table-bordered table-invoice">
                                 
                                <tbody>
                                    <tr>
                                        <td class="tright" style="width: 30%">Tài khoản <span class="f-red">(*)</span> :
                                        </td>
                                        <td style="width: 70%" colspan="3">
                                            <input type="text" class="span6" required id="cUserName" value="<%=ViewData["cUserName"] %>" name="cUserName">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright" style="width: 20%">Mật khẩu <span class="f-red">(*)</span> :
                                        </td>
                                        <td style="width: 80%" colspan="3">
                                            <input type="password" class="span6"  id="cPassWord" value="<%=ViewData["cPassWord"] %>" name="cPassWord">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright" style="width: 20%">Quyền <span class="f-red">(*)</span> :
                                        </td>
                                        <td style="width: 80%" colspan="3">
                                           <%=ViewData["quyen"] %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tcenter" colspan="4">
                                            <input type="hidden" id="id" name="id" value="<%=ViewData["id"] %>" />
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
    function CapNhat() {
        $.ajax({
            type: "post",
            url: "<%=ResolveUrl("~")%>employee/updateuser",
            data: $("#_form").serialize(),
            success: function (ok) {
                if (ok == 1) {
                    AlertAction("Đã thêm thành công!");
                    window.location.replace("/employee/list");
                } else {
                    alert(ok);
                }
            }
        });
        return false;
    }
</script>
