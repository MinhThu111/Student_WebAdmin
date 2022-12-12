
//Declare icon html
var _loadAnimationSmallHtml = '<div class="spinner-border d-flex align-content-end flex-wrap" role="status" style="width:1rem;height:1rem;"><span class="sr-only"></span></div>',
    _iconEditHtml = '<button type="button">Edit</button>',
    _iconAddHtml = '<i class="fa fa-plus-circle"></i>',
    _iconDeleteHtml = '<button type="button">Delete</button>',
    _iconSearchHtml = '<i class="ti-icon"></i>',
    _iconPublishHtml = '<i class="mdi mdi-publish"></i>',
    _iconuPublishHtml = '<i class="mdi mdi-cancel"></i>',
    _iconViewHtml = '<i class="mdi mdi-eye text-info"></i>',
    _iconGPSHtml = '<i class="icons8-google-maps"></i>',
    _iconLoadingHtml = '<i class="mdi mdi-spin mdi-loading"></i>';
_iconPermissionHtml = '<i class="icon-people text-warning"></i>';

//Declare loading overlay
var _overlaySuccessHtml = `<div class="overlay_update_success" style=" background-color: seagreen; display: flex; justify-content: center; align-items: center; opacity: 0.3; width: 100%; z-index: 10; height: 100%; position: absolute; ">
                            <i class="mdi mdi-check mdi-36px text-white"></i>
                        </div>`;
var _loadingOverlay = '<div class="overlay-loading" style="display:none;"><div class="lds-ring"><div></div><div></div></div></div>';
var _loadingOverlay3Dot = '<div class="overlay-loading" style="display:none;"><div class="lds-ellipsis"><div></div><div></div><div></div></div>';
var _loadingButtonOverlay = `<div class="overlay-loading-button text-center" style="display:none;"><div class="lds-dual-ring"><div></div><div></div><div></div><div></div></div>`;


//Declare resources language in js
var _dataTableResource = {
    Search: "Tìm kiếm:",
    Show: "Xem",
    All: "Tất cả",
    Entries: "dòng",
    Showing: "Đang xem",
    To: "đến",
    Of: "của",
    Next: "<i class='mdi mdi-chevron-right'>",
    Previous: "<i class='mdi mdi-chevron-left'>",
    First: "Trang đầu",
    Last: "Trang cuối",
    EmptyTable: "Không có dữ liệu",
    LoadingRecords: "Đang tải...",
    ZeroRecords: "Không tìm thấy dữ liệu"
};
var _dataTablePaginationStyle = function () {
    $(".dataTables_paginate > .pagination").addClass("pagination-rounded");
};
var _buttonResource = {
    Add: "Thêm",
    AddNew: '<i class="fa fa-plus-circle"></i> Thêm mới',
    Edit: "Sửa",
    Update: "Cập nhật",
    Save: "Lưu",
    Pushlish: "Đăng",
    uPushlish: "Gỡ",
    Delete: "Xóa",
    Cancel: "Hủy",
    Lock: "Khóa",
    UnLock: "Mở khóa",
    ChangePassword: "Đổi mật khẩu",
    ResetPassword: "Làm mới mật khẩu",
    ConfirmDelete: "Xác nhận xóa?",
    ConfirmSave: "Xác nhận lưu?",
    ConfirmLock: "Xác nhận khóa?",
    ConfirmUnLock: "Xác nhận mở khóa?",
    ConfirmRecover: "Xác nhận khôi phục?",
    View: "Xem",
    Accept: "Chấp nhận",
    Schedule: "Xếp lịch",
    Permission: "Quyền"
};
var _resultActionResource = {
    AddSuccess: "Thêm thành công",
    UpdateSuccess: "Cập nhật thành công",
    DeleteSuccess: "Đã xóa",
    LockSuccess: "Đã khóa",
    UnLockSuccess: "Đã mở khóa",
    RecoverSuccess: "Đã khôi phục",
    AddFail: "Thêm thất bại",
    UpdateFail: "Cập nhật thất bại",
    DeleteFail: "Xóa thất bại",
    ErrorAction: "Kết nối đến máy chủ không ổn định",
    PleaseWrite: "Bạn chưa nhập đủ hoặc thông tin không hợp lệ",
    NoData: "Không có dữ liệu",
};
var _textOhterResource = {
    contact: "Liên hệ",
    active: "Mở",
    lock: "Khóa",
};

