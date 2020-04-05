$(document).ready(function () {
    //#region select2
    $('.select2DropDown').select2();

    $("#btnCreatePositionTable").on("click",
        function () {
            var $form = $("#createPositionTable");
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
                                window.location = '/PositionTable/Index';
                            });
                            resetForm("createPositionTable");
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

    $("#btnEditPositionTable").on("click",
        function () {

            var $form = $("#editPositionTable");

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
                                window.location = '/PositionTable/Index';
                            });;
                            resetForm("editPositionTable");
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

    function TimeFormat(s) {
        var v = s.value;
        if (v.match(/^\d{2}$/) !== null) {
            s.value = v + ':';
        } else if (v.match(/^\d{2}\/\d{2}$/) !== null) {
            s.value = v + ':';
        }
    }


});