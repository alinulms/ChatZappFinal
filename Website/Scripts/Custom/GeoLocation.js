$(document).ready(function () {
    getLocation();

    var chat = $.connection.hub;

    chat.client.broadcastMessage = function (name, imageUrl, message, discussionId) {
        var encodedName = $('<div />').text(name).html();
        var encodedImageUrl = $('<div />').text(imageUrl).html();
        var encodedMsg = $('<div />').text(message).html();

        if ($('#discussionId').val() == discussionId) {
            $('#message_' + discussionId).append('<li class="list-group-item">'+'<img src="'+encodedImageUrl+'">'+'<strong>' + encodedName
              + ':</strong><br/>' + encodedMsg + '</li>');
        }
    };

    $("#message").focus();

    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            $('#error').val(BrowserDetect.browser);
            chat.server.send($('#UserName').val(), $('#UserImageUrl').val(), $('#message').val(), $('#discussionId').val(), $('#Latitude').val(), $('#Longitude').val(), BrowserDetect.browser + " " + BrowserDetect.version + " on " + BrowserDetect.OS);
            $('#message').val('').focus();
        });
    });
});

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, positionError, { enableHighAccuracy: true });
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function positionError() {
    alert('no position');
}

function showPosition(position) {
    $('#sLatitude').html(position.coords.latitude);
    $('#sLongitude').html(position.coords.longitude);
    $('#Latitude').val(position.coords.latitude);
    $('#Longitude').val(position.coords.longitude);
}

function formatCoordonates(coordonate) {
    var cleanCoordonate = coordonate.toString().replace(".", "").substr(0, 10);
    var firstPart = cleanCoordonate.substr(0, 2);
    var secondPart = cleanCoordonate.substr(3, coordonate.length);
    return firstPart + "." + secondPart;
}


