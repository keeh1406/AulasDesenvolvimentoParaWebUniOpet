// Write your JavaScript code.
$(document).ready(function () {
    $('#add-item-button')
        .on('click', addItems);

    $('.done-checkbox')
        .on('click', function (event) {
            markCompleted(event.target);
        });
});

function addItems() {
    $('#add-item-error').hide();
    var newTitle = $('#add-item-title').val();
    var newDueAt = $('#add-item-due-at').val();

    var data = {
        title: newTitle,
        dueAt: newDueAt
    };
    $.post('ToDo/AddItem', data, function () {
        window.location = '/ToDo';
    })
    .fail(function (data) {
        if (data && data.responseJSON) {
            var key = Object
                .keys(data.responseJSON)[0];
            var firstError = data
                .responseJSON[key];
            $('#add-item-error')
                .text(firstError)
                .show();
        }
    });
}

function markCompleted(checkbox) {
    checkbox.disabled = true;

    var data = { id: checkbox.name };
    $.post('ToDo/MarkDone', data, function () {
        var row = checkbox  // a partir do checkbox
            .parentElement  // acessamos a td
            .parentElement; // acessamos a tr
        $(row).addClass('done');
    });
}