import { LoggableModel } from "./LoggableModel.model";
import {DepartamentoModel} from "./Departamento.model";

export class CargoModel extends LoggableModel{

    Id: number;
    Nome: string;
    DepartamentoId: number;
    Departamento: DepartamentoModel;

}