
var dataTable;
var $tableMain = $('#table_main');
var $selectSearchStatus = $('#select_search_status');
var $selectSearchNewsCategory = $('#select_search_newscategory');

$(document).ready(function () {

    //Init table
    LoadDataTable();

});

const buttonActionHtml = function (id, status, timer) {
    let html = ``;
    html += `<button type="button" class="btn btn-sm btn-outline-success " onclick="ShowEditModal(this,${id})" title="${_buttonResource.Edit}"><i class='bx bx-edit'></i></button> `;
    html += `<button type="button" class="btn btn-sm btn-outline-danger" onclick="Delete(${id})" title="${_buttonResource.Delete}" ><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></button> `;

    if (parseInt(status) != -1) {
        switch (parseInt(status)) {
            case 0: html += `<button type="button" class="btn btn-sm btn-outline-warning" id="${status}" onclick="ChangeStatus(this, event, '${id}', '${timer}')" ><i class="lni lni-lock"></i></button>`; break;
            case 1: html += `<button type="button" class="btn btn-sm btn-outline-primary" id="${status}" onclick="ChangeStatus(this, event, '${id}', '${timer}')" ><i class="lni lni-unlock"></i></button>`; break;
            default: break;
        }
    }
    return html;
}
const statusHtml = function (status) {
    let html = '';
    switch (parseInt(status)) {
        case 0: html = `<span class="badge " style="color:red">${_textOhterResource.lock}</span>`; break;
        case 1: html = `<span class="badge" style="color:blue">${_textOhterResource.active}</span>`; break;
        default: break;
    }
    return html;
}
const displayType = function (type) {
    let html = '';
    switch (type) {
        case 0: html += `<span>Giới thiệu</span>`; break;
        case 1: html += `<span>Tin tức</span>`; break;
        case 2: html += `<span>Thông báo</span>`; break;
        default: break;
    }
    return html;
}

//get data form controller
const dataParamsTable = function (method = 'GET') {
    return {
        type: method,
        url: '/News/GetList',
        data: function (d) {
            d.status = $selectSearchStatus.val();
            d.lstnewscategoryid = $selectSearchNewsCategory.val();
        },
        dataType: 'json',
        beforeSend: function () {
        },
        dataSrc: function (response) {
            console.log(response.data);
            if (CheckResponseIsSuccess(response) && response.data != null)
                return response.data;
            return [];
        },
        error: function (err) {
            CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            return [];
        }
    };
}

// create column name
const columnTable = function () {
    return [
        {
            title: "STT",
            data: null,
            render: (data, type, row, meta) => ++meta.row,
            className: "text-center font-weight-normal text-dark"

        },
        {
            data: "title",
            render: (data) => `<p class="text-truncate" style="width:250px" title="${data}">${data ?? ""}</p>`,
            className: "text-dark font-weight-normal "
        },
        {
            data: "newscategoryObj.name",
            className: "text-nowrap text-dark font-weight-normal"
        },
        {
            data: "newscategoryObj.type",
            render: (data) => displayType(data),
            className: "text-nowrap text-dark font-weight-normal"
        },
        {
            data: "avatarurl",
            render: (data, type, row, meta) => IsNullOrEmty(data) ? '' : `<img class="img img-thumbnail" src="${data}" style="width:150px;height:auto;object-fit:cover;" alt="avatar" ${_imageErrorUrl.square}' />`,
            className: "text-center text-nowrap text-dark font-weight-normal",
        },
        {
            data: "status",
            render: (data, type, row, meta) => statusHtml(data),
            className: "text-center text-dark font-weight-normal",
        },
        {
            data: "id",
            render: (data, type, row, meta) => buttonActionHtml(data, row.status, row.timer),
            orderable: false,
            searchable: false,
            className: "text-center "
        }
    ];
}

