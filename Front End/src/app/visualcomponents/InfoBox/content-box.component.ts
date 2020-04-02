import { Component, Input, Output, EventEmitter } from "@angular/core";


@Component({
    selector: '[content-box]',
    template: ` 
    
    <div  class="content-block">

    <h3 *ngIf="Title" > <i [class]="'fa ' + iconClass  "></i> {{ Title }} </h3>   

    <div class="content-block-content">
    <ng-content></ng-content>
    </div>

    <div class="content-box-controls">
    
    <button *ngIf="btnActionVisible" class="plus-add-btn item-scale-on-hover" (click)="btnAddAction()" > <i class="fa fa-plus"></i> {{ btnAddText }} </button>

    </div>
    
    </div>`
 
})
export class ContentBoxComponent {
@Input() public Title: string;
@Output('btnAddAction') btnEmitter: EventEmitter<any> = new EventEmitter<any>();
@Input() public btnAddText: string;
@Input() public btnActionVisible: boolean = true;
@Input() public iconClass: string;

btnAddAction() {
this.btnEmitter.emit();
}


}