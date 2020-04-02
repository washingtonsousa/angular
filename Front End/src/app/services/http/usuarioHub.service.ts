import { Injectable } from "@angular/core";
import { SignalRHubTemplate } from "./SignalRHubTemplate";

@Injectable()
export class UsuarioHubService extends SignalRHubTemplate {


constructor() {
    super();
    this.createProxyHub("UsuariosHub");
}

}