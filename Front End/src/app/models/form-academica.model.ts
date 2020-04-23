import { Loggable } from "./loggable.model";

export class FormAcademica extends Loggable{
    public  Id : number;
    public  Instituicao : string;
    public  Curso : string;
    public  TipoCurso : string;
    public  Situacao : string;
    public  UsuarioId : number;
}