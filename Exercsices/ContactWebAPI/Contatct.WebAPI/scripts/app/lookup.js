var uri = '/api/contacts/';

$(document)
    .ready(function () {
        //add a click handler for the id getContact
        $('#getContact')
            .on('click',
                function () {
                    //get the value of the field with id cotnactId
                    var id = $('#contactId').val();

                    //call the webAPI method that takes the id
                    $.getJSON(uri + id)
                        .done(function(data) {
                            //put the contact info in the paragraph with id contact
                            if (data != null) {
                                $('#contact').text(data.Name + ' - ' + data.PhoneNumber);
                            } else {
                                $('#contact').text('not found');
                            }
                        })
                        .fail(function(jqXhr, status, err) {
                            //print error
                            $('#contact').text('Error: ' + err);
                        });
                });
    });