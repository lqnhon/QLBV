<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Thông tin tài khoản
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">Thông tin tài khoản</a></div>
    <form method="post" name="_form" id="_form" class="form-horizontal" onsubmit="return CapNhat();">
        <div class="row-fluid">
            <div class="span6">

                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-ok-sign"></i></span>
                        <h5>Thông tin nhân viên</h5>
                    </div>
                    <div class="widget-content" style="height: 300px">

                        <table class="table table-bordered table-striped">

                            <tbody>
                                <tr>
                                    <td><span>Họ và tên</span></td>
                                    <td>
                                        <input id="cName" class="span12" name="cName" value="<%=ViewData["cName"] %>" /></td>
                                </tr>
                                <tr>
                                    <td><span>Số điện thoại</span></td>
                                    <td>
                                        <input id="cPhone" class="span12" name="cPhone" value="<%=ViewData["cPhone"] %>" /></td>
                                </tr>
                                <tr>
                                    <td><span>Địa chỉ</span></td>
                                    <td>
                                        <input id="cAddress" class="span12" name="cAddress" value="<%=ViewData["cAddress"] %>" /></td>
                                </tr>
                                <tr>
                                    <td><span>Tên facebook</span></td>
                                    <td>
                                        <input id="cNameFace" class="span12" name="cNameFace" value="<%=ViewData["cNameFace"] %>" /></td>
                                </tr>
                                <tr>
                                    <td><span>Link facebook</span></td>
                                    <td>
                                        <input id="cLinkFace" class="span12" name="cLinkFace" value="<%=ViewData["cLinkFace"] %>" /></td>
                                </tr>
                                <tr>
                                    <td><span>Số tài khoản</span></td>
                                    <td>
                                        <input id="cCardBank" class="span12" name="cCardBank" value="<%=ViewData["cCardBank"] %>" /></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-ok-sign"></i></span>
                        <h5>Thông tin tài khoản</h5>
                    </div>
                    <div class="widget-content" style="height: 300px">

                        <table class="table table-bordered table-striped">

                            <tbody>
                                <tr>
                                    <td><span>Tài khoản</span></td>
                                    <td>
                                        <input id="cUserName" class="span12" name="cUserName" value="<%=ViewData["cUserName"] %>" /></td>
                                </tr>
                                <tr>
                                    <td><span>Quyền</span></td>
                                    <td><%= ViewData["Quyen"] %></td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-fluid" style="margin-top: -29px; width: 100%; margin-left: -15px; padding: 0px; width: 1119px;">
            <div class="span12">
                <div class="widget-content" style="height: 300px">
                    <table class="table table-bordered table-striped">
                        <tbody>
                            <tr>
                                <td class="tright" colspan="4">
                                    <input type="hidden" value="<%=ViewData["id"] %>" id="id" name="id" />
                                    <button type="submit" class="btn btn-primary" id="btn-submit">Cập nhật</button>
                                    <a class="btn btn-danger" onclick="HidePopup();">Thoát</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

        </div>
    </form>
    <script type="text/javascript">
        function CapNhat() {
            $.ajax({
                type: "post",
                url: "<%=ResolveUrl("~")%>user/update",
                data: $("#_form").serialize(),
                success: function (ok) {
                    if (ok == 1) {
                        AlertAction("Cập nhật thành công!");
                    } else {
                        alert(ok);
                    }
                }
            });
            return false;
        }
        $('#iSupplier').select2();
        function Xem() {
            $("body").prepend('<div id="screen"><div id="loader"><div id="load1" class="spin"></div><div id="load2" class="spin"></div>' +
    '<div id="load3" class="spin"></div><div id="load4" class="spin"></div><div id="load5" class="spin"></div></div></div>');
            $.post("/employee/search", "key=" + $("#key").val(), function (data) {
                $("#list").html(data);
                $("#screen").hide().remove();
            });
        }
    </script>
</asp:Content>
