'use strict';
$(document).ready(function () {
    FillThreeSixtyDegreeImage();
    function FillThreeSixtyDegreeImage() {
        //let dropdown = $('#promotionType');
        //dropdown.empty();
        //dropdown.append('<option value="">Select</option>');
        //dropdown.prop('selectedIndex', 0);
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            data: '',
            url: '/Home/FillThreeSixtyDegreeImage',
            success: function (data) {
                $.each(data, function (key, entry) {
                    $('#panormaDiv').append('<div id="panorama' + key + '" style="width: 550px; height: 370px;margin-left: 20px;margin-bottom:20px;"></div>')
                    //dropdown.append($('<option></option>').attr('value', entry.Id).text(entry.Subject));
                    var fileURL = 'https://api.ayodhya-dham.in/' + entry.FilePath
                    //pannellum.viewer('panorama' + key, {
                    //    "type": "equirectangular",
                    //    "panorama": fileURL,//"@Url.Content('" + fileURL + "')",
                    //    "autoLoad": true
                    //});
                    fetch('/proxy/getimage?url=' + fileURL)
                        .then(response => response.blob())
                        .then(blob => {
                            // Handle the image blob
                            // Create a URL for the blob
                            var imageUrl = URL.createObjectURL(blob);
                            pannellum.viewer('panorama' + key, {
                                "type": "equirectangular",
                                "panorama": imageUrl,
                                "autoLoad": true
                            });
                        })
                        .catch(error => console.error('Error:', error));
                });
            },
            failure: function (response) {
                console.log(response);
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });
    }
});