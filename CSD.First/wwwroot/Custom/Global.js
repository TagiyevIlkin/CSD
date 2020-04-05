$(document).ready(function() {
    $(".datePicker")
        .datepicker({
            //maxDate: 0,
            dateFormat: 'dd.mm.yy',
            changeMonth: true, //user can select months
            changeYear: true, //user can select years
            yearRange: "-70:+0" //year selection is possible from starting 70 years before now
            //showOn: "both"
        });
});