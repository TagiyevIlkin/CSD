
function deletePersonel(Fullname, id) {

    Swal.fire({
        title: 'Diqqət!',
        text: "İşçi  " + Fullname + "  i  " + 'silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "İmtina et",
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.value) {
            $.get('/Person/Delete/' + id).done(function (response) {

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


function deleteUser(UserName, id) {

    Swal.fire({
        title: 'Diqqət!',
        text: UserName + "  istifadəçisini  " + 'silmək istədiyinizə əminsiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "İmtina et",
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.value) {
            $.get('/User/Delete/' + id)
                .done(function (res) {
                    var table = $("#dataTable").DataTable();
                    table.draw();

                    Swal.fire({
                        type: 'success',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 2000
                    });
                }
                );
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
            "url": "/Person/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [1, 2, 14],
                "visible": false
            }],
        "columns": [
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/Person/Edit/${row.Id}'  class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                               </li>
                               <li >
                                  <a onclick="deletePersonel('${row.Fullname}','${row.Id}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                               
                            </ul>`;
                }
            }, 
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "PersonelId", "name": "Personal Id", "autoWidth": true },
            {
                "data": "UserName", "name": "Istifadəçi Adi", "autoWidth": true,
                "render": function (data, type, row) {
                    if (data == null) {

                        return `<div style="margin-top: 14%">
                                  <span class="alert alert-info text-nowrap mt-3">İstifadəci yoxdur</span>
                                </div>
                                  <hr />
                                 <button id="createUser" data-id="${row.Id}" data-toggle="modal" data-target="#createUserModal"  class="btn btn-outline-dark">
                                   <span class="ti-user"></span>
                                   <span class="icon-name">Əlavə et</span>
                                 </button>`;
                    } else {
                        return `<div style="margin-top: 14%"><span class="alert alert-info text-nowrap">${row.UserName}</span></div>
                                 <hr />
                                <ul class="d-flex justify-content-center">
                                  <li class="mr-2">
                                    <a id="editUser" data-id="${row.UserId}" data-toggle="modal" data-target="#editUserModal" class='btn text-primary btn-sm'><i class='fa fa-edit'></i></a>
                                  </li>
                                  <li >
                                     <a onclick="deleteUser('${row.UserName}','${row.UserId}')" class="btn text-danger btn-sm"><i class="fa fa-trash"></i></a>
                                  </li>
                                </ul>`;
                    }
                }
            },
            { "data": "Fullname", "name": "Ad Soyad Ata adı", "autoWidth": true },
            { "data": "Birthdate", "name": "Doğum tarixi", "autoWidth": true },
            { "data": "City", "name": "Doğum Yeri", "autoWidth": true },
            { "data": "FamilyStatus", "name": "Ailə vəziyyəti", "autoWidth": true },
            { "data": "Gender", "name": "Cins", "autoWidth": true },
            { "data": "FinCode", "name": "Fin kod", "autoWidth": true },
            { "data": "SerialNumber", "name": "Seriya", "autoWidth": true },
            { "data": "Residence", "name": "Yasayış ünvanı", "autoWidth": true },
            { "data": "Number", "name": "Nömrə", "autoWidth": true },
            { "data": "Email", "name": "Elektron Poçt", "autoWidth": true },
            { "data": "UserId", "name": "UserId", "autoWidth": true }

        ]
    });














    //#region User Create
    $(document).on("click", "#btnCreateUser",
        function () {
            var $form = $("#createUserForm");

            $.validator.unobtrusive.parse($form);
            if ($form.valid()) {
                $.ajax({
                    url: '/User/Create',
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {
                        if (response.status === 200) {
                            var table = $("#dataTable").DataTable();
                            table.draw();
                            $form[0].reset();
                            Swal.fire({
                                type: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 2000
                            });

                            $("button#closeModal").click();

                        } else {
                            Swal.fire({
                                type: 'error',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 2000
                            });
                        }
                    }
                });
            }
        });
    //#endregion

    //#region User Edit
    $(document).on("click", "#btnEditUser",
        function () {
            var $form = $("#editUserForm");
            //alert($form);
            $.validator.unobtrusive.parse($form);
            if ($form.valid()) {
                $.ajax({
                    url: '/User/Edit',
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {
                        console.log(response);
                        if (response.status === 200) {
                            var table = $("#dataTable").DataTable();
                            table.draw();
                            $form[0].reset();
                            Swal.fire({
                                type: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 2000
                            });
                            $("button#closeModal").click();

                        } else {
                            Swal.fire({
                                type: 'error',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 2000
                            });
                        }
                    }
                });
            }
        });
    //#endregion
});


//#region modal for user create


$(document).on("click",
    "#createUser",
    function () {

        var personelId = $(this).data("id");
        $.ajax({
            url: '/User/Create',
            data: { id: personelId }

        })
            .done(function (response) {



                $("#createUserModal .modal-dialog").html(response);

                var modal = $("#createUserModal .modal-dialog");
                var Username = modal.find("input[name = 'Username']");
                var Password = modal.find("input[name = 'Password']");
                Username.val('istifadəçi Adı');
                Password.val('');

                var select = modal.find("select.multipleSelect");

                $(select).select2({
                    placeholder: "səlahiyyət seçin",
                    allowClear: true,
                    width: 'resolve'
                });
            });
    });
//#endregion


//#region modal for user edit
$(document).on("click",
    "#editUser",
    function () {

        var UserId = $(this).data("id");
        $.ajax({
            url: '/User/Edit',
            data: { id: UserId }

        })
            .done(function (response) {
                $("#editUserModal .modal-dialog").html(response);

                var modal = $("#editUserModal .modal-dialog");
                var Password = modal.find("input[name = 'Password']");
                Password.val('');

                var select = modal.find("select.multipleSelect");

                $(select).select2({
                    placeholder: "səlahiyyət seçin",
                    allowClear: true,
                    width: 'resolve'
                });
            });
    });
//#endregion


