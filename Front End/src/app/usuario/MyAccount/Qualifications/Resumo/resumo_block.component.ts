import { Component, Input, OnInit } from "@angular/core";
import { Resumo } from "../../../../models/resumo.model";


@Component({
    selector: '[resumo-block]',
    template: `<div class="card w-100">
  <h3 class="card-header"><i class="fa fa-edit"></i> Resumo </h3>
  <div class="card-body">
    <p class="card-text" [innerHTML]="resumo?.Conteudo"></p>

    <p>
    <a (click)="resumoModal.openModal()" class="link">
       <i class="fa fa-pencil"></i> Editar 
     </a>
    </p>
    
  </div>
</div>

<div #resumoModal modal-content Title="Preencher resumo"> 

<div *ngIf="(resumo | json) != '{}'" resumo-form #resumoForm buttonText="Salvar" (OnSubmit)="onSave($event)" [resumo]="resumo">
      
    </div>    

</div>

`
})
export class ResumoBlockComponent implements OnInit {

      @Input() public resumo: Resumo;


      constructor() {
   
      }

      ngOnInit() {
    
      }

      onSave(event) {
        this.resumo = event;
      }

}