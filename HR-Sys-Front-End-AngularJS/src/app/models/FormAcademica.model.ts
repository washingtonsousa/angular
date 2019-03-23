import { LoggableModel } from "./LoggableModel.model";

export class FormAcademicaModel extends LoggableModel{
    public  Id : number;
    public  Instituicao : string;
    public  Curso : string;
    public  TipoCurso : string;
    public  Situacao : string;
    public  UsuarioId : number;
}