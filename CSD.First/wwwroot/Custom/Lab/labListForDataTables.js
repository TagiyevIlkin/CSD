
function deleteLab(id) {

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
            $.get('/Lab/Delete/' + id).done(function (response) {

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
                            showConfirmButton: true
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
            "url": "/Lab/LoadDataForTable",
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
                                 <a  href='/Lab/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>
                               <li >
                                  <a onclick="deleteLab('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                }
            },
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "Name", "name": "Adı", "autoWidth": true },
            { "data": "RoomNumber", "name": "Otaq nömrəsi", "autoWidth": true },
            {
                data: null, render: function (row) {
                    if (row.PicturePath == null) {
                        return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <button type='button' title='Fayl yoxdur'  disabled  style='cursor: not-allowed;'  class='btn text-primary btn-sm'><i class='fa fa-download'></i></button>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                    } else {
                        return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/Lab/DownloadFile/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-download'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                    }
                }
            },
            {
                data: null, render: function (row) {
                    if (row.PicturePath == null) {
                        return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <button type='button' title='Fayl yoxdur'  disabled  style='cursor: not-allowed;'  class='btn text-primary btn-sm'><i class='fa fa-eye'></i></button>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                    } else {
                        return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                   <a href='${ row.PicturePath}'  target="_blank"  class='btn text-primary btn-sm'><i class='fa fa-eye'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                    }
                }
            },
            { "data": "AdditionalInfo", "name": "Əlavə məlumat", "autoWidth": true }

        ]
    });

});