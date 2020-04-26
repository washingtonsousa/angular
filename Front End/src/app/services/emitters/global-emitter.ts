import { EventEmitter } from "@angular/core";

export class GlobalEmitter {

    private static emitters: EventEmitter<any>[] = [];

    public static get(event) {

        if (this.emitters[event] == undefined || this.emitters[event] == null)
            this.emitters[event] = new EventEmitter<any>();

        return this.emitters[event];
    }

    public static emit(event, params = null) {

        this.get(event).emit(params);

    }

}