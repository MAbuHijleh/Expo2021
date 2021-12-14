window.onafterprint = function (event) {
    location.reload();
};

function printUser(FullName, Title, Organization, Id) {
    $.ajax({
        url: "/RegistredUsers/Print/" + Id
    }).done(function (res) {
    });
    $("#FullName").text(FullName);
    $("#Title").text(Title);
    $("#Organization").text(Organization);
    window.print();
}