var _lengthMenuResource = [[10, 25, 50, 100, -1], ['10', '25', '50', '100', 'Tất cả']];

var _languageDataTalbeObj = {
    url: '/assets/libs/datatables.net/js/i18n/vi.json',
};

var _imageErrorUrl = {
    avatar: `onerror="this.onerror=null;this.src='/images/error-avatar.png';"`,
    square: `onerror="this.onerror=null;this.src='/images/error-image.png';"`,
    notFound: '<div class="text-center"><img src="/images/notFound.png"></div>',
};

//Check response is success
function CheckResponseIsSuccess(data) {
    var type = "warning";
    let isSuccess = false;
    switch (parseInt(data.result)) {
        case -1: type = "error"; ListErrorCodeAndMessage(data, type); break;
        case 0: type = "warning"; ShowToastNoti(type, '', data.error.message); break;
        case 1: type = "success"; isSuccess = true; break;
        default: break;
    }
    return isSuccess;
}

//List error code
function ListErrorCodeAndMessage(data, type) {
    switch (parseInt(data.error.code)) {
        case -2: ShowToastNoti(type, '', "Có gì đó không đúng!"); break;
        case -1: ShowToastNoti(type, '', "Có lỗi trong quá trình truy cập dữ liệu!"); break;
        case 0:
            if (!window.navigator.onLine)
                ShowToastNoti(type, '', "No Internet! Hãy kiểm tra kết nối mạng!");
            else
                ShowToastNoti(type, '', data.error.message ?? "");
            break;
        case 400: ShowToastNoti(type, "Lỗi 400!", "Yêu cầu không hợp lệ!"); break;
        case 401:
            //ShowToastNoti(type, "Lỗi 401!", "Chưa xác thực hoặc hết phiên. Vui lòng đăng nhập lại!"); SignInAgain();
            setTimeout(function () { location.href = '/account/signout?ReturnUrl=' + location.pathname; }, 100); break;
        case 403: ShowToastNoti(type, "Lỗi 403!", "Không có quyền truy cập!"); break;
        case 404: ShowToastNoti(type, "Lỗi 404!", "Không tìm thấy tài nguyên được yêu cầu!"); break;
        case 405: ShowToastNoti(type, "Lỗi 405!", "Phương thức yêu cầu vô hiệu hóa!"); break;
        case 406: ShowToastNoti(type, "Lỗi 406!", "Không tìm thấy bất kỳ nội dung nào với yêu cầu đưa ra!"); break;
        case 407: ShowToastNoti(type, "Lỗi 407!", "Yêu cầu xác thực proxy!"); break;
        case 408:
            //ShowToastNoti(type, "Lỗi 408!", "Phiên đăng nhập hết hạn! Đang thử tạo lại phiên mới...", 3000);
            SignOutJs(); break;
        case 409: ShowToastNoti(type, "Lỗi 409!", "Yêu cầu xung đột với máy chủ!"); break;
        case 410: ShowToastNoti(type, "Lỗi 410!", "Nội dung yêu cầu đã bị xóa!"); break;
        case 411: ShowToastNoti(type, "Lỗi 411!", "Máy chủ từ chối yêu cầu!"); break;
        case 411: ShowToastNoti(type, "Lỗi 411!", "Máy chủ từ chối yêu cầu!"); break;
        case 412: ShowToastNoti(type, "Lỗi 412!", "Điều kiện tiên quyết không được đáp ứng!"); break;
        case 413: ShowToastNoti(type, "Lỗi 413!", "Dữ liệu yêu cầu vượt giới hạn!"); break;
        case 414: ShowToastNoti(type, "Lỗi 414!", "URI yêu cầu dài hơn mức quy định!"); break;
        case 415: ShowToastNoti(type, "Lỗi 415!", "Định dạng của dữ liệu được yêu cầu không được máy chủ hỗ trợ!"); break;
        case 416: ShowToastNoti(type, "Lỗi 416!", "Không thể thực hiện phạm vi yêu cầu!"); break;
        case 417: ShowToastNoti(type, "Lỗi 417!", "Máy chủ không thể đáp ứng được yêu cầu!"); break;
        case 421: ShowToastNoti(type, "Lỗi 421!", "Yêu cầu được hướng đến một máy chủ không thể tạo phản hồi!"); break;
        case 423: ShowToastNoti(type, "Lỗi 423!", "Tài nguyên đang được truy cập bị khóa!"); break;
        case 424: ShowToastNoti(type, "Lỗi 424!", "Yêu cầu không thành công do không thực hiện được yêu cầu trước đó!"); break;
        case 428: ShowToastNoti(type, "Lỗi 428!", "Máy chủ gốc yêu cầu yêu cầu phải có điều kiện!"); break;
        case 429: ShowToastNoti(type, "Lỗi 429!", "Bạn đang yêu cầu quá nhiều trong một khoảng thời gian nhất định!"); break;
        case 431: ShowToastNoti(type, "Lỗi 431!", "Máy chủ không thể xử lý yêu cầu vì tiêu đề quá lớn!"); break;
        case 451: ShowToastNoti(type, "Lỗi 451!", "Tài nguyên yêu cầu không thể được cung cấp một cách hợp pháp!"); break;
        case 500: ShowToastNoti(type, "Lỗi 500!", `Máy chủ không thể xử lý yêu cầu! ${!IsNullOrEmty(data.error.message) ? "<br/>" + data.error.message : ""}`); break;
        case 501: ShowToastNoti(type, "Lỗi 501!", "Phương thức yêu cầu không được máy chủ hỗ trợ và không thể xử lý được!"); break;
        case 502: ShowToastNoti(type, "Lỗi 502!", "Máy chủ nhận được một phản hồi không hợp lệ!"); break;
        case 503: ShowToastNoti(type, "Lỗi 503!", "Máy chủ xảy ra lỗi trong quá trình xử lý yêu cầu!"); break;
        case 504: ShowToastNoti(type, "Lỗi 504!", "Máy chủ không thể nhận được phản hồi kịp thời!"); break;
        case 505: ShowToastNoti(type, "Lỗi 505!", "Phiên bản HTTP được sử dụng trong yêu cầu không được máy chủ hỗ trợ!"); break;
        case 506: ShowToastNoti(type, "Lỗi 506!", "Máy chủ có lỗi cấu hình nội bộ!"); break;
        case 507: ShowToastNoti(type, "Lỗi 507!", "Máy chủ không đủ tài nguyên!"); break;
        case 508: ShowToastNoti(type, "Lỗi 508!", "Máy chủ đã phát hiện một vòng lặp vô hạn trong khi xử lý yêu cầu!"); break;
        case 510: ShowToastNoti(type, "Lỗi 510!", "Cần có các phần mở rộng khác cho yêu cầu để máy chủ đáp ứng yêu cầu đó!"); break;
        case 511: ShowToastNoti(type, "Lỗi 511!", "Máy khách cần xác thực để có quyền truy cập mạng!"); break;
        default: ShowToastNoti(type, '', data.error.message ?? ""); break;
    }
}

