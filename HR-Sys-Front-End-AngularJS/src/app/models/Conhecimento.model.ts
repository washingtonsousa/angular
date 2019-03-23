import { LoggableModel } from "./LoggableModel.model";
import { CategoriaConhecimentoModel } from "./CategoriaConhecimento.model";

export class ConhecimentoModel extends LoggableModel {

public Id:number; 
public Nome:string; 
public CategoriaConhecimento: CategoriaConhecimentoModel;
public CategoriaConhecimentoId: number;
 
}
     