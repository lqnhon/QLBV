﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Danh sách bài viết đang chờ duyệt
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">Bài viết đang chờ duyệt</a></div>
    <div class="row-fluid">
        <div class="span12">

            <table class="table table-bordered table-invoice">
                <tbody>
                    <tr>
                        <td style="width: 5%">Nhập từ khóa:</td>
                        <td style="width: 20%">
                            <input type="text" id="key" name="key" placeholder="Nhập tiêu đề, mô tả, nội dung bài viết..." class="span12">
                        </td>                      
                        <td class="tleft" style="width: 10%"> 
                            <button onclick="Xem()" class="btn btn-warning">Xem</button>
                        </td>   
                    </tr>
                </tbody>
            </table>

        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">

            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>Danh sách bài viết đang soạn thảo</h5>
                </div>
                <div class="widget-content nopadding">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th style="width: 5%">STT</th>
                                <th style="width: 10%">Ngày tạo</th>
                                <th style="width: 70%">Tiêu đề</th>
                                <th style="width: 15%">Chức năng</th>
                            </tr>
                        </thead>
                        <tbody id="list">
                            <%=ViewData["data"] %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </div>
    <script type="text/javascript">
        $('#iSupplier').select2();
        function Xem() {
            $("body").prepend('<div id="screen"><div id="loader"><div id="load1" class="spin"></div><div id="load2" class="spin"></div>' +
    '<div id="load3" class="spin"></div><div id="load4" class="spin"></div><div id="load5" class="spin"></div></div></div>');
            $.post("/waitingForReview/search", "key=" + $("#key").val(), function (data) {
                $("#list").html(data);
                $("#screen").hide().remove();
            });
        }
</script>
</asp:Content>
