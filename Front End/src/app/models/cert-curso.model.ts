import { Loggable } from "./loggable.model";

export class CertCurso extends Loggable {
    public  Id : number;
    public  Nome : string; 
    public  Descricao : string; 
    public  Periodo : string; 
    public  Instituicao : string; 
    public  Certificadora : string; 
    public  UsuarioId : number; 
}