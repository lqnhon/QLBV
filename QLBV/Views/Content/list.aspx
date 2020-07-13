<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Danh sách bài viết đã được duyệt và chờ xử lý
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">Danh sách bài viết đã được duyệt và chờ xử lý</a></div>
    
    <div class="row-fluid">
        <div class="span12">

            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>Danh sách bài viết đã được duyệt và chờ xử lý</h5>
                </div>
                <div class="widget-content nopadding">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th style="width: 5%">STT</th>
                                <th style="width: 55%">Họ và tên</th>
                           
                                <th style="width: 25%">Số bài viết</th>
                                 <th style="width: 15%">Chi tiết</th>
                              
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
            $.post("/content/search", "key=" + $("#key").val(), function (data) {
                $("#list").html(data);
                $("#screen").hide().remove();
            });
        }
    </script>
</asp:Content>
