import { Component, Input, Output, EventEmitter } from "@angular/core";
import { AreaModel } from "../../models/Area.model";
import {trigger, state, style, transition, animate} from "@angular/animations";


@Component({
    selector: "[card-area]",
    template: `<div class="card" style="width: 100%" @scaleInOut>
    <img *ngIf="Area.imgStr" class="card-img-top img-fluid" [src]="Area.imgStr" [alt]="Area.Nome.charAt(0)">
    <div *ngIf="!Area.imgStr" class="card-letter-area" > <h1 class="card-letter"> {{  Area.Nome.charAt(0)  }} </h1> </div>
    <div class="card-body">
      <h5 class="card-title">{{Area.Nome}}</h5>
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
export class CardAreaComponent {

    @Input() public Area: AreaModel;
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