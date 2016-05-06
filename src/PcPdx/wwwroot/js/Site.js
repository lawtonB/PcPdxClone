$(document).ready(function () {
    $('.addShow').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: "~/../../Views/Shows/Create",
            success: function (result) {
                $('#showShow').html(result);
            }
        });
    });

    $('.addRoleCreate').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: "~/../../Roles/Create",
            success: function (result) {
                $('#showRoleCreate').html(result);
            }
        });
    });

    $('.addManage').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: "~/../../Roles/ManageUserRoles",
            success: function (result) {
                $('#showManage').html(result);
            }
        });
    });
});

function Reload()
{
    location.reload();
}
