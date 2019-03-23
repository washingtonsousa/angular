import { Component, Input, ElementRef } from "@angular/core";
import * as $ from 'jquery';

@Component({
 selector: '[bottom-right-side-panel]',
 template: `

    <div class="bottom-right-side-panel-inner">

         <div class="bottom-right-side-panel-header">
         
         <h2>  {{ panelTitle }} </h2>
         <hr />
         </div>

         <div class="bottom-right-side-panel-body"> 
         
         <ng-content></ng-content>
         
         
         </div>

         <div class="bottom-right-side-panel-footer"> 
         
         <p><small> {{footerText}} </small></p>
         
         </div>

    </div>
    <span class="bottom-right-side-panel-close" (click)="hide()"> <i class="fa fa-times"></i> </span>
 `
})
export class BottomRightSidePanelComponent {
@Input() public panelTitle: string;
@Input() public footerText: string;

constructor(private elementRef: ElementRef) {
$(this.elementRef.nativeElement).addClass('bottom-right-side-panel-panel');
}

show() {
$('.bottom-right-side-panel-panel').removeClass('bottom-right-side-panel-panel-show');
$(this.elementRef.nativeElement).addClass('bottom-right-side-panel-panel-show');
}

hide() {
$(this.elementRef.nativeElement).removeClass('bottom-right-side-panel-panel-show');
}


}