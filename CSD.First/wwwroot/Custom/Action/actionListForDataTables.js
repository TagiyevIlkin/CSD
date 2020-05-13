
function deleteAction(id) {

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
            $.get('/Action/Delete/' + id).done(function (response) {

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
            "url": "/Action/LoadDataForTable",
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
                                 <a  href='/Action/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>
                               <li >
                                  <a onclick="deleteAction('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;
                }
            },
            { "data": "Id", "name": "Id", "autoWidth": true },
            {
                data: null, render: function (row) {

                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                  <a id="showMore" data-id="${row.Id}" style='cursor: pointer;' data-toggle="modal" data-target="#showMoreModal" class='btn text-primary btn-sm'><i class='fa fa-eye'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                            </ul>`;

                },
            },
            { "data": "Name", "name": "Adı", "autoWidth": true },
            { "data": "Date", "name": "Tarix", "autoWidth": true },
            { "data": "BeginTime", "name": "Başlama vaxtı", "autoWidth": true },
            { "data": "EndTime", "name": "Bitmə vaxtı", "autoWidth": true }

        ]
    });

});




//#region modal for Show MoreInfo

$(document).on("click",
    "#showMore",
    function () {

        var messageId = $(this).data("id");
        $.ajax({
            url: '/Action/ShowMore',
            data: { id: messageId }

        })
            .done(function (response) {

                $("#showMoreModal .modal-dialog").html(response);
            });
    });
//#endregion