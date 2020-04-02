import { UsuarioModel } from "./Usuario.model";
import { LoggableModel } from "./LoggableModel.model";

export class ResumoModel extends LoggableModel {

    public  Id : number;
    public  Conteudo : string;
    public  UsuarioId : number;

}