//Add first row DataTalbe
function AddFirstRowDataTable(table, data) {
    //Add row data
    table.row.add(data).draw(false).node();

    //Set current page
    var currentPage = table.page();

    //move added row to desired index
    var rowCount = table.data().length - 1,
        insertedRow = table.row(rowCount).data(),
        tempRow;
    for (var i = rowCount; i >= 1; i--) {
        tempRow = table.row(i - 1).data();
        table.row(i).data(tempRow);
        table.row(i - 1).data(insertedRow);
    }

    //refresh the current page
    table.page(currentPage).draw(false);

    //Add animation new row
    var rowNode = table.row(0).node();
    RunAnimationAddRowNode(rowNode);
}

//Run animation add
function RunAnimationAddRowNode(rowNode) {
    $('.dataTables_scrollHeadInner').css('width', '100%');
    $('.dataTables_scrollFootInner').css('width', '100%');
    $('.dataTables_scrollHeadInner table').css('width', '100%');
    $('.dataTables_scrollFootInner table').css('width', '100%');
    setTimeout(function () {
        //4a81d4
        $(rowNode).css({ "background-color": "#339933", "color": "white", "fontSize": ".1rem", "opacity": "0" })
            .animate({
                fontSize: '.75rem',
                opacity: '1'
            }, 300);
        setTimeout(function () {
            if ($(rowNode).hasClass('odd')) {
                $(rowNode).css({ "background-color": "#f3f7f9", "transition": "3s", "color": "#6c757d" });
            } else {
                $(rowNode).css({ "background-color": "#fff", "transition": "3s", "color": "#6c757d" });
            }
            setTimeout(() => {
                $(rowNode).removeAttr("style");
            }, 3000);
        }, 300);
    }, 800);
}

