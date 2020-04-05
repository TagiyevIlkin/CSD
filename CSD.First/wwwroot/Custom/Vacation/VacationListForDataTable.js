function deleteVacation(Id) {
    Swal.fire({
        title: 'Silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "İmtina et",
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.value) {
            $.get('/Vacation/Delete/' + Id).done(function (res) {
                Swal.fire(
                    {
                        position: 'center',
                        type: 'success',
                        title: "Uğurla yerinə yetirildi",
                        showConfirmButton: false,
                        timer: 1500
                    }
                )
                var table = $("#dataTable").DataTable();
                table.draw();
            });
        }
    })
}

$(document).ready(function () {

    $("#dataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/Vacation/LoadDataForTable",
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
            { "data": "Status", "name": "Status", "autoWidth": true },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/Vacation/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                           
                               </li>
                               <li >
                                  <a onclick="deleteVacation('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                }
            },
            { "data": "VacationTypeName", "name": "Məzuniyyət tipi", "autoWidth": true },
            { "data": "DepartmentPositionName", "name": "Tutduğu vəzifə", "autoWidth": true },
            { "data": "PersonName", "name": "Şəxs", "autoWidth": true },
            { "data": "ReplacementPersonName", "name": "Şəxsi əvəz edəcək olan", "autoWidth": true },
            { "data": "BeginDate", "name": "Başlama tarixi", "autoWidth": true },
            { "data": "EndDate", "name": "Bitmə tarixi", "autoWidth": true }
        ]
    });
});