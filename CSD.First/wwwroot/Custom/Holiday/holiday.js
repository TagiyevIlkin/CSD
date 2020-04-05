$(document).ready(function () {
    //#region select2
    $('.select2DropDown').select2();

    $("#btnCreateHoliday").on("click",
        function () {
            var $form = $("#createHoliday");
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
                                title: "Uğurla daxil edildi",
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/Holiday/Index';
                            });
                            resetForm("createHoliday");
                        } else {
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

    $("#btnEditHoliday").on("click",
        function () {
            var $form = $("#editHoliday");
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
                                title: "Uğurla yeniləndi",
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/Holiday/Index';
                            });;
                            resetForm("editHoliday");
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
});