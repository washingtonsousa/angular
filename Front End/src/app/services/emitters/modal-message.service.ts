import { GlobalEmitter } from "./global-emitter";
import { ModalMessageComponent } from "src/app/custommodals/modalMessage.component";

export class ModalMessageService {

    public static open(Message, Title ="Aviso") {

        GlobalEmitter.emit("modal-message", {
                Title: Title,
                Message: Message
        });

    }

    public static listen() {
        return GlobalEmitter.get("modal-message");
    }
}