$(document).ready(function () {
    //#region select2
    $('.select2DropDown').select2();

    $("#btnCreateDepartment").on("click",
        function () {

            var $form = $("#createDepartment");

            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {
                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {
                        console.log(response);

                        if (response.status === 200) {
                            Swal.fire({
                                position: 'center',
                                type: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/Department/Index';
                            });
                            resetForm("createDepartment");
                        }
                        else {
                            Swal.fire({
                                type: 'warning',
                                title: response.message,
                                showConfirmButton: true
                            });
                        }
                    }
                });
            }
        });

    $("#btnEditDepartment").on("click",
        function () {
            var $form = $("#editDepartment");

            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {

                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {
                        console.log(response);
                        if (response.status === 204) {
                            Swal.fire({
                                type: 'warning',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            });
                        }
                        else {
                            Swal.fire({
                                type: 'warning',
                                title: response.message,
                                showConfirmButton: true
                                //timer: 1500
                            });
                        }
                    }
                });
            }

        });
});