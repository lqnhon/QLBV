// JavaScript Document
var sitename = "";
var emailRegExp = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.([a-z]){2,4})$/;
var file_type = "doc,docx,xls,xlsx,pdf,jpg,png,jpeg,JPG,JPEG";
function openPopup(url) {
    opener = window.open(url, 'openPopup', 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=0,dependent=no,width=0,height=0');

}
function UpdateNgayKetThuc(val, id) {
    val = val.split("/");
    year = parseInt(val[2]) + 20;
    $("#" + id).val(val[0] + "/" + val[1] + "/" + year);
}
function DownLoadDocument(post, url) {
    $.post(sitename+url, post, function () { });
}
function CheckFileTypeUpload(idfile,id_namefile) {
    file = $("#" + idfile).val();
    filetype_upload = file.split(".");
    typefile = filetype_upload[filetype_upload.length - 1];
    var filetype_check = file_type.split(",");
    check = 0;
    for (i = 0; i < filetype_check.length; i++) {
        if (typefile == filetype_check[i]) { check = check + 1; break; }
    }
    if (check == 0) {
        alert("Định dạng file đính kèm không hợp lệ! Vui lòng chỉ chọn các định dạng: " + file_type);
        $("#" + idfile).val("");
        $("#" + id_namefile).val("");
        
    } else {
        $("#" + id_namefile).val(file);
    }
}
function CheckFileType1(idfile) {
    file = $("#" + idfile).val();
    filetype_upload = file.split(".");
    typefile = filetype_upload[filetype_upload.length - 1];
    var filetype_check = file_type.split(",");
    check = 0;
    for (i = 0; i < filetype_check.length; i++) {
        if (typefile == filetype_check[i]) { check = check + 1; break; }
    }
    
    if (check == 0) {        
        alert("Định dạng file đính kèm không hợp lệ! Vui lòng chỉ chọn các định dạng: "+file_type);
        $("#" + idfile).val("");
        return false;        
    } else { 
        return true;
    }
}
function CheckFileType(idfile) {
    file = $("#" + idfile).val();
    filetype_upload = file.split(".");
    typefile = filetype_upload[filetype_upload.length - 1];
    var filetype_check = file_type.split(",");
    check = 0;
    for (i = 0; i < filetype_check.length; i++) {
        if (typefile == filetype_check[i]) { check = check + 1; break; }
    }
    if (check == 0) {
        if (!confirm("Định dạng file đính kèm không hợp lệ! Bạn vẫn muốn lưu mà không dùng file đính kèm?")) {
            return false;
        } else {
            //$(".yourBtn").html("");
            $("#" + idfile).val("");
            return true;
        }
    } else { 
        return true
    }
}

function AlertAction(stralert) {
    var div="<div id='titthongbao' class='alert alert-info'><i class='icon-ok-sign'></i> "+stralert+"</div>";
    $("body").prepend(div);
    $("#titthongbao").fadeOut(2500);
}
function ChangePhongLuuTru(id) {
    //alert(id);
    $.post(sitename + "/Home/Ajax_Change_font", "id=" + id, function (data) {
        if (data == 1) {
            location.reload();
        } else {
            alert(data);
        }
    });
}
function TopPage(height){
    $('html, body').animate({ scrollTop: height }, 'slow');
}
function ShowPopUp(post, url) {
    HidePopup();
    
    $("body").prepend('<div id="screen"><div id="loader"><div id="load1" class="spin"></div><div id="load2" class="spin"></div>'+
        '<div id="load3" class="spin"></div><div id="load4" class="spin"></div><div id="load5" class="spin"></div></div></div>');
    $.post(sitename + url, post, function (data) {
        //alert(data);
        HidePopup();
        $("body").prepend(data);    
        $('.datepick').datepicker();
    });    
}
function ShowPopUpSecond(post, url) {
    

    $("body").prepend('<div id="screen2"><div id="loader"><div id="load1" class="spin"></div><div id="load2" class="spin"></div>' +
        '<div id="load3" class="spin"></div><div id="load4" class="spin"></div><div id="load5" class="spin"></div></div></div>');
    $.post(sitename + url, post, function (data) {
        //alert(data);
        HidePopupSecond();
        $("body").prepend(data);
        $('.datepick').datepicker();
    });
}
function HidePopup(){
    $("#screen").hide().remove();
    $("#popup").hide().remove();
}
function HidePopupSecond() {
    $("#screen2").hide().remove();
    $("#popup2").hide().remove();
}
function ChangeLoaiLuuTru(id, value, url) {
    
    $.post(sitename + url, "id="+id+"&value="+value, function (data) {
        if (data == 1) {
            AlertAction("Cập nhật thành công!");
        } else {
            alert(data);
        }
    });
}
function UpdateStatus(post, url) {
    //alert(post+url);
    $.post(sitename + url, post, function (data) {
        if (data == 1) {
            AlertAction("Cập nhật thành công!");
        } else {
            alert(data);
        }
    });
}
function ShowFormEdit(url, post, place) {
    var reloader = '<div id="loader"><div id="load1" class="spin"></div><div id="load2" class="spin"></div>' +
        '<div id="load3" class="spin"></div><div id="load4" class="spin"></div><div id="load5" class="spin"></div></div>';
    $("#" + place).show().html(reloader);
    //$("#" + place).show().html("<p class='tcenter'><img src='/images/ajax-loader.gif'/></p>");
    
    $.post(sitename + url, post, function (data) {
            TopPage(100);
            $("#" + place).show().html(data);
        });   
}
function UpdateOrder(post, value, url) {
    if (isNaN(value)) {
        alert("Vui lòng chỉ nhập số!");
        return false;
    } else {
        //alert(post);
        $.post(sitename + url, post + "&value=" + value, function (data) {
            if (data == 1) {
                AlertAction("Cập nhật thành công!")
            } else { alert(data); }
        });
        
    }
}
function DeleteFile(id, url) {
    if (confirm("Bạn có thật sự muốn file đính kèm này?")) {
        $.post(sitename + url, "id=" + id, function (data) {
            if (data == 1) {
                $("#file_" + id).hide().remove();
                AlertAction("Xóa thành công!")
            } else {
                alert(data);
            }
        });
    }
}
function DoActionRemoveTr(id, url) {
   // alert(id + url);
    $.post(sitename + url, "id=" + id, function (data) {
            if (data == 1) {
                $("#tr_" + id).hide().remove();
                AlertAction("Cập nhật thành công!")
            } else {
                alert(data);
            }
        });
    
}
function DeletePage(id,post, url) { //Xóa nhanh
    if (confirm("Bạn có thật sự muốn xóa?")) {
        $.post(sitename + url, post, function (data) {
            if (data == 1) {
                $("#tr_" + id).hide().remove();
                AlertAction("Xóa thành công!")
                location.reload();
            } else {
                alert(data);
            }
        });
    }
}
function DeleteTieuChi(post, url) {
    if (confirm("Bạn có thật sự muốn xóa?")) {
        $.post(sitename + url, post, function (data) {
            if (data == 1) {
                location.reload();
            } else {
                alert(data);
            }
        });
    }
}
function str_replace(string, search, replace) {
    return string.split(search).join(replace);
}
function CheckNum(id) {
    
    var val = str_replace($("#" + id).val(), ",", ".");
    
    if (isNaN(val)) {
        alert("Vui lòng chỉ nhập số!");
        $("#" + id).focus();
        $("#" + id).val(0);
    } else {
        $("#" + id).val(val);
    }
}