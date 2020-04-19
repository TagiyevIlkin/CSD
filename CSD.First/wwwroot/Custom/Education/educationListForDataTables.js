
function deleteEducation(id) {

    Swal.fire({
        title: 'Diqqət!',
        text: 'Silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "İmtina et",
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.value) {
            $.get('/Education/Delete/' + id).done(function (response) {

                if (response.status = 200) {
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
                } else {
                    Swal.fire(
                        {
                            title: 'Xəta!',
                            type: 'error',
                            text: response.message,
                            showConfirmButton: true,
                            timer: 2000
                        }
                    )
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
            "url": "/Education/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [1,2],
                "visible": false
            }],
        "columns": [
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/Education/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>
                               <li >
                                  <a onclick="deleteEducation('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                }
            },
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "Status", "name": "Status", "autoWidth": true },
            { "data": "PersonelFullName", "name": "A.S.A", "autoWidth": true },
            { "data": "EducationalInstitution", "name": "Təhsil müəssisəsi", "autoWidth": true },
            { "data": "EducationDegreeName", "name": "Təhsil dərəcəsi", "autoWidth": true },
            { "data": "Faculty", "name": "Fakultə", "autoWidth": true },
            { "data": "Specialty", "name": "İxtisas", "autoWidth": true },
            { "data": "BeginTime", "name": "Başlama tarix", "autoWidth": true },
            { "data": "EndTime", "name": "Bitirmə tarixi", "autoWidth": true },
            { "data": "CityName", "name": "Şəhər/Rayon", "autoWidth": true },
            { "data": "DocumentName", "name": "Sənəd", "autoWidth": true }

        ]
    });

});