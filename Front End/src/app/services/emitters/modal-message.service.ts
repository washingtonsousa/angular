import { GlobalEmitter } from "./global-emitter";
import { ModalMessageComponent } from "src/app/custommodals/modalMessage.component";
import { DomainNotification } from "src/app/models/notification.model";
import { HttpErrorResponse } from "@angular/common/http";

export class ModalMessageService {

    public static open(Message, Title ="Aviso") {

        GlobalEmitter.emit("modal-message", {
                Title: Title,
                Message: Message
        });

    }

    public static handleHttpResponse(err: HttpErrorResponse, returnSimpleErrorMessage = true) {

       
        if(err.status == 400) {

            let notifications = <DomainNotification[]> err.error;
            this.notify(notifications);
            return;
            }

            if(returnSimpleErrorMessage)
            this.open("Operação não pode ser realizada por erro desconhecido, verifique abaixo o retorno do servidor para mais detalhes: " 
            + err.message);

    }

    public static notify(notifications: DomainNotification[]) {

        let Message = "";

        for(let notification of notifications) {
            Message += notification.Value + "<br />";
        }

        this.open(Message, "Notificações")

    }

    public static listen() {
        return GlobalEmitter.get("modal-message");
    }
}