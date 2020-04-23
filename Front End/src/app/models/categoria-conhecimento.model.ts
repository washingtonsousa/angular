import { Conhecimento } from "./conhecimento.model";

export class CategoriaConhecimento {
    public Id: number;
    public Categoria: string;
    public Conhecimentos: Conhecimento[];
}