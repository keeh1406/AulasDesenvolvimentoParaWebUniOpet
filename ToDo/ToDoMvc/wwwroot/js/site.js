// Write your JavaScript code.
$(document).ready(function () {
    $('#add-item-button').on('click', addItems);

    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    })
});


function addItems() {
    $('#add-item-error').hide();
    var newTitle = $('#add-item-title').val();

    var data = { title: newTitle };
    $.post('ToDo/AddItem', data, function () {
        window.location = '/ToDo';
    }).fail(function (data) {
        if (!data || !data.responseJSON) {
            return;
        }
        var key = Object.keys(data.responseJSON)[0];
        var firstError = data.responseJSON[key];
        $('#add-item-error').text(firstError).show();
    });
}

function markCompleted(checkbox) {
    checkbox.disabled = true;

    var data = { id: checkbox.name };
    $.post('/ToDo/MarkDone', data, function () {
        var row = checkbox
            .parentElement
            .parentElement;
        $(row).addClass('done');
    })
}
