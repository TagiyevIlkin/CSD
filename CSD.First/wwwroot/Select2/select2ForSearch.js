$(document).ready(function () {
    $('.select2DropDown').select2({
        placeholder: "Seçin"
    });

    $(".TopDepartmentName").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/Department", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });

    $(".OrganizationName").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/Organization", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });

    $(".PersonName").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/Personel", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });


    $(".PositionName").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/Position", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });
    
    $(".DepartmentPositionName").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/DepartmentPosition", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });

    $(".RepPerson").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/Personel", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });


    $(".PersonAndDepPositionName").select2({
        placeholder: "Axtarış...",
        allowClear: true,
        minimumInputLength: 2,  // minimumInputLength for sending ajax request to server
        width: 'resolve',   // to adjust proper width of select2 wrapped elements 
        ajax: {
            url: "/Select2/PersonelVsPosition", // Controller - Select2Demo and Action -AccessRemoteData
            type: "Get",
            dataType: 'json',
            data: function (query) {
                //console.log(query); 
                //console.log(query.term);
                return { search: query.term }
            },
            //processes the results from the JSON method and gives us the select list
            processResults: function (data) {
                //console.log(data.items);
                return {
                    results: data.items //JSON.parse()
                };
            }
        }
    });
});