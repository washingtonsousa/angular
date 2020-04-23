import {Pipe, PipeTransform} from '@angular/core';
import { Usuario } from '../models/usuario.model';
import { Area } from '../models/Area.model';


@Pipe({name: 'logListPipe', pure: false})
export class  LogListFilterPipe implements PipeTransform {


   
transform(logs : any[], filterQueryHandler: any) {

    if(filterQueryHandler) {
    

                    if(filterQueryHandler.UsuarioNome != "" && filterQueryHandler.UsuarioNome) {
                        logs = logs.filter(log =>  log.Usuario.toLowerCase()
                    .includes(filterQueryHandler.UsuarioNome.trim().toLowerCase()));  
                    }

                    if(filterQueryHandler.DataStr != "" && filterQueryHandler.DataStr) {
                        logs = logs.filter(log =>  log.Data_Acesso.split("T")[0]
                    .includes(filterQueryHandler.DataStr.trim().toLowerCase()));  
                    }
                   
                return logs; 
            
            }
               else {
    
                   return logs;
    
               }
            }
} 