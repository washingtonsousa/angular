import { Loggable } from "./loggable.model";

export class Contato extends Loggable {
    
    public  Id : number;
    public  Descricao : string;
    public  Fixo : number;
    public  Celular : number;
    public  EmailContato : string;
    public  UsuarioId : number;
    
}