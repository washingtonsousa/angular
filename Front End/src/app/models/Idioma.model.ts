import { LoggableModel } from "./LoggableModel.model";

export class IdiomaModel extends LoggableModel {
    public  Id: number; 
    public  Nome : string;
    public  Fluencia :string;
    public  UsuarioId :number;
}