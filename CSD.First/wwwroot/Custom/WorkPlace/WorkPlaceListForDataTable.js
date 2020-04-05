function deleteWorkPlace(id) {


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
            $.get('/WorkPlace/Delete/' + id).done(function (res) {
                Swal.fire(
                    {
                        position: 'center',
                        type: 'success',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 2000
                    }
                )
                var table = $("#WorkPlaceDataTable").DataTable();
                table.draw();
            });
        }
    })



}

$(document).ready(function () {

    $("#WorkPlaceDataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/WorkPlace/LoadDataForTable",
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
            { "data": "Contact", "name": "Müqavilə", "autoWidth": true },
            {
                data: null, render: function (row) {

                    if (row.Contact != null) {

                        return `<ul class="d-flex justify-content-center">
                                <li>
                                    <a  href='/WorkPlace/Download/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-download'></i></a>
                               </li>
                                <li >
                                    <a  href='/WorkPlace/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>

                               <li >
                                  <a onclick="deleteWorkPlace('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                                 
                            </ul>`;
                    } else {
                        return `<ul class="d-flex justify-content-center">
                                <li>
                                    <button disabled  class='btn text-primary btn-sm'><i class='fa fa-download'></i></button>
                               </li>
                                <li >
                                    <a  href='/WorkPlace/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>

                               <li >
                                  <a onclick="deleteWorkPlace('${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                                 
                            </ul>`;
                    }
                }
            },
            {
                "data": "Status", "name": "status", "autoWidth": true,
                "render": function (data, type, row) {
                    if (data == false) {

                        return `<div class="mt-2">
                                  <span class="alert alert-info text-nowrap">Xitam verilib!</span>
                                </div>
                               `;
                    } else {
                        return `<button id="terminateWorkPlace" data-id="${row.Id}" data-toggle="modal" data-target="#createWPHModal"  class="btn btn-outline-dark">
                                   <span><i class="fa fa-stop text-danger  mr-2" ></i>Xitam ver</span>
                                 </button>`;
                    }
                }
            },
            { "data": "PersonelFullName", "name": "A.S.A", "autoWidth": true },
            { "data": "DepartmentPositionName", "name": "Vəzifə adı", "autoWidth": true },
            { "data": "ContactNumber", "name": "Müqavilə nömrəsi", "autoWidth": true },
            { "data": "JoinDate", "name": "İşə başladığı vaxt", "autoWidth": true }
        ]


    });

    //#region modal for terminate WorkPlace

    $(document).on("click", "#terminateWorkPlace", function () {
      

            var personelId = $(this).data("id");
            $.ajax({
                url: `/WorkPlaceHistory/Create/${personelId}`,
            }) .done(function (response) {
               $("#createWPHModal .modal-dialog").html(response);
                });
        });


    $(document).on("click", "#btnCreateWorkPlaceHistory", function () {

      

            $.ajax({

                url: '/WorkPlaceHistory/Create',
                data: new FormData(document.forms["createWorkPlaceHistory"]),
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

                        })

                        var table = $("#WorkPlaceDataTable").DataTable();
                        table.draw();

                        $("#closeModal").click();


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

    });


    //#endregion      
});