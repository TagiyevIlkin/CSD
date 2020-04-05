$(document).ready(function () {
    //#region select2
    $('.select2DropDown').select2();


    $("#btnCreateApplicationNumber").on("click",
        function () {
            var $form = $("#createApplicationNumber");

            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {
                $.ajax({
                    url: $form.action,
                    type: "POST",
                    data: $form.serialize(),
                    success: function (response) {
                    
                        if (response.status === 200) {
                            Swal.fire(
                                {
                                    position: 'center',
                                    type: 'success',
                                    text: response.message,
                                    showConfirmButton: false,
                                    timer: 1500
                                }).then(function () {
                                    window.location = '/ApplicationNumber/Index';
                                });
                        } else {
                            Swal.fire({
                                type: 'error',
                                title:'Xəta!',
                                text: response.message,
                                showConfirmButton: true
                            });
                        }
                    }
                });
            }
 
        });



    $("#btnEditApplicationNumber").on("click",
        function () {

            var $form = $("#editApplicationNumber");
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
                                text: response.message,
                                showConfirmButton: false,
                                timer: 1500
                            }).then(function () {
                                window.location = '/ApplicationNumber/Index';
                            });;
                          
                        } else {
                            Swal.fire({
                                type: 'error',
                                title: 'Xəta!',
                                text: response.message,
                                showConfirmButton: true
                            });
                        }
                    }
                });
            }

        });
});