<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Soạn thảo văn bản
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">Soạn thảo văn bản</a></div>

    <div class="row-fluid">
        <div class="span12">
            <div class="span12">
                <form method="post" name="_form" id="_form" class="form-horizontal" enctype="multipart/form-data">
                    <table class="table table-bordered table-invoice">
                        <tbody>
                            <tr>
                                <td style="width: 15%">Tiêu đề:</td>
                                <td style="width: 85%">
                                    <input type="text" class="span12" id="cTopic" name="cTopic" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15%">Mô tả:</td>
                                <td style="width: 85%">
                                    <textarea id="cDescribe" name="cDescribe" class="span12"></textarea>
                                </td>
                            </tr>

                            <tr>

                                <td>Nội dung chính:</td>
                                <td>
                                    <textarea id="cContent" name="cContent" class="span12"></textarea>
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 15%">Từ khóa:</td>
                                <td style="width: 85%">
                                    <input type="text" class="span12" id="cKey" name="cKey" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tright" colspan="4">
                                    <input type="hidden" id="id" name="id" value="<%=ViewData["id"] %>" />
                                    <input type="hidden" id="chosen" name="chosen" />
                                    <input type="submit" class="btn btn-primary" onclick="ChosenSave(1)" value="Lưu tạm thời" />
                                    <input type="submit" class="btn btn-primary" onclick="ChosenSave(2)" value="Lưu và chuyển duyệt" />
                                    <a class="btn btn-danger">Hủy bài viết</a>
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </form>

            </div>

        </div>

    </div>
    <style>
      
    </style>
   
    <script src="<%=ResolveUrl("~")%>Scripts/jquery-1.7.1.min.js"></script>
    <script src="<%=ResolveUrl("~")%>Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~")%>Content/ckfinder/ckfinder.js" type="text/javascript"></script>
    <script>
        var editor;
        function createEditor(languageCode, id) {
            var editor = CKEDITOR.replace(id, {
                language: languageCode,
                height: 1000,

            });
        }

        $(function () {
            createEditor('vi', 'cContent');
        });
    </script>

</asp:Content>