//Load table
function LoadDataTable(method = 'GET') {
    if (dataTable) dataTable.ajax.reload(null, true);
    dataTable = $tableMain.DataTable({
        search: false,
        lengthChange: true,
        lengthMenu: _lengthMenuResource,
        colReorder: { allowReorder: false },
        select: false,
        scrollY: '600px',
        scrollCollapse: true,
        stateSave: false,
        processing: true,
        responsive: { details: true },
        //get data
        ajax: dataParamsTable(method),
        rowId: "id",
        //column name
        columns: columnTable(),
        language: _languageDataTalbeObj,
        drawCallback: _dataTablePaginationStyle,
        initComplete: function () { jQuery(jQuery.fn.dataTable.tables(true)).DataTable().columns.adjust().draw(); }
    });
}

//Search 
function SearchStatus() {
    LoadDataTable();
}

//Show panel when done
function ShowPanelWhenDone(html) {
    $(window).scrollTop();
    $('#div_view_panel').html(html);
    ShowHidePanel("#div_view_panel", "#div_main_table");
}

//Reset form
function ResetForm(formElm) {
    $(formElm).trigger('reset');
    RemoveClassValidate(formElm);
}

//Show add modal
function ShowAddModal(elm) {
    let text = $(elm).html();
    $(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
    $.get(`/News/P_Add`).done(function (response) {
        $(elm).attr('disabled', false); $(elm).html(text);
        if (response.result === 0 || response.result === -1) {
            CheckResponseIsSuccess(response); return false;
        }
        ShowPanelWhenDone(response);
        $(".select2").select2();
        $('[maxlength]').maxlength({
            alwaysShow: !0,
            warningClass: "badge badge-success",
            limitReachedClass: "badge badge-danger"
        });
        $('#summernote').summernote({
            height: 600,
            placeholder: 'Nội dung',
            toolbar: [
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['height', ['height']],
                ['fontname', ['fontname']],
                ['table', ['table']],
                ['insert', ['link', 'picture', 'video']],
                ['view', ['fullscreen', 'codeview', 'help']],
            ],
        });


        $('#form_data [name="avatarurl"]').on('change', function () {
            let value = $(this).val();
            if (!value) {
                value = '/img/none_img.png';
            }
            $('#img_avatar_preview').attr('src', value);
        })
        InitSubmitAddForm();
    }).fail(function (err) {
        $(elm).attr('disabled', false); $(elm).html(text);
        CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
    });
}

//Show edit modal
function ShowEditModal(elm, id) {
    console.log(id);
    let text = $(elm).html();
    $(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
    $.get(`/News/P_Edit/${id}`).done(function (response) {
        $(elm).attr('disabled', false); $(elm).html(text);
        if (response.result === 0 || response.result === -1) {
            CheckResponseIsSuccess(response); return false;
        }
        ShowPanelWhenDone(response);
        $('.select2').select2();
        $('[maxlength]').maxlength({
            alwaysShow: !0,
            warningClass: "badge badge-success",
            limitReachedClass: "badge badge-danger"
        });
        $('#summernote').summernote({
            tabsize: 2,
            height: 600,
            placeholder: 'Nội dung',
            toolbar: [
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['height', ['height']],
                ['fontname', ['fontname']],
                ['table', ['table']],
                ['insert', ['link', 'picture', 'video']],
                ['view', ['fullscreen', 'codeview', 'help']],
            ]
        });
        let value = $('#form_data [name="avatarurl"]').val();
        console.log(value);
        $('#img_avatar_preview').attr('src', value);
        $('#form_data [name="avatarurl"]').on('change', function () {
            let value = $(this).val();
            if (!value) {
                value = '/img/none_img.png';
            }
            $('#img_avatar_preview').attr('src', value);
        })
        InitSubmitEditForm();
    }).fail(function (err) {
        $(elm).attr('disabled', false); $(elm).html(text);
        CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
    });
}

//Delete
function Delete(id) {
    swal.fire({
        title: 'Xác nhận xóa?',
        text: '',
        type: 'warning',
        showCancelButton: !0,
        confirmButtonText: "Xóa",
        cancelButtonText: "Đóng",
        confirmButtonClass: "btn btn-danger mx-1 mt-2",
        cancelButtonClass: "btn btn-outline-secondary mx-1 mt-2",
        reverseButtons: true,
        buttonsStyling: !1,
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                $.ajax({
                    type: 'POST',
                    url: '/News/Delete',
                    data: { id: id },
                    dataType: 'json',
                    success: function (response) {
                        if (!CheckResponseIsSuccess(response)) {
                            resolve(); return false;
                        }
                        ShowToastNoti('success', '', _resultActionResource.DeleteSuccess);
                        ChangeUIDelete(dataTable, id);
                        $('[maxlength]').maxlength({
                            alwaysShow: !0,
                            warningClass: "badge badge-success",
                            limitReachedClass: "badge badge-danger"
                        });
                        resolve();
                    },
                    error: function (err) {
                        CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
                        resolve();
                    }
                });
            });
        }
    });
}

