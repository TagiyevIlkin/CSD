//var Popup, PosDataTable
function deletePosition(id) {


    Swal.fire({
        title: 'Silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'İmtina et'
    }).then((result) => {
        if (result.value) {
            $.get('/DepartmentPosition/Delete/' + id).done(function (res) {
                Swal.fire(
                    {
                        position: 'center',
                        type: 'success',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 1500
                    }
                )
                var table = $("#DepPosDataTable").DataTable();
                table.draw();
            });
        }
    })



}

function CheckPath() {

    return true;
}

$(document).ready(function () {

    $("#DepPosDataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/DepartmentPosition/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [0,1],
                "visible": false
            }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "MaterialResponsibilityFile", "name": "Path", "autoWidth": true },
            {
                data: null, render: function (row) {

                    if (row.MaterialResponsibilityFile != null) {
                        return `<ul class="d-flex justify-content-center">
                                <li>
                                    <a  href='/DepartmentPosition/Download/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-download'></i></a>
                               </li>

                                <li >
                                    <a  href='/DepartmentPosition/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>

                               <li >
                                  <a onclick="deletePosition('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                    }
                    else {
                        return `<ul class="d-flex justify-content-center">
                                <li>
                                    <button disabled href='/DepartmentPosition/Download/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-download'></i></button>
                               </li>

                                <li >
                                    <a disabled href='/DepartmentPosition/Edit/${row.Id}' class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>

                               <li >
                                  <a onclick="deletePosition('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                    }
                }
            },
            { "data": "PositionName", "name": "Vəzifə adı", "autoWidth": true },
            { "data": "VacationDayCount", "name": "Məzuniyyət günü sayı", "autoWidth": true },
            { "data": "PositionVacationName", "name": "PositionVacationName", "autoWidth": true },
            { "data": "DepartmentName", "name": "Şöbə adı", "autoWidth": true },
            { "data": "ContraktTypeName", "name": "Müqavilə tipi", "autoWidth": true }
        ]
    });
});