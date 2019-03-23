import { Component, Input, TemplateRef, ViewChild } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap";




@Component({
    selector: '[modal-message]',
    template: `
    
<ng-template #template>
    <div class="modal-header">
    <h2 class="modal-title pull-left">{{Title}}</h2>
    <button type="button" class="close pull-right" aria-label="Close" (click)="modalRef.hide()">
    <span aria-hidden="true">&times;</span>
    </button>
    </div>
    <div class="modal-body">
    {{Message}}
    </div>
    <div class="modal-footer">
    <button class="btn btn-primary" (click)="modalRef.hide()"> OK </button>
    </div>
</ng-template>
    
    
    `
})
export class ModalMessageComponent {

    modalRef: BsModalRef;
    @Input() public Message: string;
    @Input() public Title: string = "Aviso";
    @ViewChild('template') template:  TemplateRef<any>;

    constructor(private modalService: BsModalService) {}


    openModal() {
        this.modalRef = this.modalService.show(this.template);
      }
}