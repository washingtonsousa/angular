import {Pipe, PipeTransform} from '@angular/core';
import { CategoriaConhecimento } from '../models/categoria-conhecimento.model';


@Pipe({name: 'categoriaConhecimentoPipe', pure: false})
export class  CategoriaConhecimentosFilterPipe implements PipeTransform {



transform(CategoriaConhecimentos : CategoriaConhecimento[], filterQueryHandler: any) {

if(filterQueryHandler) {

                if(filterQueryHandler.Categoria != "" && filterQueryHandler.Categoria) {
                    CategoriaConhecimentos = CategoriaConhecimentos.filter(categoriaConhecimento => 
                        categoriaConhecimento.Categoria.toLowerCase()
                    .includes(filterQueryHandler.Categoria.trim().toLowerCase()));  
                }


               
            return CategoriaConhecimentos; 
        
        }
           else {

               return CategoriaConhecimentos;

           }
        }
}