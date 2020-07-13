<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
     <script src="<%=ResolveUrl("~")%>js/jquery.min.js"></script>
    <script src="<%=ResolveUrl("~")%>ckfinder/ckfinder.js"></script>
    <script src="<%=ResolveUrl("~")%>ckeditor/ckeditor.js"></script>
    <title>test</title>
</head>
<body>
    <div>
        <textarea id="editor1" name="editor1" rows="10" cols="80">
                This is my textarea to be replaced with CKEditor.
</textarea>

     
    </div>
</body>
    <script>
        CKEDITOR.replace('editor1',  {
            filebrowserBrowseUrl: '/ckfinder/ckfinder.html?/'
        });

        function BrowseServer() {
            var finder = new CKFinder();
            //finder.basePath = '../';
            finder.selectActionFunction = SetFileField;
            finder.popup();
        }
        function SetFileField(fileUrl) {
            document.getElementById('Image').value = fileUrl;
        }
    </script>
</html>
