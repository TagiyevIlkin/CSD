
$(document).on("click", '.delete', function () {

    $(this).closest('tr').remove();
});

function DeleteEducationFromView(id) {

    $.ajax({
        url: '/Education/Delete/' + id,
        contentType: false,
        processData: false,
        type: 'GET',
        success: function (response) {

            if (response.status != 200) {

                Swal.fire({
                    title: 'Xəta!',
                    type: 'error',
                    text: response.message,
                    showConfirmButton: true
                });

            } 
        }


    });
};

$(document).ready(function () {
    
    //#region Create Education

    $("#Create_Education").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["Create_Education"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    console.log(response)
                    if (response.status === 200) {

                        var markup =
                            `<tr  id="${response.Id}">
                            <td><a   onclick="DeleteEducationFromView(${response.Id})"   href="#"    class="btn btn-sm btn-danger delete ">Sil</a></td>
                            <td >${response.EducationalInstitution}</td>
                            <td >${response.EducationDegree}</td>
                            <td >${response.Faculty}</td>
                            <td >${response.Specialty}</td>
                            <td >${response.BeginTime}</td>
                            <td >${response.EndTime}</td>
                            <td >${response.CityName}</td>
                            <td >${response.DocumentName}</td>

                             </tr>`;

                        $("#dataTableForCreateEducation").append(markup);

                        //#region  reset form
                        $('#Create_Education').trigger("reset");
                        $(".customers_select").select2();
                        $(".customers_select").val(null).trigger("change");
                        //#endregion
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

    //#region Edit Education
    $("#editEducation").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editEducation"]),
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
                                window.location = '/Education/Index';
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


    //#region deleteEducationFromCreateView


    $('.deleteEducationFromCreateView').on('click', function myfunction() {

        var id = $(this).data("id");

        $.ajax({
            url: '/Education/Delete/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status == 200) {

                    $(`table#dataTableForCreateEducation tr.${id}`).remove();

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