window.onbeforeprint = function (event) {
    $.ajax({
        url: "/RegistredUsers/Print/" + $("#Id").val()
    }).done(function (res) {
    });
};

window.onafterprint = function (event) {
    location.reload();
};