//Run animation delete
function RunAnimationDeleteRowNode(rowNode) {
    $('.dataTables_scrollHeadInner').css('width', '100%');
    $('.dataTables_scrollFootInner').css('width', '100%');
    $('.dataTables_scrollHeadInner table').css('width', '100%');
    $('.dataTables_scrollFootInner table').css('width', '100%');
    $(rowNode).css({ "fontSize": ".875rem", opacity: "1" })
        .animate({
            fontSize: '.1rem',
            opacity: '0'
        }, 500);
}

//Run animation edit
function RunAnimationEditRowNode(rowNode) {
    $('.dataTables_scrollHeadInner').css('width', '100%');
    $('.dataTables_scrollFootInner').css('width', '100%');
    $('.dataTables_scrollHeadInner table').css('width', '100%');
    $('.dataTables_scrollFootInner table').css('width', '100%');
    setTimeout(function () {
        //FFCC33 | bb000c
        $(rowNode).css({ "background-color": "#18c355", "color": "#FF0000", "font-weight": "bold" }).animate({
            opacity: '0.7'
        }, 300);
        $(rowNode).animate({
            opacity: '1'
        }, 300);
        $(rowNode).css({ "background-color": "#fff", "transition": "3s", "color": "#6c757d" });
        setTimeout(() => {
            $(rowNode).removeAttr("style");
        }, 2000);
    }, 200);
}

//Change UI Add
function ChangeUIAdd(table, data) {
    AddFirstRowDataTable(table, data);
}

//Change UI Edit
function ChangeUIEdit(table, id, data) {
    var rowIdx;
    var rowData = table.row(
        function (idx, data, node) {
            if (data.id == id) {
                rowIdx = idx;
                return idx.toString();
            }
        }).data();
    Object.keys(data).forEach((item, index) => rowData[item] = data[item]);
    table.row(rowIdx).data(rowData).draw(false);
    var rowNode = table.row(function (idx, data, node) { if (data.id == id) return idx.toString(); }).node();
    RunAnimationEditRowNode(rowNode);
}

//Change UI Delete
function ChangeUIDelete(table, id) {
    var rowNode = table.row(function (idx, data, node) { if (data.id == id) return idx.toString(); }).node();
    RunAnimationDeleteRowNode(rowNode);
    setTimeout(() => table.row(function (idx, data, node) { if (data.id == id) return idx.toString(); }).remove().draw(false), 500);
}

function IsNullOrEmty(string) {
    return string == null || string === "";
}

//Show hide panel
function ShowHidePanel(panelShow, panelHide) {
    $(panelHide).fadeOut(100);
    setTimeout(function () {
        $(panelShow).fadeIn(100);
    }, 200);
}

//Show panel
function ShowPanel(panel) {
    $(panel).slideDown(200);
}

