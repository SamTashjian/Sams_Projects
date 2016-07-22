/// <reference path="../jquery-1.10.2.js" />
$(document)
    .ready(function () {
        $('#SelectedCategory')
            .on('change',
                function (e) {
                    console.log(e);

                    var chosenCat = e.target.value;
                    window.location.href = '/Admin/ManagePoliciesByCat?chosenCat=' + chosenCat;
                });
    });