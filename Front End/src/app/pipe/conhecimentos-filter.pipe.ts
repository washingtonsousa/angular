import {Pipe, PipeTransform} from '@angular/core';
import { Conhecimento } from '../models/conhecimento.model';


@Pipe({name: 'conhecimentoPipe', pure: false})
export class  ConhecimentosFilterPipe implements PipeTransform {



transform(Conhecimentos : Conhecimento[], filterQueryHandler: any) {

if(filterQueryHandler) {

                if(filterQueryHandler.Nome != "" && filterQueryHandler.Nome) {
                    Conhecimentos = Conhecimentos.filter(conhecimento => conhecimento.Nome.toLowerCase()
                    .includes(filterQueryHandler.Nome.trim().toLowerCase()));  
                }


                if(filterQueryHandler.CategoriaNome != "" && filterQueryHandler.CategoriaNome) {
                    Conhecimentos = Conhecimentos.filter(conhecimento =>  conhecimento.CategoriaConhecimento.Categoria.toLowerCase()
                .includes(filterQueryHandler.CategoriaNome.trim().toLowerCase()));  
                }
               
            return Conhecimentos; 
        
        }
           else {

               return Conhecimentos;

           }
        }
}