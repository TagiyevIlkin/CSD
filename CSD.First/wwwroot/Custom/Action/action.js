

$(document).ready(function () {

    //#region Create Lab

    $("#createLab").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createLab"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    console.log(response)
                    if (response.status === 200) {

                        Swal.fire({
                            title: 'Yerinə yetirildi',
                            type: 'success',
                            text: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        }).then((result) => {
                            if (result) {
                                window.location = '/Lab/Index';
                            }
                        });                    }
                    else {
                        Swal.fire({
                            title: 'Xəta!',
                            type: 'error',
                            text: response.message,
                            showConfirmButton: true
                        });
                    }
                }
            });
        }
    });
    //#endregion
    //#region Edit Lab
    $("#editLab").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editLab"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    if (response.status === 200) {

                        Swal.fire({
                            title: 'Yerinə yetirildi',
                            type: 'success',
                            text: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        }).then((result) => {
                            if (result) {
                                window.location = '/Lab/Index';
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            title: 'Xəta!',
                            type: 'error',
                            text: response.message,
                            showConfirmButton: true
                        });
                    }
                }
            });
        }
    });
    //#endregion

    //#region deleteFile
    $('.deleteFile').on('click', function () {

        var id = $('.deleteFile').data('id');

        $.ajax({
            url: '/Lab/DeleteFile/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status === 200) {
                    $('#FileInput').val('Cari fayl--Silindi!');
                    $('#FileInput').addClass('text-danger');
                    $('#FileInput').addClass('alert');
                    $('#FileInput').addClass('alert-danger');
                } else {

                    Swal.fire({
                        title: 'Məlumat!',
                        type: 'info',
                        text: response.message,
                        showConfirmButton: true
                    });
                }
            }


        });
    });
    //#endregion
    
});

