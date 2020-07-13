<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="screen"></div>
<div id="popup" class="popup halp">
    <div id="main">
        <div class="row-fluid">
            <div class="span12">

                <div class="widget-box" style="margin-top: 0px; margin-bottom: 0px;">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-th"></i></span>
                        <h5>Thêm mới nhân viên</h5>
                        <span class="btn-danger btn" style="float: right" onclick="HidePopup();">X</span>
                    </div>
                    <div class="widget-content nopadding">
                        <form method="post" name="_form" id="_form" class="form-horizontal" onsubmit="return CapNhat();">
                            <table class="table table-bordered table-invoice">
                                <tbody>
                                    <tr>
                                        <td class="tright" style="width: 20%">Họ và tên <span class="f-red">(*)</span> :
                                        </td>
                                        <td style="width: 80%" colspan="3">
                                            <input type="text" class="span12" required id="cName" value="<%=ViewData["cName"] %>" name="cName">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright">Địa chỉ: <span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="text" class="span12" id="cAddress" name="cAddress">
                                        </td>
                                         <td class="tright">Số điện thoại: <span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="text" class="span12" id="cPhone" name="cPhone">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright">Tên facebook: <span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="text" class="span12" id="cNameFace" name="cNameFace">
                                        </td>
                                         <td class="tright">Link: <span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="text" class="span12" id="cLinkFace" name="cLinkFace">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tright">Ngân hàng: <span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <select id="iBank" name="iBank" class="span12">
                                                <option value="0"> Chọn ngân hàng</option>
                                            </select>
                                           
                                        </td>
                                         <td class="tright">Số tài khoản: <span class="f-red">(*)</span> :
                                        </td>
                                        <td>
                                            <input type="text" class="span12" id="cCardBank" name="cCardBank">
                                        </td>
                                    </tr>
                                     <tr>
                                       
                                    </tr>
                                 
                                    <tr>
                                        <td class="tcenter" colspan="4">
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
            url: "<%=ResolveUrl("~")%>employee/insert",
            data: $("#_form").serialize(),
            success: function (ok) {             
                if (ok==1) {
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
