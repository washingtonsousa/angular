import { Component, Output, Input, EventEmitter } from "@angular/core";

@Component({
    templateUrl: "crud-top-panel.html",
    selector: '[crud-top-panel]'
})
export class CrudTopPanelComponent {
   
    @Output() public addEventEmitter = new EventEmitter<any>();
    @Input() public tooltipAddEvent: string = "";
    @Input() public buttonText: string = "";
    @Input() public addBtnVisible: boolean  = true;

    constructor() {

    }

    addEventEmmiter() {
        this.addEventEmitter.emit();
    }
}