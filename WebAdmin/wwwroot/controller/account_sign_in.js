var laddaSubmitForm;

$(document).ready(function () {

    //Submit form
    $('#form_data').on('submit', function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        let $formElm = $('#form_data');
        let isvalidate = $formElm[0].checkValidity();
        if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); return false; }
        let formData = new FormData($formElm[0]);
        $.ajax({
            url: $formElm.attr('action'),
            type: $formElm.attr('method'),
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.result === 3) { //Is unAuthen
                    ShowToastNoti('error', '', 'Bạn không có quyền đăng nhập hệ thống!', 3000, 'topCenter');
                } else if (response.result === 1) { //Is success
                    ShowToastNoti('success', '', 'Đăng nhập thành công. Đang chuyển hướng...', 4000, 'topCenter');
                    location.href = '/';
                } else { //Fail
                    CheckResponseIsSuccess(response);
                }
            }, error: function (err) {
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    });

});

function ShowPassword(elm) {
    var pass = $(elm).attr('data-forcus');
    if ($(pass).attr('type') === "password") {
        $(pass).attr('type', 'text');
        $(elm).find('span').removeClass('fa-eye-slash').addClass('fa-eye');
    } else {
        $(pass).attr('type', 'password');
        $(elm).find('span').removeClass('fa-eye').addClass('fa-eye-slash');
    }
}