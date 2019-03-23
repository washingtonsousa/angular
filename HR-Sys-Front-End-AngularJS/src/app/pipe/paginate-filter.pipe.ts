import {Pipe, PipeTransform} from '@angular/core';


@Pipe({name: 'paginatePipe', pure: false})
export class  PaginateFilterPipe implements PipeTransform {
   
transform(data : any[], nameQuery: any) {

    if(nameQuery) {
    
        let TotalPages = Math.ceil(data.length / nameQuery.limit);


        console.log(TotalPages);

                data = data.slice(nameQuery.start, nameQuery.end);
                   
                return data; 
            
            }
               else {
    
                   return data;
    
               }
            }
} 