function deleteWorkBook(Id) {
    Swal.fire({
        title: 'Silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonName: "İmtina et"
    }).then((result) => {
        if (result.value) {
            $.get('/WorkBook/Delete/' + Id).done(function (res) {
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
            "url": "/WorkBook/LoadDataForTable",
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
                                 <a  href='/WorkBook/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                           
                               </li>
                               <li >
                                  <a onclick="deleteWorkBook('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                }
            },
            { "data": "PersonName", "name": "A.S.A", "autoWidth": true },
            { "data": "BeginDate", "name": "Başlama Tarixi", "autoWidth": true },
            { "data": "EndDate", "name": "Bitirmə Tarixi", "autoWidth": true },
            { "data": "OrganizationName", "name": "Təşkilat", "autoWidth": true },
            { "data": "PositionName", "name": "Vəzifə", "autoWidth": true },
        ]
    });
});