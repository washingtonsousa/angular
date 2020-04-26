import { GlobalEmitter } from "./global-emitter";

export class LoadingIconService {

    public static show() {
        GlobalEmitter.emit("loading-icon", true);
    }

    public static hide() {
        GlobalEmitter.emit("loading-icon", false);
    }

    public static listen() {
        return GlobalEmitter.get("loading-icon");
    }
}