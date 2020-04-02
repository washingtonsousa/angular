import {Pipe, PipeTransform} from '@angular/core';
import { CategoriaConhecimentoModel } from '../models/CategoriaConhecimento.model';


@Pipe({name: 'categoriaConhecimentoPipe', pure: false})
export class  CategoriaConhecimentosFilterPipe implements PipeTransform {



transform(CategoriaConhecimentos : CategoriaConhecimentoModel[], filterQueryHandler: any) {

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