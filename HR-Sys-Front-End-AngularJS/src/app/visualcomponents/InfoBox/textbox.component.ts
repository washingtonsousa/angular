import { Component, Input } from "@angular/core";


@Component({
    selector: '[text-box]',
    template: `<div class="data-text-block"> 
 
    <h2 *ngIf="boxTitle"> {{ boxTitle }} </h2>
    <hr />
    <ng-content></ng-content>

     </div>`
 
})
export class TextBoxComponent {
@Input() public boxTitle: string;
}