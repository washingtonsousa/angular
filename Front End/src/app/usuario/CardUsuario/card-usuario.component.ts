import { Component, Input, Output , EventEmitter, OnInit, ChangeDetectionStrategy} from "@angular/core";
import { UsuarioModel } from "../../models/Usuario.model";
import { ProfilePictureService } from "../../profilePicture/profile-picture.service";
import {trigger, state, style, transition, animate} from "@angular/animations";
import { DomSanitizer } from "@angular/platform-browser";


@Component({
    selector: '[card-usuario]',
    templateUrl: 'card-usuario.html',
    animations: [trigger('scaleInOut', [
        state('void', style({
          transform: 'scale(0)'
        })),
        transition('void <=> *', animate('200ms')),
        
      ])],
      changeDetection: ChangeDetectionStrategy.OnPush
})
export class CardUsuarioComponent implements OnInit{

     @Input() Usuario: UsuarioModel = new UsuarioModel();
     @Output() public editEventEmitter = new EventEmitter<any>(); 
     @Output() public deleteEventEmitter = new EventEmitter<any>(); 
     @Output() public viewEventEmitter = new EventEmitter<any>(); 

     public userProfileImageSrc: any = "assets/images/default-user-image.png";
    
     constructor(private sanitizer:DomSanitizer) {}
     
     viewEventMethod(){
        this.viewEventEmitter.emit();
     }

     editEventMethod() {
        this.editEventEmitter.emit();
     }

     deleteEventMethod() {
        this.deleteEventEmitter.emit();
     }


     ngOnInit() {
        this.initializeComponent();
     }

     initializeComponent() {

      if(this.Usuario.profileImage64String != null && this.Usuario.profileImage64String != "" ) {
            this.userProfileImageSrc 
            = this.sanitizer.bypassSecurityTrustResourceUrl("data:image/jpg;base64," + this.Usuario.profileImage64String);
      }
     }

}