
var dataTable;
var $tableMain = $('#table_main');
var $selectSearchStatus = $('#select_search_status');
var $selectSearchPersontype = $('#select_search_persontype');

$(document).ready(function () {

    //Init table
    LoadDataTable();

});
const buttonActionHtml = function (id, status, timer) {
    let html = ``;
    html += `<button type="button" class="btn btn-sm btn-outline-secondary " onclick="ShowEditModal(this,${id})" title="${_buttonResource.Edit}"><i class='bx bx-edit'></i></button> `;
    html += `<button type="button" class="btn btn-sm btn-outline-secondary" onclick="Delete(${id})" title="${_buttonResource.Delete}" ><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></button> `;
  
    if (parseInt(status) != -1) {
        switch (parseInt(status)) {
            case 0: html += `<button type="button" class="btn btn-sm btn-outline-warning text-secondary" id="${status}" onclick="ChangeStatus(this, event, '${id}', '${timer}')" ><i class="lni lni-lock"></i></button>`; break;
            case 1: html += `<button type="button" class="btn btn-sm btn-outline-secondary text-info" id="${status}" onclick="ChangeStatus(this, event, '${id}', '${timer}')" ><i class="lni lni-unlock"></i></button>`; break;
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

//get data form controller
const dataParamsTable = function (method = 'GET') {
    return {
        type: method,
        url: '/Student/GetList',
        data: function (d) {
            d.status = $selectSearchStatus.val();
            d.lstpersontypeid = $selectSearchPersontype.val();
            //console.log(d.status);
        },
        dataType: 'json',
        beforeSend: function () {
            //laddaSearch.start();
        },
        dataSrc: function (response) {
            //laddaSearch.stop();
            console.log(response.data);
            if (CheckResponseIsSuccess(response) && response.data != null)
                return response.data;
            return [];
        },
        error: function (err) {
            //laddaSearch.stop();
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
            data: "id",
            render: (data, type, row, meta) => `<a class="text-dark font-weight-normal" onclick="ShowViewModal(this, '${row.id}')" href="javascript:void(0);">${row.lastName} ${row.firstName}</a>`,
            className: "text-nowrap text-dark font-weight-normal"
        },
        {
            data: "gender",
            render: (data) => data == '0' ? 'Nam' : 'Nữ',
            className: "text-nowrap text-dark font-weight-normal"
        },
        {
            data: "birthDay",
            render: (data) => new Date(data).toLocaleDateString(),
            className: "text-nowrap text-dark font-weight-normal",
        },
        {
            data: "email",
            className: "text-nowrap text-dark font-weight-normal"
        },
        {
            data: "avatarUrl",
            render: (data, type, row, meta) => IsNullOrEmty(data) ? '' : `<img class="img img-thumbnail" src="${data}" style="width:90%;height:90%;object-fit:cover;" alt="avatar" ${_imageErrorUrl.square}' />`,
            className: "text-center text-nowrap",
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
    console.log("hello");
    if (dataTable) dataTable.ajax.reload(null, true);
    dataTable = $tableMain.DataTable({
        search: false,
        lengthChange: true,
        lengthMenu: _lengthMenuResource,
        colReorder: { allowReorder: false },
        select: false,
        scrollY: '300px',
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
    $.get(`/Student/P_Add`).done(function (response) {
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
        InitSubmitAddForm();
    }).fail(function (err) {
        $(elm).attr('disabled', false); $(elm).html(text);
        CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
    });
}

//Show edit modal
function ShowEditModal(elm, id) {
    let text = $(elm).html();
    $(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
    $.get(`/Student/P_Edit/${id}`).done(function (response) {
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
                    url: '/Student/Delete',
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
            url: '/Student/P_Add',
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
        //let isvalidate = $formElm[0].checkValidity();
        let isvalidate = CheckValidationUnobtrusive($formElm);
        if (!isvalidate) { ShowToastNoti('warning', '', _resultActionResource.PleaseWrite); return false; }
        let formData = new FormData($formElm[0]);

        //laddaSubmitForm = Ladda.create($formElm.find('[type="submit"]'));
        //laddaSubmitForm.start();
        $.ajax({
            url: '/Student/P_Edit',
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
            url: '/Student/ChangeStatus',
            data: {
                id: id,
                //status: isChecked ? 1 : 0,
                status: _status == 1 ? 0 : 1  ,
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

function LoadProvince(elm, divElm, formElm) {
    let value = $(elm).val();
    let $provinceSelect = $(formElm).find('[name="addressObj.provinceId"]');
    let $districtSelect = $(formElm).find('[name="addressObj.districtId"]');
    let $wardSelect = $(formElm).find('[name="addressObj.wardId"]');


    $districtSelect.html(FIRST_OPTION);
    $districtSelect.val('0');

    $wardSelect.html(FIRST_OPTION);
    if (parseInt(value) === 0) {
        $provinceSelect.html(FIRST_OPTION);
        $provinceSelect.attr('disabled', true);
        $districtSelect.html('');
        $districtSelect.attr('disabled', true);
        $wardSelect.html('');
        $wardSelect.attr('disabled', true);
    }
    else {
        ShowOverlay3Dot($(divElm));
        $.ajax({
            type: "GET",
            url: "/Common/GetListDropdownProvince",
            data: {
                /*countryId: value*/
            },
            dataType: 'json',
            success: function (response) {
                HideOverlay3Dot($(divElm));
                if (!CheckResponseIsSuccess(response)) return false;
                let html = '';
                $.map(response.data, function (item) {
                    html += `<option value="${item.id}">${item.name}</option>`;
                });
                $provinceSelect.html(FIRST_OPTION + html);
                $provinceSelect.attr('disabled', false);
                $provinceSelect.val($provinceSelect.children('option:not(.bs-title-option)').eq(0).val());
            },
            error: function (err) {
                HideOverlay3Dot($(divElm));
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    }
}
function LoadDistrict(elm, divElm, formElm) {
    let value = $(elm).val();
    let $districtSelect = $(formElm).find('[name="addressObj.districtId"]');
    let $wardSelect = $(formElm).find('[name="addressObj.wardId"]');

   /* $wardSelect.html(FIRST_OPTION);*/
    $wardSelect.val('0');
    if (parseInt(value) === 0) {
        $districtSelect.html('');
        $districtSelect.attr('disabled', true);
        $wardSelect.html('');
        $wardSelect.attr('disabled', true);
    } else {
        //ShowOverlay3Dot($(divElm));
        $.ajax({
            type: "GET",
            url: "/Common/GetListDropdownDistrict",
            data: {
                provinceId: value
            },
            dataType: 'json',
            success: function (response) {
                console.log(response);
                /* HideOverlay3Dot($(divElm));*/
                if (!CheckResponseIsSuccess(response)) return false;
                let html = '';
                $.map(response.data, function (item) {
                    html += `<option value="${item.id}">${item.name}</option>`;
                });
              /*  $districtSelect.html(FIRST_OPTION + html);*/
                $districtSelect.html(html);
                $districtSelect.attr('disabled', false);
                $districtSelect.val($districtSelect.children('option:not(.bs-title-option)').eq(0).val());
                $wardSelect.html('');
                $wardSelect.attr('disabled', true);
            },
            error: function (err) {
                /*  HideOverlay3Dot($(divElm));*/
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    }
}
function LoadWard(elm, divElm, formElm) {
    let value = $(elm).val();
    let $wardSelect = $(formElm).find('[name="addressObj.wardId"]');
    if (parseInt(value) === 0) {
        $wardSelect.html('');
        $wardSelect.attr('disabled', true);
    } else {
        //ShowOverlay3Dot($(divElm));
        $.ajax({
            type: "GET",
            url: "/Common/GetListDropdownWard",
            data: {
                districtId: value
            },
            dataType: 'json',
            success: function (response) {
                /* HideOverlay3Dot($(divElm));*/
                console.log(response);
                if (!CheckResponseIsSuccess(response)) return false;
                let html = '';
                $.map(response.data, function (item) {
                    html += `<option value="${item.id}">${item.name}</option>`;
                });

                $wardSelect.html(html);
                $wardSelect.attr('disabled', false);
                $wardSelect.val($wardSelect.children('option:not(.bs-title-option)').eq(0).val());
            },
            error: function (err) {
                HideOverlay3Dot($(divElm));
                CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
            }
        });
    }
}

function showPreview(elm, event) {
    var src = $(elm).attr('avatarUrl');
    console.log(src);
    //var preview = document.getElementById("file-ip-1-preview");
    //preview.src = src;
    //preview.style.display = "block";
}