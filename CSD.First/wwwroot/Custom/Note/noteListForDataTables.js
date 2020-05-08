
function deleteNote(id) {

    Swal.fire({
        title: 'Diqqət!',
        text: 'İsmarıcı silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "İmtina et",
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.value) {
            $.get('/Note/Delete/' + id).done(function (response) {

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
            "url": "/Note/LoadDataForTable",
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
                                  <a id="showMessage" data-id="${row.Id}" style='cursor: pointer;' data-toggle="modal" data-target="#showMessageModal" class='btn text-primary btn-sm'><i class='fa fa-eye'></i></a>
                               </li>
                               <li >
                                  <a onclick="deleteNote('${row.Id}')"  style='cursor: pointer;' class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                }
            },
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "Name", "name": "Ad", "autoWidth": true },
            { "data": "Surname", "name": "Soyad", "autoWidth": true },
            { "data": "Title", "name": "Başlıq", "autoWidth": true },
            { "data": "Email", "name": "Email", "autoWidth": true }

        ]
    });

});

//#region modal for Show note

$(document).on("click",
    "#showMessage",
    function () {

        var messageId = $(this).data("id");
        $.ajax({
            url: '/Note/Show',
            data: { id: messageId }

        })
            .done(function (response) {

                $("#showMessageModal .modal-dialog").html(response);
            });
    });
//#endregion