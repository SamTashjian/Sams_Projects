var uri = '/api/contacts';

$(document)
    .ready(function() {
        loadContacts();
    });

function loadContacts() {
    //sending get request to WebAPI endpoint
    $.getJSON(uri)
        .done(function(data) {
            //clear table
            $('#contacts tbody tr').remove();

            //on success, 'data' contains a list of contacts
            $.each(data,
                function(index, contact) {
                    //add row to the table for the contact

                    $(createRow(contact)).appendTo($('#contacts tbody'));
                });
        });
};

function createRow(contact) {
    var row = $("<tr></tr>")
        .append($("<td></td>").text(contact.ContactID))
        .append($("<td></td>").text(contact.Name))
        .append($("<td></td>").text(contact.PhoneNumber));
    return row;
    //return "<tr><td>" + contact.ContactID + "</td>" +
    //    "<td>" + contact.Name + "</td>" +
    //    "<td>" + contact.PhoneNumber + "</td>" +
    //    "</tr>";
}