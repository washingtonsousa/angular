import {Component, Input} from '@angular/core';

@Component({
template: `<div *ngIf="visible" class="ms-loading-icon">
<div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
<span *ngIf="visible"> {{ loadingText }}</span>`,
selector: 'ms-loading-icon'
})
export class MSLoadingComponent {
    
    @Input() public visible: boolean = true;
    @Input() public loadingText: string = "";
    constructor() {}

    show() {
        this.visible = true;
    }

    hide() {
        this.visible = false;
    }
}