//Hide panel
function HidePanel(panel) {
    $(panel).fadeOut(200);
}

//Back to talbe
function BackToTable(elmShow = '#div_main_table', elmHide = '#div_view_panel') {
    ShowHidePanel(elmShow, elmHide);
    $('.dataTables_scrollHeadInner').css('width', '100%');
    $('.dataTables_scrollFootInner').css('width', '100%');
    $('.dataTables_scrollHeadInner table').css('width', '100%');
    $('.dataTables_scrollFootInner table').css('width', '100%');
    $(elmHide).find('.navbar_title').removeClass('active');
    //setTimeout(function () {
    //    $('#div_view_panel').html('');
    //}, 200);
}

//Show overlay
function ShowOverlay(elm) {
    var $loading = $($(elm).children()[0]);
    if (!$loading.hasClass('overlay-loading')) {
        $(elm).prepend(_loadingOverlay);
        $($(elm).children()[0]).fadeIn(100);
    }
}

//Hide overlay
function HideOverlay(elm) {
    var $loading = $($(elm).children()[0]);
    if ($loading.hasClass('overlay-loading')) {
        $loading.fadeOut(100);
        setTimeout(function () {
            $loading.remove();
        }, 150);
    }
}

//Clear validate form css
function RemoveClassValidate(elm) {
    try {
        $(elm).removeClass("was-validated");
        $(elm).find('input').removeClass("parsley-success");
        $(elm).find('input').removeClass("parsley-error");
        $('.parsley-errors-list').remove();
    } catch (e) {

    }
    //Remove other
    //$("#detailEditor").summernote("code", ""); //clear detail
    //myDropzone.removeAllFiles(); //clear file dropzone
    //$(".dropify-clear").click(); //clear dropify
}

//Show message error
function ShowToastNoti(type, title, message, timeout = 2000, position = 'topRight', icon = '') {
    let color = '';
    switch (type) {
        case 'success': icon = '<i class="iziToast-icon ico-success revealIn"></i>'; color = 'green';
             break;
        //var audio = new Audio('/sounds/sound1.ogg'); audio.volume = 0.2; audio.play(); break;
        case 'warning': icon = '<i class="iziToast-icon ico-warning revealIn"></i>'; color = 'orange';
            break;
        //var audio = new Audio('/sounds/sound6.ogg'); audio.volume = 0.8; audio.play(); break;
        case 'error': icon = '<i class="iziToast-icon ico-error revealIn"></i>'; color = 'red';
             break;
        //var audio = new Audio('/sounds/sound5.ogg'); audio.volume = 0.4; audio.play(); break;
        case 'info': icon = '<i class="iziToast-icon ico-info revealIn"></i>'; color = 'blue';
             break;
        //var audio = new Audio('/sounds/sound7.ogg'); audio.volume = 0.4; audio.play(); break;
        case 'question': icon = '<i class="iziToast-icon ico-question revealIn"></i>'; color = 'yellow';
             break;
        //var audio = new Audio('/sounds/sound4.ogg'); audio.volume = 0.4; audio.play(); break;
        default: break;
    }
    iziToast.show({
        icon: icon,
        color: color,
        displayMode: 0,
        title: title,
        message: message,
        position: position,
        progressBar: true,
        timeout: timeout,
        transitionIn: 'flipInX',
        transitionOut: 'flipOutX',
        progressBarColor: 'rgb(0, 255, 184)',
        imageWidth: 70,
        layout: 2,
        iconColor: 'rgb(0, 255, 184)'
    });
}

//Check validateion in lib Unobtrusive js
function CheckValidationUnobtrusive(formElm) {
    $.validator.unobtrusive.parse(formElm);
    formElm.validate();
    //$.each(formElm.validate().errorList, function (key, value) {
    //    $errorSpan = formElm.find(`span[data-valmsg-for="${value.element.id}"]`);
    //    $errorSpan.html(`<span>${value.message}</span>`);
    //    $errorSpan.show();
    //});
    return formElm.valid();
}
