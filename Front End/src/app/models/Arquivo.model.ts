import { Loggable } from "./loggable.model";
import {Usuario} from './usuario.model';


export class Arquivo extends Loggable {
    Id: number;
    Nome: string;
    Descricao: string;
    Ext: string;
    Tipo: string;
    UsuarioId: number;
    URL:string;
    NomeCompleto: string;
    Data_Referencia: string;
    Usuario: Usuario;
}