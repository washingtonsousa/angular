import { ConhecimentoModel } from "./Conhecimento.model";

export class CategoriaConhecimentoModel {
    public Id: number;
    public Categoria: string;
    public Conhecimentos: ConhecimentoModel[];
}