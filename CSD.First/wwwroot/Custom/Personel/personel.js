

$(document).ready(function () {
    //#region select2

    

    //#region Personel Create
    $("#btnCreatePerson").on("click",
        function() {
            var $form = $("#createPersonel");
            $.validator.unobtrusive.parse($form);
            if ($form.valid()) {
                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function(response) {
                        //console.log(response);
                        if (response.status === 200) {

                            $form[0].reset();
                            Swal.fire({
                                type: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 2000
                            });
                            var personelId = response.personelId;
                            $("input[name='PersonelFile.PersonelId']").val(personelId);
                            $("a#pop2-tab").click();
                        } else if (response.status === 204) {
                            Swal.fire({
                                type: 'error',
                                title: 'Xəta',
                                text: response.message,
                                showConfirmButton: true
                            });
                        } else {
                            Swal.fire({
                                type: 'error',
                                title: 'Xəta',
                                text: response.message,
                                showConfirmButton: true
                            });
                        }
                    }
                });
            }
        });
    //#endregion

    //#region Personel Edit
    $("#btnEditPerson").on("click",
        function () {
            var $form = $("#editPersonel");
            $.validator.unobtrusive.parse($form);
            if ($form.valid()) {
                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {
                        console.log(response);
                        if (response.status === 200) {

                            //$form[0].reset();
                            Swal.fire({
                                type: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 2000
                            });
                            var personelId = response.personelId;
                            $("input[name='PersonelFile.PersonelId']").val(personelId);
                            $("a#pop1-tab").click();
                        } else if (response.status === 204) {
                            Swal.fire({
                                type: 'error',
                                title: 'Xəta',
                                text: response.message,
                                showConfirmButton: true
                            });
                        } else {
                            Swal.fire({
                                type: 'error',
                                title: 'Xəta',
                                text: response.message,
                                showConfirmButton: true
                            });
                        }
                    }
                });
            }
        });
    //#endregion

    //#region CreatePersonFile
    $("#btnCreatePersonFile").on("click",
        function() {
            $.ajax({
                url: '/Personel/CreateFile',
                data: new FormData(document.forms["createPersonelFilesform"]),
                contentType: false,
                processData: false,
                type: 'POST',
                success: function(response) {
                    console.log(response);

                    if (response.status === 200) {
                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 2000
                        }).then(function () {
                            window.location = '/Personel/Index';
                        });
                    } else if (response.status === 400) {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    } else if (response.status === 406) {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    } else {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    }
                }
            });
        });
    //#endregion

    //#region EditPersonFile
    $("#btnEditPersonFile").on("click",
        function () {
            $.ajax({
                url: '/Personel/EditFile',
                data: new FormData(document.forms["editPersonelFilesform"]),
                contentType: false,
                processData: false,
                type: 'POST',
                success: function (response) {
                    console.log(response);

                    if (response.status === 200) {
                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 2000
                        })
                        .then(function () {
                            window.location = '/Personel/Index';
                        });
                    } else if (response.status === 400) {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    } else if (response.status === 401) {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    } else if (response.status === 406) {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    } else {
                        Swal.fire({
                            type: 'error',
                            title: 'Xəta',
                            text: response.message,
                            showConfirmButton: true
                        });
                    }
                }
            });
        });
    //#endregion

    //#region Delete File
    $(".deleteFiles").on('click',
        function (e) {
            e.preventDefault();

            var button = $(this);
            var id = $(this).data("id");
            var parent = $(this).parent().parent();
            var downloadButton = parent.find("a.downloadFiles");
            
            if (id > 0) {
                Swal.fire({
                    title: 'Fayl silinsin?',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Sil',
                    cancelButtonText: 'İmtina et'
                }).then((response) => {
                    if (response.value) {
                        $.ajax({
                            url: '/Personel/DeleteFile/' + id,
                            success: function (res) {
                                if (res.status === 200) {
                                    Swal.fire({
                                        type: 'success',
                                        title: res.message.toString(),
                                        showConfirmButton: false,
                                        timer: 1500
                                    });

                                    
                                    button.addClass("disabled");
                                    downloadButton.addClass("disabled");

                                } else if (res.status === 406) {
                                    Swal.fire({
                                        type: 'error',
                                        title: 'Xəta',
                                        text: response.message,
                                        showConfirmButton: true
                                    });
                                   
                                } else {
                                    Swal.fire({
                                        type: 'error',
                                        title: 'Xəta',
                                        text: response.message,
                                        showConfirmButton: true
                                    });
                                    
                                }
                            }
                        });
                    }
                });
            }

        });
    //#endregion
});


//$(".btnDownload").on("click",
//    function() {
//        var fileid = $(this).data("fileid");
//        $.ajax({
//            url: '/Personel/Download',
//            data: { fileId: fileid},
//            success: function (response) {

//                if (res.status === 200) {
//                    console.log(response.message);
//                }

//            }
//        });
//    });