var uri = '/api/contacts/';

$(document)
    .ready(function() {
        loadContacts();
    });

function loadContacts() {
    // Send Get request to WebAPI endpoint
    $.getJSON(uri)
        .done(function(data) {
            // clear the table
            $('#contacts tbody tr').remove();

            // On success, 'data' contains a list of contacts
            $.each(data,
                function(index, contact) {
                    // Add a row to the table for the contact
                    $(createRow(contact)).appendTo($('#contacts tbody'));
                });
        });
};

function createRow(contact) {
    return '<tr><td>' +
        contact.ContactID +
        '</td><td>' +
        contact.Name +
        '</td><td>' +
        contact.PhoneNumber +
        '</td></tr>';
};