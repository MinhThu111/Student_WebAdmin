
var dataTable;
var $tableMain = $('#table_main');
var $selectSearchStatus = $('#select_search_status');
var $selectSearchPersontype = $('#select_search_persontype');

$(document).ready(function () {

    //Init table
    LoadDataTable(); 
    
});
const viewDataHtml = function (data, id) {
    let name = id == '1' ? 'Student' : 'Teacher';
    let htmls = '';
    htmls += `<div class="col-12 col-lg-4">
							<div class="card radius-15">
								<div class="card-body">
									<div class="d-flex mb-2">
										<div>
											<p class="mb-0 font-weight-bold">${name}</p>
											<h2 class="mb-0">${data}</h2>
										</div>
										<div class="ml-auto align-self-end">
											<p class="mb-0 font-14 text-primary"><i class='bx bxs-up-arrow-circle'></i>  <span>1.01% 31 days ago</span>
											</p>
										</div>
									</div>
									<div id="chart1"></div>
								</div>
							</div>
						</div>`
                       

    return htmls;
};
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
        url: '/Home/GetList',
        data: function (d) {
        },
        dataType: 'json',
        beforeSend: function () {
            //laddaSearch.start();
        },
        dataSrc: function (response) {
            //laddaSearch.stop();
            console.log(response.data);
            if (CheckResponseIsSuccess(response) && response.data != null) {          
                return response.data;
            }
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
            data: "id",
            render: (data, type, row, meta) => data == '1' ? 'Student' : 'Teacher',
            className: "text-nowrap text-dark font-weight-normal"
        },
        {
            data: "name",
            className: "text-nowrap text-dark font-weight-normal"
        }
    ];
}

//Load table
function LoadDataTable(method = 'GET') {
    console.log("hello");
    if (dataTable) dataTable.ajax.reload(null, true);
    dataTable = $tableMain.DataTable({
        search: false,
        searching: false,
        ordering: false,
        paging: false,
        info:false,
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


