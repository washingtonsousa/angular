import {Component, ElementRef, HostListener} from '@angular/core';
import {trigger, state, style, transition, animate} from "@angular/animations";

@Component({
templateUrl:'side-menu.html',
selector: 'side-menu',
animations: [trigger('scaleInOut', [
    state('show', style({
      transform: "translateX(0)"
    })),
    state('hide', style({
      transform: "translateX(-100%)"
      })),
    transition('show <=> hide', animate('200ms')),
    
  ])]
})
export class SideMenuComponent {
private sideMenuUser: string = localStorage.getItem('username');
private visible: string = "hide";
private hasFullAccess: boolean = false;

constructor(private element: ElementRef) {


let accessLevel = localStorage.getItem("access_level");

if(accessLevel == 'Administrador') {
  this.hasFullAccess = true;
}


}

public show() {
this.visible = "show";
}

public hide() {
this.visible = "hide";
}

public toggle() {
 this.visible =  (this.visible == "show") ? "hide" : "show";
}

@HostListener('document:click', ['$event'])
 onDocumentClick(event) {

     if(this.element.nativeElement.contains(event.target) 
    ) {
       
    } 
     else {

      /*

      if(event.explicitOriginalTarget.classList) {
      
        if (!event.explicitOriginalTarget.classList.contains("side-menu-toggle-btn-do-not-close")) {
           this.hide();
        }   
      
      } */

    }


  }

}