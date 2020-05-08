
$(document).ready(function () {

    //#region Create Message

    $("#createMessage").submit(function (event) {

        event.preventDefault();

        const action = "Contact/GetMessage";

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createMessage"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    console.log(response)
                    if (response.status === 200) {

                        Swal.fire({
                            title: 'Məlumat!',
                            type: 'info',
                            text: response.message,
                            showConfirmButton: true
                        });                        $('#createMessage').trigger("reset");                    }
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

});