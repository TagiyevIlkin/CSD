$(document).ready(function () {
    //#region select2
    $('.select2DropDown').select2();

    $("#btnCreateVacation").on("click",
        function () {

            var $form = $("#createVacation");

            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {
                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {

                        if (response.status === 200) {
                            Swal.fire({
                                type: 'success',
                                text: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/Vacation/Index';
                            });
                            resetForm("createVacation");
                        }
                     else {
                            Swal.fire({
                                type: 'warning',
                                title: 'Xəta',
                                text: response.message,
                                showConfirmButton: true
                                //timer: 1500
                            });
                        }
                    }
                });
            }
        });

    $("#btnEditVacation").on("click",
        function () {
            var $form = $("#editVacation");

            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {
                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {

                        if (response.status === 200) {
                            Swal.fire({
                                type: 'success',
                                text: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/Vacation/Index';
                            });
                            resetForm("createVacation");
                        }
                        else {
                            Swal.fire({
                                type: 'warning',
                                title: 'Xəta',
                                text: response.message,
                                showConfirmButton: true
                                //timer: 1500
                            });
                        }
                    }
                });
            }

        });
});