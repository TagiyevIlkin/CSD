
function deleteOrganization(id) {

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
            $.get('/Organization/Delete/' + id).done(function (res) {
                Swal.fire({
                    position: 'center',
                    type: 'success',
                    title:res.message,
                    showConfirmButton: false,
                    timer: 1500
               } )
                var table = $("#OrganizationDataTable").DataTable();
                table.draw();
            });
        }
    })
}


$(document).ready(function () {
    $("#OrganizationDataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/Organization/LoadDataForTable",
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
                                 <a  href='/Organization/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                           
                               </li>
                               <li >
                                  <a onclick="deleteOrganization('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                }
            },
            { "data": "Name", "name": "Təşkilatın adı", "autoWidth": true },
            { "data": "OrganizationLegalFormName", "name": "Təşkilatın qanuni forması", "autoWidth": true },
            { "data": "OrganizationLegalTypeName", "name": "Təşkilatın qanuni tipi", "autoWidth": true },
            { "data": "TopOrganizationName", "name": "Yuxarı təşkilat", "autoWidth": true },
            { "data": "ShortName", "name": "Abreviatura", "autoWidth": true },
            { "data": "MobileNumber", "name": "Mobil nömrə", "autoWidth": true },
            { "data": "Email", "name": "Email", "autoWidth": true },
            { "data": "Fax", "name": "Faks", "autoWidth": true },
            { "data": "VORN", "name": "VÖEN", "autoWidth": true },
            { "data": "Index", "name": "İndeks", "autoWidth": true }   
        ]
    });
});