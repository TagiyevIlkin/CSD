
$(document).on("click", '.delete', function () {

    $(this).closest('tr').remove();
});

$(document).on("click", '.deleteSpecialitySubjectFromCreateView', function () {

    $(this).closest('tr').remove();
});

function DeleteSpecialitySubjectFromView(id) {

    $.ajax({
        url: '/SpecialitySubject/Delete/' + id,
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

    //#region Create SpecialitySubject

    $("#createSpecialitySubject").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createSpecialitySubject"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    console.log(response)
                    if (response.status === 200) {

                        var markup =
                        `<tr  id="${response.Id}">
                            <td><input type='button'  onclick="DeleteSpecialitySubjectFromView(${response.Id})"  value='Sil'   class="btn btn-sm btn-danger delete "/></td>
                            <td >${response.Subject}</td>
                            <td >${response.Credit}</td>
                             </tr>`;

                        var CurrentdataTable = '#dataTableForCreateSpecialitySubject' + response.SemesterId;

                        $(CurrentdataTable).append(markup);
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

    //#region Edit Language
    $("#editLanguage").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editLanguage"]),
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
                                window.location = '/Language/Index';
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


    $('.deleteSpecialitySubjectFromCreateView').on('click', function myfunction() {

        var id = $(this).data("id");

        $.ajax({
            url: '/SpecialitySubject/Delete/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status == 200) {

                    //something in success

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