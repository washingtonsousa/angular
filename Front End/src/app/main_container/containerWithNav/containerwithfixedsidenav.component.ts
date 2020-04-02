import { Component, Input, ViewChild, ElementRef } from "@angular/core";
import * as $ from 'jquery';
import { FixedSideNavItemObject } from "./fixedsidenavitem.object";


@Component({
selector: '[containerWithNav]',
templateUrl: 'container-with-nav.html'

})
export class ContainerWithFixedSideNavComponent {
   @Input() public pageTitle: string;
   @ViewChild('templateRef') public templateRef: ElementRef;
   @Input() public sideMenuOptions: FixedSideNavItemObject[] = [];
   @Input() public iconClass: string;

   toggleFullMenu() {
      $(this.templateRef.nativeElement).toggleClass("left-fixed-menu-reduced");
   }


}