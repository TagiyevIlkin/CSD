
function deleteSpecialitySubject(major, id) {

    Swal.fire({
        title: 'Diqqət!',
        text: `${major} ixtisası üçün olan bütün fənləri silmək istədiyinizə əminsiniz?`,
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "İmtina et",
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.value) {
            $.get('/SpecialitySubject/DeleteAll/' + id).done(function (response) {

                if (response.status === 200) {
                    Swal.fire(
                        {
                            title: 'Yerinə yetirildi',
                            type: 'success',
                            text: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        }
                    )
                    var table = $("#dataTable").DataTable();
                    table.draw();
                } else if (response.status === 202) {
                    Swal.fire(
                        {
                            title: 'Məlumat!',
                            type: 'info',
                            text: response.message,
                            showConfirmButton: true

                        }
                    )
                } else {
                    Swal.fire(
                        {
                            title: 'Xəta!',
                            type: 'error',
                            text: response.message,
                            showConfirmButton: true
                        })
                }

            });
        }
    });
};



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
            "url": "/SpecialitySubject/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [1],
                "visible": false
            }],
        "columns": [
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/SpecialitySubject/Create/${row.Id}' title='İdarə et'  class='btn text-primary btn-sm'><i class='fa fa-tasks'></i></a>
                               </li>
                                
                               <li >
                                  <a onclick="deleteSpecialitySubject('${row.Major}','${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                }
            },
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "Code", "name": "Kodu", "autoWidth": true },
            { "data": "Major", "name": "İxtisas", "autoWidth": true },
        ]
    });

});