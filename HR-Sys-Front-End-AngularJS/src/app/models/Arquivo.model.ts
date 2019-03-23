import { LoggableModel } from "./LoggableModel.model";
import {UsuarioModel} from './Usuario.model';


export class ArquivoModel extends LoggableModel {
    Id: number;
    Nome: string;
    Descricao: string;
    Ext: string;
    Tipo: string;
    UsuarioId: number;
    URL:string;
    NomeCompleto: string;
    Data_Referencia: string;
    Usuario: UsuarioModel;
}