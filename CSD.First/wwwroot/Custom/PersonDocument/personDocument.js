
$(document).on("click", '.delete', function () {

    $(this).closest('tr').remove();
});

function DeletePersonDocumentFromView(id) {

    $.ajax({
        url: '/PersonDocument/Delete/' + id,
        contentType: false,
        processData: false,
        type: 'GET',
        success: function (response) {

            if (response.status != 200) {
                //something in success
            }
        }


    });
};

$(document).ready(function () {

    //#region Create PersonDocument

    $("#createPersonDocument").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createPersonDocument"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    console.log(response)
                    if (response.status === 200) {

                        var markup =
                            `<tr  id="${response.Id}">
                            <td><input type='button'  onclick="DeletePersonDocumentFromView(${response.Id})"  value='Sil'   class="btn btn-sm btn-danger delete "/></td>
                            <td >${response.FileName}</td>
                            <td >${response.DocumentTypeName}</td>
                             </tr>`;

                        $("#dataTableForCreatePersonDocument").append(markup);

                        //#region  reset form
                        $(".customers_select").select2();
                        $(".customers_select").val(null).trigger("change");
                        $("#fileopen").val('');
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

    //#region Edit PersonDocument

    $("#editPersonDocument").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editPersonDocument"]),
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
                                window.location = '/PersonDocument/Index';
                            }
                        });
                    }
                    else if (response.status === 202) {
                        Swal.fire({
                            title: 'Xəbərdarlıq!',
                            type: 'info',
                            text: response.message,
                            showConfirmButton: true
                        });
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
        }
    });
    //#endregion


    //#region deletePreviousFile
    $('.deletePreviousFile').on('click', function () {

        var id = $('.deletePreviousFile').data('id');

        $.ajax({
            url: '/PersonDocument/DeleteFile/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status === 200) {
                    $('#FileInput').val('Silindi!');
                    $('#FileInput').addClass('text-danger');
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

    //#region deletePersonDocumentFromCreateView

    $('.deletePersonDocumentFromCreateView').on('click', function myfunction() {

        var id = $(this).data("id");

        $.ajax({
            url: '/PersonDocument/Delete/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status == 200) {

                    $(`table#dataTableForCreatePersonDocument tr.${id}`).remove();

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