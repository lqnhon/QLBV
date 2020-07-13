// JavaScript Document
var sitename = "/";
function HidePopup(){// ẩn popup
    $("#screen").remove();
    $("#popup").remove();
}
function ScrollPage(height){
    $('html, body').animate({ scrollTop: height }, 'slow');
}
function AlertAction(stralert) {
    var div = "<div id='titthongbao' class='alert alert-info'><i class='icon-ok-sign'></i> " + stralert + "</div>";
    $("body").prepend(div);
    $("#titthongbao").fadeOut(2500);
}
function PopupBody(url, str_post) {    
    $.post(sitename + "Content/Ajax/" + url + ".aspx", str_post, function (data) {
        $("body").prepend(data);
    });
}
function ShowPopUp(url, post) {
    $.post(sitename + "Content/Ajax/" + url + ".aspx", post, function (data) {
        
        $("body").prepend(data);
    });
}
function ThuTucQuanTam(id) {
    $.post(sitename + "Content/Ajax/Thutuc/quantam_add.aspx", "id=" + id, function (data) {
        $("#thutuc_quantam").remove();
        $(".favourite").hide();
        $(".main_right").prepend(data);
    });
}
