
var dataTable;
var $tableMain = $('#table_main');
var $selectSearchStatus = $('#select_search_status');

$(document).ready(function () {

    //Init table
    LoadDataTable();

});

const buttonActionHtml = function (id, status, timer) {
    let html = ``;
    html += `<a href="#editEmployeeModal" class="edit" onclick="ShowEditModal(this,${id})" title="${_buttonResource.Edit}"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>`;
    html += `<a href="#deleteEmployeeModal" class="delete" onclick="Delete(${id})" title="${_buttonResource.Delete}"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>`;
    if (parseInt(status) != -1)
        html += `<label class="switch">
                      <input type="checkbox" id="status_${id}" ${parseInt(status) == 0 ? "" : "checked"} onclick="ChangeStatus(this, event, '${id}', '${timer}')">
                      <label class="slider round" for="status_${id}"></label>
                  </label>`;
    return html;
}
const statusHtml = function (status) {
    let html = '';
    switch (parseInt(status)) {
        case 0: html = `<span class="badge badge-warning" style="color:red">${_textOhterResource.lock}</span>`; break;
        case 1: html = `<span class="badge badge-success" style="color:blue">${_textOhterResource.active}</span>`; break;
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
            //console.log(d.status);
        },
        dataType: 'json',
        beforeSend: function () {
            //laddaSearch.start();
        },
        dataSrc: function (response) {
            //laddaSearch.stop();
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
            className: "text-center"
        },
        {
            data: "id",
            render: (data, type, row, meta) => `<a class="table_a_href" onclick="ShowViewModal(this, '${row.id}')" href="javascript:void(0);">${row.lastName} ${row.firstName}</a>`,
        },
        {
            data: "gender",
            render: (data) => data == '0' ? 'Male' : 'Female',
            className: "text-nowrap"
        },
        {
            data: "birthDay",
            render: (data) => new Date(data).toLocaleDateString(),
            className: "text-center text-nowrap",
        },
        {
            data: "email",
            className: "text-nowrap"
        },
<<<<<<< HEAD
        //{
        //    data: "personTypeId",
        //    className: "text-nowrap"
        //},
        //{
        //    data: "nationalityId",
        //    className: "text-nowrap"
        //},
        {
            data: "personTypeId",
            className: "text-nowrap"
        },
        {
            data: "nationalityId",
            className: "text-nowrap"
        },

        {
            data: "status",
            render: (data, type, row, meta) => statusHtml(data),
            className: "text-center text-nowrap",
        },
        {
            data: "id",
            render: (data, type, row, meta) => buttonActionHtml(data, row.status, row.timer),
            orderable: false,
            searchable: false,
            className: "text-center text-nowrap"
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
        scrollX: true,
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
    //if ($selectSearchStatus.val() === '1' || $selectSearchStatus.val() === '0') {
    //    dataTable.columns('#status').search($selectSearchStatus.val() === '1' ? 'Mở' : 'Khóa').draw();
    //}
    //else {
    //    dataTable.columns('#status').search('',true, false).draw();
    /*     dataTable.draw();*/
    //console.log('true');


    //}


}
function SearchGender() {
    LoadDataTable();
    //if ($selectSearchGender.val() === '1' || $selectSearchGender.val() === '0') {
    //    dataTable.columns('#gender').search($selectSearchGender.val() === '1' ? 'Nữ' : 'Nam').draw();
    //}
    //else {
    //    //console.log('falses');
    //    dataTable.columns('#gender').search('', true,false).draw();
    //}           
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
                if (CheckNewRecordIsAcceptAddTable(response.data)) ChangeUIAdd(dataTable, response.data); //Add row in table
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
        $.ajax({
            type: 'POST',
            url: '/Student/ChangeStatus',
            data: {
                id: id,
                status: isChecked ? 1 : 0,
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
