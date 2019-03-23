import {Pipe, PipeTransform} from '@angular/core';
import { ArquivoModel } from '../models/Arquivo.model';
import { DateTimeAdapterService } from '../adapters/dateTime.adapter';


@Pipe({name: 'arquivoPipe', pure: false})
export class  ArquivosFilterPipe implements PipeTransform {


constructor() {}


transform(arquivos : ArquivoModel[], filterQueryHandler: any) {

    if(filterQueryHandler) {

                    if(filterQueryHandler.Nome != "" && filterQueryHandler.Nome) {
                        arquivos = arquivos.filter(arquivo =>  arquivo.Nome.toLowerCase()
                    .includes(filterQueryHandler.Nome.trim().toLowerCase()));  
                    }

                    if(filterQueryHandler.UsuarioNome != "" && filterQueryHandler.UsuarioNome) {
                        arquivos = arquivos.filter(arquivo =>  arquivo.Usuario.Nome.toLowerCase()
                    .includes(filterQueryHandler.UsuarioNome.trim().toLowerCase()));  
                    }

                    if(filterQueryHandler.Data_Referencia != "" && filterQueryHandler.Data_Referencia) {
   
                        arquivos = arquivos.filter(arquivo =>  arquivo.Data_Referencia.toLowerCase()
                    .includes(filterQueryHandler.Data_Referencia.trim().toLowerCase()));  

                    }

             
                   
                return arquivos; 
            
            }
               else {
    
            return arquivos;
    
               }
            }
} 