import {Pipe, PipeTransform} from '@angular/core';
import { Usuario } from '../models/usuario.model';
import { Area } from '../models/Area.model';


@Pipe({name: 'areaPipe', pure: false})
export class  AreasFilterPipe implements PipeTransform {


   
transform(areas : Area[], filterQueryHandler: any) {

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