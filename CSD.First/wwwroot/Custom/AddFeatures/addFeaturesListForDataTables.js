

$(document).ready(function () {

    $("#dataTable").DataTable({
        "language": {
            "url": "/DataTables/Azerbaijan.json"
        },
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "ajax": {
            "url": "/AddFeatures/LoadDataForTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false
            }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "PersonFullName", "name": "A.S.A", "autoWidth": true },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li class="mr-2">
                                 <a  href='/Education/Create/${row.Id}' title='Təhsil əlavə et'  class='btn text-primary btn-sm'><i class='fa fa-graduation-cap'></i></a>
                               </li> 
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                               
                            </ul>`;
                }
            },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                              <li class="mr-2">
                                 <a  href='/Language/Create/${row.Id}' title='Dil əlavə et' class='btn text-primary btn-sm'><i class='fa fa-language'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                               
                            </ul>`;
                }
            },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li >
                                   <a  href='/WorkExperience/Create/${row.Id}' title='İş təcrübəsi əlavə et'  class='btn text-primary btn-sm'><i class='fa fa-briefcase'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                               
                            </ul>`;
                }
            },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li >
                                   <a  href='/KnownProgram/Create/${row.Id}' title='İş təcrübəsi əlavə et'  class='btn text-primary btn-sm'><i class='fa fa-code'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                               
                            </ul>`;
                }
            },
            {
                data: null, render: function (row) {
                    return `<ul class="d-flex justify-content-center">
                               <li >
                                   <a  href='/PersonDocument/Create/${row.Id}' title='İş təcrübəsi əlavə et'  class='btn text-primary btn-sm'><i class='fa fa-file'></i></a>
                               </li>
                            </ul>
                            <hr />
                            <ul class="d-flex justify-content-center">
                               
                            </ul>`;
                }
            }

        ]
    });

});