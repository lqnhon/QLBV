<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="QLBV.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Danh sách bài viết
</asp:Content>

 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Entities dt = new Entities(); %>   
    <% 
        int id_user = 0;
        if (Request.Cookies["user_id"] != null)
        {
            id_user = Convert.ToInt32(Request.Cookies["user_id"].Value);
        }
      
        int daduocduyet = dt.tblContents.Where(v => v.iCreateBy == id_user && v.iStatus == 3).Count();
        int toanbo = dt.tblContents.Where(v => v.iStatus == 3).Count();
 
    %>
    <div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a></div>
    <div class="row-fluid">
        <div class="span6">
            <div class="widget-box">
                <div class="widget-title bg_ly" data-toggle="collapse" href="">
                    <span class="icon"><i class="icon-chevron-down"></i></span>
                    <h5>Top thành viên tháng <%=DateTime.Now.Month %> năm <%=DateTime.Now.Year %></h5>
                </div>
                <div class="widget-content nopadding collapse in" id="collapseG2">
                    <ul class="recent-posts">
                        <%=ViewData["top"] %>
                    </ul>
                </div>
            </div>

        </div>
        <div class="span6">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-ok"></i></span>
                    <h5>Trạng thái bài viết</h5>
                </div>
                <div class="widget-content">
                    <ul class="unstyled">
                        <%=ViewData["content"] %>
                      
                    </ul>
                </div>
            </div>

        </div>
    </div>
    <div class="row-fluid">
        <div class="span6">
            <div class="widget-box">
                <div class="widget-title bg_lo" data-toggle="collapse">
                    <span class="icon"><i class="icon-chevron-down"></i></span>
                    <h5>Top bài viết mới nhất</h5>
                </div>
                <div class="widget-content nopadding updates collapse in" >
                <%= ViewData["topcontent"] %>    
                </div>
            </div>

        </div>
        <div class="span6">
            <div class="widget-box">
                <div class="widget-title bg_lo" data-toggle="collapse" >
                    <span class="icon"><i class="icon-chevron-down"></i></span>
                    <h5>Top bình luận mới nhất</h5>
                </div>
                <div class="widget-content nopadding updates collapse in">
                    <%=ViewData["topcomment"] %>
                   </div>
            </div>

        </div>
    </div>

</asp:Content>
