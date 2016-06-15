$(document).ready(function () {
    // Declare a proxy to reference the hub.
    var chat = $.connection.theChatHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (username, message) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(username).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };

    // Get the user name and store it to prepend to messages.
    var name = prompt('Enter your name:', '');
    $('#displayname').val(name);
    ////document.getElementById("displayname").value = name

    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.sendMessageAndName($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});