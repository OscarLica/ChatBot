$(function () {

    function GetTemplateBot(message) {
        var template = '<div class="d-flex justify-content-end mb-4">';
        template += '<div class="msg_cotainer_send">';
        template += '' + message + '';
        template += '<span class="msg_time_send">' + new Date().toLocaleDateString() + '</span>';
        template += '</div>';
        template += '<div class="img_cont_msg">';
        template += '   <img src="/img/avatar-2-64.png" class="rounded-circle user_img_msg">';
        template += '</div>';
        template += '</div>';
        return template;
    }

    function GetTemplateUser(message) {
        var template = '<div class="d-flex justify-content-start mb-4">';
        template += '<div class="img_cont_msg">';
        template += '   <img src="https://static.turbosquid.com/Preview/001292/481/WV/_D.jpg" class="rounded-circle user_img_msg">';
        template += '</div>';
        template += '<div class="msg_cotainer">';
        template += '' + message + '';
        template += '<span class="msg_time">' + new Date().toLocaleDateString() + '</span>';
        template += '</div>';
        template += '</div>';
        return template;
    }

    /*  agrega el evento click a un control tipo span*/
    $(document).on("click", "span[data-send-message]", function () {

        var message = $("#text-message").val();
        if (!message.length) return;
        SendMessage(message);
        
    });

    /**
     *  Ejecuta la petición al bot
     * @param {any} message mensaje
     */
    function SendMessage(message) {
        var content = $(".msg_card_body");
        var templateMessage = GetTemplateUser(message);

        $("#text-message").val("");
        content.append(templateMessage);

        $.get("/Home/GetIntent/" + message).then((response) => {
           
            content.append(GetTemplateBot(response.response));

            if (response.intent === "Despedida") {
                setTimeout( Clean, 5000);
            }
        });
    }

    /** limpia el cuerpo del chat */
    function Clean() {
        $(".msg_card_body").html("");
    }
});