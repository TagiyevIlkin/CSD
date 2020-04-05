$(document).ready(function () {

    $("#btnCreateWorkPlace").on('click', function () {
        var $form = $("#createWorkPlace");
        $.validator.unobtrusive.parse($form);
        if ($form.valid()) {
            $.ajax({
                url: '/WorkPlace/Create',
                data: new FormData(document.forms["createWorkPlace"]),
                contentType: false,
                processData: false,
                type: 'POST',
                success: function (response) {
                    if (response.status === 200) {

                        Swal.fire({
                            type: 'success',
                            title: response.message.toString(),
                            showConfirmButton: false,
                            timer: 1500
                        }).then((result) => {
                            if (result) {
                                $("#returnTable").click();
                            }

                        });

                    }  else {
                        Swal.fire({
                            type: 'warning',
                            title: response.message.toString(),
                            showConfirmButton: true
                            //timer: 1500
                        });
                    }
                }



            })
        }

    });

    $("#deleteFile").on('click', function () {
        Swal.fire({
            title: 'Müqavilə faylı silinsin?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sil',
            cancelButtonText: 'İmtina et'
        }).then((response) => {
            if (response.value) {
                var url = window.location.pathname;
                var id = url.substring(url.lastIndexOf('/') + 1);
                $.get('/WorkPlace/DeleteFile/' + id).done(function (response) {
                    if (response.status === 200) {
                        Swal.fire({
                            position:'center',
                            type: 'success',
                            title: response.message.toString(),
                            timer: 2000
                        })

                    }else {
                        Swal.fire({
                            type: 'warning',
                            title: response.message.toString(),
                            showConfirmButton: true
                            //timer: 1500
                        });
                    }
                });
            }
        })
    })
});