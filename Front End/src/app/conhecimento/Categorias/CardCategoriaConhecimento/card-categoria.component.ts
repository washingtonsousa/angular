import { Component, Input, Output, EventEmitter } from "@angular/core";
import { CategoriaConhecimento } from "../../../models/categoria-conhecimento.model";
import {trigger, state, style, transition, animate} from "@angular/animations";


@Component({
    selector: "[card-categoriaConhecimento]",
    template: `<div class="card card-inverse" style="width: 100%" @scaleInOut>
   <div class="card-body">
      <h5 class="card-title">{{CategoriaConhecimento.Categoria}}</h5>
    </div>
    <div class="card-bottom-controls">
      <a  class="card-link" (click)="editEventMethod()"><i class="fa fa-pencil"></i></a>
      <a  class="card-link" (click)="deleteEventMethod()"><i class="fa fa-trash"></i></a>
    </div>
  </div>`,
  animations: [trigger('scaleInOut', [
      state('void', style({
        transform: 'scale(0)'
      })),
      transition('void <=> *', animate('200ms')),
      
    ])]
})
export class CardCategoriaConhecimentoComponent {

    @Input() public CategoriaConhecimento: CategoriaConhecimento;
    @Output() public editEventEmitter = new EventEmitter<any>(); 
    @Output() public deleteEventEmitter = new EventEmitter<any>(); 

    constructor() {
         
    }


    editEventMethod() {
      this.editEventEmitter.emit();
   }

   deleteEventMethod() {
      this.deleteEventEmitter.emit();
   }


}