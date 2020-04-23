import { Loggable } from "./loggable.model";
import {Departamento} from "./departamento.model";

export class Cargo extends Loggable {

    Id: number;
    Nome: string;
    DepartamentoId: number;
    Departamento: Departamento;

}