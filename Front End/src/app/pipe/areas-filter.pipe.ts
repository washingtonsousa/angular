import {Pipe, PipeTransform} from '@angular/core';
import { UsuarioModel } from '../models/Usuario.model';
import { AreaModel } from '../models/Area.model';


@Pipe({name: 'areaPipe', pure: false})
export class  AreasFilterPipe implements PipeTransform {


   
transform(areas : AreaModel[], filterQueryHandler: any) {

    if(filterQueryHandler) {
    
     
                    if(filterQueryHandler.AreaNome != "" && filterQueryHandler.AreaNome) {
                        areas = areas.filter(area =>  area.Nome.toLowerCase()
                    .includes(filterQueryHandler.AreaNome.trim().toLowerCase()));  
                    }
                   
                return areas; 
            
            }
               else {
    
                   return areas;
    
               }
            }
} 