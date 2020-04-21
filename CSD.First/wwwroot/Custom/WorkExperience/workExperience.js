function DeleteFromView(id) {

    $.ajax({
        url: '/WorkExperience/Delete/' + id,
        contentType: false,
        processData: false,
        type: 'GET',
        success: function (response) {

            if (response.status == 200) {

                window.location.reload(); //Duzelmelidir! reload edilmemelidir

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
};



$(document).ready(function () {

   
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

                            <td><a   onclick="DeleteFromView(${response.Id})"   href="#"    class="btn btn-sm btn-danger delete-row">Sil</a></td>
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

    $("a.delete-row").on('click', function (event) {
        event.preventDefault();
        alert("As you can see, the link no longer took you to jquery.com");
        var href = $(this).attr('href');
        alert(href);
        $(this).closest("tr").remove(); // remove row
        return false; // prevents default behavior
    });



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


});