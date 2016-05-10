$(document).ready(function () {
    $('.addShow').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: "~/../../Shows/Create",
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

    $('.new-show').submit(function (event) {
        event.preventDefault();
        console.log("start");
        $.ajax({
            url: "Shows/Create",
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                //return View("Index");
                //$('#listShow').html(result.ShowTitle)
            }
        });
    });
});

function Reload()
{
    location.reload();
}
