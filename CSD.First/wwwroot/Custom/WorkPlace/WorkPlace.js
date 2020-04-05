$(document).ready(function () {
    //#region Create WorkPlace

    $("#createWorkPlace").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createWorkPlace"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    if (response.status === 200) {

                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 1500
                        }).then((result) => {
                            if (result) {
                                window.location = '/WorkPlace/Index';
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: response.message.toString(),
                            showConfirmButton: true
                        });
                    }
                }
            });
        }
    });

    //#endregion    //#region Edit WorkPlace
    $('#editWorkPlace').submit(function myfunction(event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

       
        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editWorkPlace"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    if (response.status === 200) {

                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 1500
                        }).then((result) => {
                            if (result) {
                                window.location = '/WorkPlace/Index';
                            }
                        });
                    } 
                    else {
                        Swal.fire({
                            type: 'warning',
                            title: response.message.toString(),
                            showConfirmButton: true
                        });
                    }
                }
            });
        }
    });

    //#endregion

    //#region Delete File
    $("#deleteFile").on('click', function () {
        Swal.fire({
            title: 'Müqavilə faylı silinsin?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sil',
            cancelButtonText: 'İmtina et'
        }).then((response) => {
            if (response.value) {
                var url = window.location.pathname;
                var id = url.substring(url.lastIndexOf('/') + 1);
                $.get('/WorkPlace/DeleteFile/' + id).done(function (response) {
                    if (response.status === 200) {
                        Swal.fire({
                            position: 'top-end',
                            type: 'success',
                            title: response.message.toString(),
                            timer: 2000,
                            showConfirmButton: false

                        })
                    } else {
                        Swal.fire({
                            type: 'warning',
                            title: response.message.toString(),
                            showConfirmButton: true
                        });
                    }
                });
            }
        })
    })
    //#endregion
});