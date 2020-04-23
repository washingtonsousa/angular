import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Conhecimento } from "../../models/conhecimento.model";
import {trigger, state, style, transition, animate} from "@angular/animations";
import * as $ from 'jquery';

@Component({
    selector: "[line-conhecimento]",
    template: `<div class="inner-line" @scaleInOut>
    <div class="line-column col-6"> <h1>{{Conhecimento.Nome}}</h1> </div>
    <div class="line-column col-5">  <h3>{{ Conhecimento.CategoriaConhecimento?.Categoria  }} </h3> </div>
     
    <ng-content></ng-content>

    <div class="line-column line-controls col-1">

      <a class="line-link line-actions-toggle" (click)="toggleLineActions($event)"> <i class="fa fa-ellipsis-v"></i> </a>

      <div class="line-actions">
      <a  class="line-link" (click)="editEventMethod()"><i class="fa fa-pencil"></i> Editar</a>
      <a  class="line-link" (click)="deleteEventMethod()"><i class="fa fa-trash"></i> Deletar</a>
      </div>
    </div>
  </div>`,
  animations: [trigger('scaleInOut', [
      state('void', style({
        transform: 'scale(0)'
      })),
      transition('void <=> *', animate('200ms')),
      
    ])]
})
export class LineConhecimentoComponent {

    @Input() public Conhecimento: Conhecimento;
    @Output() public editEventEmitter = new EventEmitter<any>(); 
    @Output() public deleteEventEmitter = new EventEmitter<any>(); 

    constructor() {
         
    }

    toggleLineActions(event) {
      $("line-actions").removeClass("line-actions-show");
      $(event.target).parent().parent().find(".line-actions").toggleClass("line-actions-show");
      $(event.target).parent().find(".line-actions").toggleClass("line-actions-show");
    }


    editEventMethod() {
      this.editEventEmitter.emit();
   }

   deleteEventMethod() {
      this.deleteEventEmitter.emit();
   }


}