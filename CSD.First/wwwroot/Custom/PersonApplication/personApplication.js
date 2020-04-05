$(document).ready(function () {
  
    $("#btnCreatePersonApp").on('click', function () {
        var $form = $("#createPersonApp");
        $.validator.unobtrusive.parse($form);
        if ($form.valid()) {
            $.ajax({
                url: '/PersonApplication/Create',
                data: new FormData(document.forms["createPersonApp"]),
                contentType: false,
                processData: false,
                type: 'POST',
                success: function (response) {
                    if (response.status === 200) {

                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 1500
                        }).then((result) => {
                            if (result) {
                                window.location = '/PersonApplication/Index';

                            }
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

    $('#btnEditPersonApp').on('click', function (evt) {
        var $form = $("#editPersonApp");
        $.validator.unobtrusive.parse($form);
        if ($form.valid()) {
            $.ajax({
                url: '/PersonApplication/Edit',
                data: new FormData(document.forms["editPersonApp"]),
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
                        }).then((result) => {
                            if (result) {
                                window.location = '/PersonApplication/Index';
                            }
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
            });
        }

    });
})