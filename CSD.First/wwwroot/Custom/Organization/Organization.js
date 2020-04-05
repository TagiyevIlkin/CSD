$(document).ready(function () {

    //#region Create Organization
    $('#createOrganization').submit(function myfunction(event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createOrganization"]),
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
                                window.location = '/Organization/Index';
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

    //#region Edit Organization
    $('#editOrganization').submit(function myfunction(event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editOrganization"]),
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
                                window.location = '/Organization/Index';
                            }
                        });
                    } 
                    else  {
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
});