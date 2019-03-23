import { LoggableModel } from "./LoggableModel.model";

export class ContatoModel extends LoggableModel {
    
    public  Id : number;
    public  Descricao : string;
    public  Fixo : number;
    public  Celular : number;
    public  EmailContato : string;
    public  UsuarioId : number;
    
}