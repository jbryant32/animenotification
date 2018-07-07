
class windowMessaging {
    constructor() {
        $(document).ready(() => {
            this.createWorking();
           
        })

    }
    createMessageBox() {
        var mainContainer = document.createElement("")

    }
    createLoading() {

    }
   
    openMessage(msg) {
        $("#working-messaging-main-container").removeClass("working-messaging-closed").addClass("working-messaging-open");
        $("#message-conatiner span").text(msg);
    }
    closeMessage(msg) {
        $("#working-messaging-main-container").removeClass("working-messaging-open").addClass("working-messaging-closed")
        $("#message-conatiner span").text(msg);
    }
    openWorking(animationDoneEvent) {
        $("#working-messaging-main-container").removeClass("working-messaging-closed").addClass("working-messaging-open")
    }
    closeWorking(animationDoneEvent) {
        $("#working-messaging-main-container").removeClass("working-messaging-open").addClass("working-messaging-closed")
    }
    animationDone(callback) { callback(); }
    createWorking() {

        var mainContainer = document.createElement("div");
        var messageContainer = document.createElement("div");
        var spanMessage = document.createElement("span");

        spanMessage.innerText = "Working";
        messageContainer.setAttribute("id","message-conatiner")
        messageContainer.appendChild(spanMessage);
        mainContainer.setAttribute("id", "working-messaging-main-container")
        mainContainer.setAttribute("class", "working-messaging-main-container ");
        mainContainer.appendChild(messageContainer);
        document.body.appendChild(mainContainer);
      
    }



}
var windowMessage = new windowMessaging();
