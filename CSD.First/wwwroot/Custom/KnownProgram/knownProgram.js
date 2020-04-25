
$(document).on("click", '.delete', function () {

    $(this).closest('tr').remove();
});


function DeleteLanguageFromView(id) {

    $.ajax({
        url: '/KnownProgram/Delete/' + id,
        contentType: false,
        processData: false,
        type: 'GET',
        success: function (response) {
            //something in success
        }


    });
};

$(document).ready(function () {

    //#region Create KnownProgram

    $("#createKnownProgram").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createKnownProgram"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {
                    if (response.status === 200) {

                        var markup =
                            `<tr  id="${response.Id}">
                            <td><input type='button'  onclick="DeleteLanguageFromView(${response.Id})"  value='Sil'   class="btn btn-sm btn-danger delete "/></td>
                            <td >${response.Program}</td>
                            <td >${response.Level}</td>
                             </tr>`;

                        $("#dataTableForCreateKnownProgram").append(markup);

                        //#region  reset form
                        $(".customers_select").select2();
                        $(".customers_select").val(null).trigger("change");
                        //#endregion                    }
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

    //#region KnownProgram
    $("#editKnownProgram").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editKnownProgram"]),
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
                                window.location = '/KnownProgram/Index';
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


    //#region deleteLanguageFromCreateView


    $('.deleteKnownProgramFromCreateView').on('click', function myfunction() {

        var id = $(this).data("id");

        $.ajax({
            url: '/KnownProgram/Delete/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status == 200) {

                    $(`table#dataTableForCreateKnownProgram tr.${id}`).remove();

                } else {

                    Swal.fire({
                        title: 'Xəta!',
                        type: 'error',
                        text: response.message,
                        showConfirmButton: true
                    });
                }
            }


        });
    });

    //#endregion

});