//Init submit add form
function InitSubmitAddForm() {
    $('#form_data').on('submit', function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        let $formElm = $('#form_data');
        //let isvalidate = $formElm[0].checkValidity();
        let isvalidate = CheckValidationUnobtrusive($formElm);
        if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); return false; }
        let formData = new FormData($formElm[0]);
        laddaSubmitForm = Ladda.create($formElm.find('[type="submit"]')[0]);
        laddaSubmitForm.start();
        $.ajax({
            url: '/News/P_Add',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                laddaSubmitForm.stop();
                if (!CheckResponseIsSuccess(response)) return false;
                ShowToastNoti('success', '', _resultActionResource.AddSuccess);
                BackToTable('#div_main_table', '#div_view_panel');
                if (CheckNewRecordIsAcceptAddTable(response.data)) ChangeUIAdd(dataTable, response.data);

            }, error: function (err) {
                laddaSubmitForm.stop();
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    });
}

function InitSubmitEditForm() {
    $('#form_data').on('submit', function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        let $formElm = $('#form_data');
        let isvalidate = CheckValidationUnobtrusive($formElm);
        if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); return false; }
        let formData = new FormData($formElm[0]);
        $.ajax({
            url: '/News/P_Edit',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                //laddaSubmitForm.stop();
                if (!CheckResponseIsSuccess(response)) return false;
                ShowToastNoti('success', '', _resultActionResource.UpdateSuccess);
                BackToTable('#div_main_table', '#div_view_panel');
                ChangeUIEdit(dataTable, response.data.id, response.data);
            }, error: function (err) {
                //laddaSubmitForm.stop();
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    });
}

//Change status
function ChangeStatus(elm, e, id, timer) {
    if ($(elm).data('clicked')) {
        e.preventDefault();
        e.stopPropagation();
    } else {
        $(elm).data('clicked', true);//Mark to ignore next click
        window.setTimeout(() => $(elm).removeData('clicked'), 800);//Unmark after time
        $(elm).attr('onclick', "event.preventDefault();");
        $('#status_' + id).parent().find('label.btn-active').attr('onclick', 'event.preventDefault()');
        var isChecked = $('#status_' + id).is(":checked");
        var _status = $(elm).attr('id');
        $.ajax({
            type: 'POST',
            url: '/News/ChangeStatus',
            data: {
                id: id,
                status: _status == 1 ? 0 : 1,
                timer: timer
            },
            dataType: 'json',
            success: function (response) {
                if (!CheckResponseIsSuccess(response)) {
                    $(elm).attr('onclick', `ChangeStatus(this, event, ${id}, '${timer}')`); return false;
                }
                ShowToastNoti('success', '', _resultActionResource.UpdateSuccess);
                window.setTimeout(function () {
                    $(elm).attr('onclick', `ChangeStatus(this, event, ${response.data.id}, '${response.data.timer}')`);
                    ChangeUIEdit(dataTable, response.data.id, response.data);
                    $('[maxlength]').maxlength({
                        alwaysShow: !0,
                        warningClass: "badge badge-success",
                        limitReachedClass: "badge badge-danger"
                    });
                }, 500);

            }, error: function (err) {
                $(elm).attr('onclick', `ChangeStatus(this, event, ${id}, '${timer}')`);
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    }
}

//Check new record isvalid
function CheckNewRecordIsAcceptAddTable(data) {
    let condition = true; //place condition expression in here
    return condition;
}



