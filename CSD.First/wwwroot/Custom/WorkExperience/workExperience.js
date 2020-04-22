
function DeleteFromView(id) {

    $.ajax({
        url: '/WorkExperience/Delete/' + id,
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

$(document).on("click", '.delete', function () {

    $(this).closest('tr').remove();
});

$(document).ready(function () {

    //#region Create WorkExperience

    $("#createWorkExperience").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["createWorkExperience"]),
                contentType: false,
                processData: false,
                type: method,
                success: function (response) {

                    if (response.status === 200) {


                        var markup =
                            `<tr  id="${response.Id}">

                            <td><a   onclick="DeleteFromView(${response.Id})"   href="#"    class="btn btn-sm btn-danger delete ">Sil</a></td>
                            <td hidden>${response.Id}</td>
                            <td >${response.CompanyName}</td>
                            <td >${response.Position}</td>
                            <td >${response.JobResponsibilities}</td>
                            <td >${response.CityName}</td>
                            <td >${response.BeginDate}</td>
                            <td >${response.EndTme}</td>
                            <td >${response.AdditionalInfo}</td>

                             </tr>`;

                        $("#dataTableForCreateWorkExp").append(markup);

                        //#region  reset form
                        $('#createWorkExperience').trigger("reset");
                        $("#customers_select").select2();
                        $("#customers_select").val(null).trigger("change");
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

    //#region deleteWorkExperFromCreateView


    $('.deleteWorkExperFromCreateView').on('click', function myfunction() {

        var id = $(this).data("id");

        $.ajax({
            url: '/WorkExperience/Delete/' + id,
            contentType: false,
            processData: false,
            type: 'GET',
            success: function (response) {

                if (response.status == 200) {

                    $(`table#dataTableForCreateWorkExp tr.${id}`).remove();

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


    //#region Edit WorkExperience

    $("#editWorkExperience").submit(function (event) {

        event.preventDefault();

        const action = $(this).attr("action");

        const method = $(this).attr("method");

        var $form = $(this);

        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            $.ajax({
                url: action,
                data: new FormData(document.forms["editWorkExperience"]),
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
                                window.location = '/WorkExperience/Index';
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

});