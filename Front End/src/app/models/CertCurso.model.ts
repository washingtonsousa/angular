import { LoggableModel } from "./LoggableModel.model";

export class CertCursoModel extends LoggableModel {
    public  Id : number;
    public  Nome : string; 
    public  Descricao : string; 
    public  Periodo : string; 
    public  Instituicao : string; 
    public  Certificadora : string; 
    public  UsuarioId : number; 
}