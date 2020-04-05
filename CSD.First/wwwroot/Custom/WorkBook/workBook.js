$(document).ready(function () {
    //#region select2
    $('.select2DropDown').select2();


    $("#btnCreateWorkBook").on("click",
        function () {
            var $form = $("#createWorkBook");
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

                                type: 'success',
                                title: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/WorkBook/Index';
                            });
                            resetForm("createWorkBook");
                        }  else {
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

    $("#btnEditWorkBook").on("click",
        function () {
            var $form = $("#editWorkBook");
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

                                type: 'success',
                                text: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/WorkBook/Index';
                            });;
                            resetForm("editWorkBook");
                        } else {
                            Swal.fire({
                                title: 'Xəta',
                                type: 'warning',
                                tect: response.message,
                                showConfirmButton: true
                                //timer: 1500
                            });
                        }
                    }
                });
            }

        });
});