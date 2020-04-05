$(document).ready(function () {
  
    //#region Create DepartmentPosition
    $("#createDepPosition").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createDepPosition"]),
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
                                window.location = '/DepartmentPosition/Index';
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
    //#endregion

    // #region Edit DepartmentPosition
    $("#editDepPosition").submit(function (event) {
        event.preventDefault();
        const action = $(this).attr("action");
        const method = $(this).attr("method");
        var $form = $(this);
        $.validator.unobtrusive.parse($form);
        if ($form.valid()) {

            $.ajax({
                url: action,
                data: new FormData(document.forms["editDepPosition"]),
                type: method,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.status == 200) {
                        Swal.fire({
                            type: "success",
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 1500
                        }).then((result) => {
                            if (result) {
                                window.location = '/DepartmentPosition/Index';
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: "error",
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
            title: 'Maddi məsuliyyət faylını silinsin?',
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
                $.get('/DepartmentPosition/DeleteFile/' + id).done(function (response) {
                    if (response.status === 200) {

                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: true
                        })

                    }
                    else {
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