<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=ViewData["cTopic"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">Nội dung bài viết</a></div>
    <div class="row-fluid">
        <div class="span8">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-list"></i></span>
                    <h5><%=ViewData["cTopic"] %></h5>
                </div>
                <div class="widget-content">
                    <div id="Topic" style="font: 700 24px/23px 'Times New Roman'; color: #004175;">
                        <h3 class=""><%=ViewData["cTopic"] %></h3>
                    </div>
                    <div id="cDescribe" style="font: 700 16px/18px 'Times New Roman'; color: #5f5f5f; margin-top: 10px!important;"><%=ViewData["cDescribe"] %></div>
                    <div id="cContent" style="margin-bottom: 2%; padding: auto!important; line-height: 20px!important; font-family: Times New Roman; font-size: 12pt;"><%=ViewData["cContent"] %></div>
                    <div id="Detail" class="tright" style="margin-bottom: 2%; padding: auto!important; line-height: 20px!important; font-family: Times New Roman; font-size: 12pt;">Theo: <strong><%=ViewData["cName"] %></strong> </div>
                    <div id="Key" style="color: #07468b;">Từ khóa: <%=ViewData["cKey"] %> </div>
                </div>
            </div>
        </div>
        <div class="span4">
            <div class="widget-box widget-chat">
                <div class="widget-title bg_lb">
                    <span class="icon"><i class="icon-comment"></i></span>
                    <h5>Trao đổi</h5>
                </div>
                <div class="widget-content nopadding collapse in" id="collapseG4">

                    <div class="chat-content">
                        <div class="chat-messages" id="chat-messages">
                            <div id="chat-messages-inner">
                                <%=ViewData["cmt"] %>
                            </div>
                        </div>
                        <div class="chat-message well">
                            <form id="login-form" method="post" class="nomagin" name="form" onsubmit="return CapNhat();">
                                <input type="hidden" value="<%=ViewData["id"] %>" id="id" name="id" />
                                <button class="btn btn-success" >Gửi</button>
                                <span class="input-box">
                                    <textarea name="msg-box" id="msg-box"  style="height: 20px"></textarea>
                                </span>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function CapNhat() {
         
                $.ajax({
                    type: "post",
                    url: "<%=ResolveUrl("~")%>content/chat",
                data: $("form").serialize(),
                success: function (ok) {
                    $("#chat-messages-inner").prepend(ok);
                    $("#msg-box").val("");
                }
            });
            return false;
      
    }
    </script>
</asp:Content>
