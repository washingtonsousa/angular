import { Component, Input, Output, EventEmitter, ViewChild, ElementRef } from "@angular/core";
import { ArquivoModel } from "../../models/Arquivo.model";
import {trigger, state, style, transition, animate} from "@angular/animations";

@Component({
    selector: '[card-arquivo]',
    template: `<div class="card" style="width: 100%" @scaleInOut>
    <div  class="card-header"> <h1 class="upload-item-icon text-center"> 
    <i [class]="'fa fa-file-'+Arquivo.Ext+'-o ' + Arquivo.Ext"></i> </h1>
    
    <input *ngIf="Selectable" #inputCheck type="checkbox" [value]="Arquivo.Id" (change)="OnCheck($event.target.value)" />
    


    </div>
    <div class="card-body">
      <ul class="list-group list-group-flush">
      <li class="list-group-item">{{Arquivo.Nome}}</li>
      <li class="list-group-item">{{Arquivo.Usuario.Nome}}</li>
    </ul>
    </div>
    <div class="card-bottom-controls">
      <a  class="card-link" (click)="downloadEventMethod()"><i class="fa fa-download"></i></a>
      <a  *ngIf="deleteOptionVisible" class="card-link" (click)="deleteEventMethod()"><i class="fa fa-trash"></i></a>
      <a  *ngIf="viewOptionVisible" class="card-link" (click)="viewEventMethod()"><i class="fa fa-eye"></i></a>
    </div>
  </div>`,
  animations: [trigger('scaleInOut', [
    state('void', style({
      transform: 'scale(0)'
    })),
    transition('void <=> *', animate('200ms')),
    
  ])]
})
export class ArquivoCardComponent {
     @Input() public Arquivo: ArquivoModel;
     @Output("onDownloadClick") public downloadEventEmitter: EventEmitter<any> = new EventEmitter<any>();
     @Output("onDeleteClick") public deleteEventEmitter: EventEmitter<any> = new EventEmitter<any>();
     @Output("onViewClick") public viewEventEmitter: EventEmitter<any> = new EventEmitter<any>();

     @Output("onCheck") public onCheckEventEmitter: EventEmitter<number> = new EventEmitter<number>();

     @Input() public viewOptionVisible: boolean;
     @Input() public deleteOptionVisible: boolean;
     @Input() public Selectable: boolean = true;
     @ViewChild("inputCheck") inputCheck: ElementRef;
      


     downloadEventMethod() {
      
      this.downloadEventEmitter.emit();

     }

     deleteEventMethod() {

      this.deleteEventEmitter.emit();

     }

     OnCheck(Id: number) {
         this.onCheckEventEmitter.emit(Id);
     }



     viewEventMethod() {

      this.viewEventEmitter.emit();

     }

}