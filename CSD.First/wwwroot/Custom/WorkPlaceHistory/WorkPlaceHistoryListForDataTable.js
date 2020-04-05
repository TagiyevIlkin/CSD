function deleteWorkPlaceHistory(id) {

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
            $.get('/WorkPlaceHistory/Delete/' + id).done(function (res) {
                Swal.fire(
                    {
                        position: 'top-end',
                        type: 'success',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 2000
                    }
                )
                var table = $("#WorkPlaceHistoryDataTable").DataTable();
                table.draw();
            });
        }
    })



}

$(document).ready(function () {

    $("#WorkPlaceHistoryDataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/WorkPlaceHistory/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [0, 1],
                "visible": false
            }],
        "columns": [

            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "Termination", "name": "Xitam", "autoWidth": true },
            {
                data: null, render: function (row) {

                    if (row.Termination != null) {

                        return `<ul class="d-flex justify-content-center">
                                <li>
                                    <a  href='/WorkPlaceHistory/Download/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-download'></i></a>
                               </li>

                               <li>
                              <a href='#' class="btn text-primary btn-sm" id = "editWorkPlaceHistoryUI" data-id="${row.Id}" data-toggle="modal" data-target="#editWPHModal"  class="btn btn-sm btn-outline-secondary" >
                               <span><i class="fa fa-edit text-primary  mr-2" ></i></span>
                                 </a >
                            </li>

                               <li >
                                  <a onclick="deleteWorkPlaceHistory('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                    } else {
                        return `<ul class="d-flex justify-content-center">
                                <li>
                                    <button disabled  class='btn text-primary btn-sm'><i class='fa fa-download'></i></button>
                               </li>

                               <li>
                              <button class="border-0 mt-2 bg-white" id = "editWorkPlaceHistoryUI" data-id="${row.Id}" data-toggle="modal" data-target="#editWPHModal"  class="btn btn-sm btn-outline-secondary" >
                               <span class="bg-white border-0 " ><i class="fa fa-edit text-primary  mr-2" ></i></span>
                                 </button >
                            </li>

                               <li >
                                  <a onclick="deleteWorkPlaceHistory('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>`;
                    }
                }
            },
            { "data": "PersonelFullName", "name": "A.S.A", "autoWidth": true },
            { "data": "DepartmentPositionName", "name": "Vəzifə adı", "autoWidth": true },
            { "data": "ContactNumber", "name": "Müqavilə nömrəsi", "autoWidth": true },
            { "data": "TerminationNumber", "name": "Xitam nömrəsi", "autoWidth": true },
            { "data": "JoinDate", "name": "İşə başladığı vaxt", "autoWidth": true },
            { "data": "ExitDate", "name": "Xitam verildiyi vaxt", "autoWidth": true }
        ]


    });


    //#region modal for terminate WorkPlace

    $(document).on("click", "#editWorkPlaceHistoryUI", function () {


        var personelId = $(this).data("id");
        $.ajax({
            url: `/WorkPlaceHistory/Edit/${personelId}`,
        }).done(function (response) {
            $("#editWPHModal .modal-dialog").html(response);
        });
    });



    $(document).on("click", "#btnEditWorkPlaceHistory",

        function () {
            var $form = $("#editWorkPlaceHistory");
            $.validator.unobtrusive.parse($form);
            if ($form.valid()) {
                $.ajax({

                    url: '/WorkPlaceHistory/Edit',
                    data: new FormData(document.forms["editWorkPlaceHistory"]),
                    contentType: false,
                    processData: false,
                    type: 'POST',
                    success: function (response) {
                        if (response.status === 200) {

                            Swal.fire({
                                type: 'success',
                                title: response.message.toString(),
                                showConfirmButton: true
                                //timer: 1500
                            }).then((result) => {
                                if (result) {

                                    window.location = 'WorkPlaceHistory/Index';
                                }

                            });

                        } else if (response.status === 406) {
                            Swal.fire({
                                type: 'error',
                                title: response.message.toString(),
                                showConfirmButton: true,
                                timer: 2000
                            });
                        } else if (response.status === 204) {
                            Swal.fire({
                                type: 'warning',
                                title: response.message.toString(),
                                showConfirmButton: true
                                //timer: 1500
                            });
                        }
                        else if (response.status === 205) {
                            Swal.fire({
                                position: 'top-end',
                                type: 'info',
                                showConfirmButton: false,
                                title: response.message.toString(),
                                timer: 2000
                            });
                        } else {
                            Swal.fire({
                                type: 'warning',
                                title: response.message.toString(),
                                showConfirmButton: true
                                //timer: 1500
                            });
                        }
                    }



                })
            }
        });


});


    //#endregion

     