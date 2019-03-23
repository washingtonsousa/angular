import { Component, Input, TemplateRef, ViewChild, Output, EventEmitter } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap";


@Component({
    selector: '[modal-confirm-message]',
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
    <button class="btn btn-danger" (click)="modalRef.hide()"> {{CancelBtnText}} </button>
    <button class="btn btn-success" (click)="onConfirm()"> {{ConfirmBtnText}} </button>
    </div>
</ng-template>
    `
})
export class ModalConfirmMessageComponent {

    modalRef: BsModalRef;
    @Input() public Message: string;
    @Input() public CancelBtnText: string = "Cancelar";
    @Input() public ConfirmBtnText: string = "Confirmar";
    @Input() public Title: string = "Aviso";
    @ViewChild('template') template:  TemplateRef<any>;
    @Output('onConfirm') public onConfirmEventEmitter: EventEmitter<any> = new EventEmitter<any>();

    constructor(private modalService: BsModalService) {}

    onConfirm() {
        this.modalRef.hide();
        this.onConfirmEventEmitter.emit();
    }

    openModal() {
        this.modalRef = this.modalService.show(this.template);
      }
    }