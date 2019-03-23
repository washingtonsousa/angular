import { Component, Input, Output, EventEmitter, ViewChild } from "@angular/core";
import { trigger, state, style, animate, transition } from '@angular/animations';
import { ModalConfirmMessageComponent } from "../../custommodals/modalConfirmMessage.component";


@Component({
    selector: '[info-box]',
    template: `<div class="data-block" [@scaleInOut]> 
    
    <h5 *ngIf="boxTitle"> {{ boxTitle }} </h5> 
    
    <ng-content></ng-content> 
    
    
    <div *ngIf="FullControlsVisible" class="data-block-controls">


    <button class="data-block-controls-item btn-transparent item-scale-on-hover" (click)="emitEdit()"> <i class="fa fa-pencil"></i> </button>
    <button *ngIf="deleteControlVisible" class="data-block-controls-item btn-transparent item-scale-on-hover" (click)="openDeleteConfirmMessage()"> <i class="fa fa-times"></i> </button>

    <div modal-confirm-message #modalConfirmMessage [Message]="modalDeleteConfirmMessage" (onConfirm)="emitDelete()"></div>

    </div>
    
    </div>`,
    animations: [trigger('scaleInOut', [
        state('void', style({
          transform: 'scale(0)'
        })),
        transition('void => *', animate('300ms')),
        
      ])]
 
})
export class InfoBoxComponent {

  @Input() public boxTitle: string;
  @Output() public editEmitter: EventEmitter<any> = new EventEmitter<any>();
  @Output() public deleteEmitter: EventEmitter<any> = new EventEmitter<any>();
  @Input() public deleteControlVisible: boolean = true;
  @Input() public FullControlsVisible: boolean = true;
  @Input() public modalDeleteConfirmMessage: string = "Tem certeza que deseja deletar este objeto?";
  @ViewChild('modalConfirmMessage') public modalConfirmMessage: ModalConfirmMessageComponent;

  emitEdit() {
   this.editEmitter.emit();
  }

  emitDelete() {
   this.deleteEmitter.emit();
   this.modalConfirmMessage.modalRef.hide();
  }


  openDeleteConfirmMessage() {
    this.modalConfirmMessage.openModal();
  }

}