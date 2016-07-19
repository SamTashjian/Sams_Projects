$(document)
    .ready(function() {
        $('#btnShowAddContact')
            .on('click',
                function() {
                    $('#addContactModal').modal('show');
                });

        $('#btnSaveContact')
            .on('click',
                function() {
                    var contact = {};

                    contact.Name = $('#name').val();
                    contact.PhoneNumber = $('#phonenumber').val();

                    $.post(uri, contact)
                        .done(function() {
                            loadContacts();
                            $('#addContactModal').modal('hide');
                        })
                        .fail(function(jqXhr, status, err) {
                            alert(status + ' - ' + err);
                        });
                });

        $('#addContactModal')
            .on('hidden.bs.modal',
                function() {
                    $('#name').val('');
                    $('#phonenumber').val('');
                });
    });