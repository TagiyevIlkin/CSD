
function deletePersonApp(id) {


    Swal.fire({
        title: 'Silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'İmtina et'
    }).then((result) => {
        if (result.value == true) {
            $.get('/PersonApplication/Delete/' + id).done(function (response) {
                Swal.fire(
                    {
                        position: 'center',
                        type: 'success',
                        title: response.message,
                        showConfirmButton: false,
                        timer: 2000
                    }
                )
                var table = $("#PersonAppDataTable").DataTable();
                table.draw();
            });
        }
    })



}
$(document).ready(function () {
    $("#PersonAppDataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/PersonApplication/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false
            }],
        "columns": [
         
           
            { "data": "Id", "name": "Id", "autoWidth": true },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/PersonApplication/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                           
                               </li>
                               <li >
                                  <a onclick="deletePersonApp('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                }
            },
            { "data": "PersonFullName", "name": "A.S.A", "autoWidth": true },
            { "data": "FromDepartmentPositionName", "name": "Tərk etdiyi vəzifə", "autoWidth": true },
            { "data": "ToDepartmentPositionName", "name": "Daxil olduğu vəzifə", "autoWidth": true },
            { "data": "PersonApplicationTypeName", "name": "Ərizənin növü", "autoWidth": true },
            { "data": "Date", "name": "Tarix", "autoWidth": true }
        ]
    });
});