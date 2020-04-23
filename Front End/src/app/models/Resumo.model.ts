import { Usuario } from "./usuario.model";
import { Loggable } from "./loggable.model";

export class Resumo extends Loggable {

    public  Id : number;
    public  Conteudo : string;
    public  UsuarioId : number;

}