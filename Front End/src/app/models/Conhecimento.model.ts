import { Loggable } from "./loggable.model";
import { CategoriaConhecimento } from "./categoria-conhecimento.model";

export class Conhecimento extends Loggable {

public Id:number; 
public Nome:string; 
public CategoriaConhecimento: CategoriaConhecimento;
public CategoriaConhecimentoId: number;
 
}
     