import { Component, Input } from "@angular/core";

@Component({
templateUrl: 'default-page-container.html',
selector: 'default-page-container'
})
export class DefaultPageComponent {

    @Input() public pageTitle: string;
    @Input() public iconClass: string;
    
}