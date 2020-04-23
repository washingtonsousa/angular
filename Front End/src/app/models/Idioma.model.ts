import { Loggable } from "./loggable.model";

export class Idioma extends Loggable {
    public  Id: number; 
    public  Nome : string;
    public  Fluencia :string;
    public  UsuarioId :number;
}