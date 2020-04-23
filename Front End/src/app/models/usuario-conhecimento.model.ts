import { Loggable } from "./loggable.model";
import { Conhecimento } from './conhecimento.model';

export class UsuarioConhecimento extends Loggable{

  Id : number ;
  UsuarioId: number ;
  ConhecimentoId: number;
  Conhecimento: Conhecimento; 
}