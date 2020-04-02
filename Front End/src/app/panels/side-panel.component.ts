import { Component, ElementRef, Input } from "@angular/core";
import * as $ from 'jquery';

@Component({
    selector: '[side-panel]',
    templateUrl: 'side-panel.html'
})
export class SidePanelComponent {

@Input() public panelTitle: string = "";

constructor(private element: ElementRef) {
    $(this.element.nativeElement).addClass("side-panel");
}

hide() {
    $(this.element.nativeElement).removeClass("side-panel-show");
}

show() {
    this.toggleBeforeShow();
    $(this.element.nativeElement).addClass("side-panel-show");
}

toggle() {
    $(this.element.nativeElement).toggleClass("side-panel-show");
}

private toggleBeforeShow() {
    $(".side-panel").removeClass("side-panel-show");
}

}