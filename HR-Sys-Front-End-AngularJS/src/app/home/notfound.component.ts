import {Component} from '@angular/core';


@Component({
     selector: 'not-found',
     template: ` <main-container>

     <div class="d-flex w-100 h-100 flex-column justify-content-center align-content-center align-items-center">
     
             <h1> <i class="fa fa-question"></i> Nada encontado no caminho especificado </h1>
             <a [routerLink]="['/']"> Voltar para a página principal </a>

      </div> 
      
      
      </main-container> `,
})
export class NotFoundComponent {

}