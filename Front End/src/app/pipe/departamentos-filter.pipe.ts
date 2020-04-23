import {Pipe, PipeTransform} from '@angular/core';
import { Departamento } from '../models/departamento.model';


@Pipe({name: 'departamentoPipe', pure: false})
export class  DepartamentosFilterPipe implements PipeTransform {



transform(Departamentos : Departamento[], filterQueryHandler: any) {

if(filterQueryHandler) {

                if(filterQueryHandler.Nome != "" && filterQueryHandler.Nome) {
                    Departamentos = Departamentos.filter(departamento => departamento.Nome.toLowerCase()
                    .includes(filterQueryHandler.Nome.trim().toLowerCase()));  
                }

                
                if(filterQueryHandler.AreaNome != "" && filterQueryHandler.AreaNome) {
                    Departamentos = Departamentos.filter(departamento =>  departamento.Area.Nome.toLowerCase()
                .includes(filterQueryHandler.AreaNome.trim().toLowerCase()));  
                }
               
            return Departamentos; 
        
        }
           else {

               return Departamentos;

           }
        }
}