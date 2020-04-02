import {Pipe, PipeTransform} from '@angular/core';
import { CargoModel } from '../models/Cargo.model';


@Pipe({name: 'cargoPipe', pure: false})
export class  CargosFilterPipe implements PipeTransform {



transform(Cargos : CargoModel[], filterQueryHandler: any) {

if(filterQueryHandler) {

                if(filterQueryHandler.Nome != "" && filterQueryHandler.Nome) {
                    Cargos = Cargos.filter(cargo => cargo.Nome.toLowerCase()
                    .includes(filterQueryHandler.Nome.trim().toLowerCase()));  
                }

                
                if(filterQueryHandler.DepartamentoNome != "" && filterQueryHandler.DepartamentoNome) {
                    Cargos = Cargos.filter(cargo =>  cargo.Departamento.Nome.toLowerCase()
                .includes(filterQueryHandler.DepartamentoNome.trim().toLowerCase()));  
                }


                if(filterQueryHandler.AreaNome != "" && filterQueryHandler.AreaNome) {
                    Cargos = Cargos.filter(cargo =>  cargo.Departamento.Area.Nome.toLowerCase()
                .includes(filterQueryHandler.AreaNome.trim().toLowerCase()));  
                }
               
            return Cargos; 
        
        }
           else {

               return Cargos;

           }
        }
}