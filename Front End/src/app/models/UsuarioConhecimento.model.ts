import { LoggableModel } from "./LoggableModel.model";
import { ConhecimentoModel } from './Conhecimento.model';

export class UsuarioConhecimentoModel extends LoggableModel{

  Id : number ;
  UsuarioId: number ;
  ConhecimentoId: number;
  Conhecimento: ConhecimentoModel; 
}