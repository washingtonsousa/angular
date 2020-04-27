import { Component, Input, TemplateRef, ViewChild, OnInit } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap";
import { ModalMessageService } from "../services/emitters/modal-message.service";

@Component({
    selector: '[modal-message]',
    template: `
    
<ng-template #template>
    <div class="modal-header">
    <h2 class="modal-title pull-left">{{settings.Title}}</h2>
    <button type="button" class="close pull-right" aria-label="Close" (click)="modalRef.hide()">
    <span aria-hidden="true">&times;</span>
    </button>
    </div>
    <div class="modal-body" [innerHTML]="settings.Message">
    </div>
    <div class="modal-footer">
    <button class="btn btn-primary" (click)="modalRef.hide()"> OK </button>
    </div>
</ng-template>
    
    
    `
})
export class ModalMessageComponent implements OnInit {

    modalRef: BsModalRef;
    @Input() public Message: string;
    @Input() public Title: string = "Aviso";
    @ViewChild('template') template: TemplateRef<any>;

    settings: ModalMessageSettings = new ModalMessageSettings();

    constructor(private modalService: BsModalService) { }


    openModal() {
        this.modalRef = this.modalService.show(this.template);
    }

    ngOnInit() {

        ModalMessageService.listen().subscribe((params:ModalMessageSettings) => {
                    this.settings = params;
                    this.openModal();
        });

    }
}

export class ModalMessageSettings {
    public Message: String = "";
    public Title: String = "Aviso";
}