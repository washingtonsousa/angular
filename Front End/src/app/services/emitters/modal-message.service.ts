import { GlobalEmitter } from "./global-emitter";

export class ModalMessageService {

    public static open(params = null) {
        GlobalEmitter.emit("modal-message", params);
    }

    public static listen() {
        return GlobalEmitter.get("modal-message");
    }
}