import {Component, Input, AfterViewInit} from '@angular/core';
import { UsuarioModel } from '../../models/Usuario.model';


@Component({
   templateUrl: 'usuario-profile.html',
   selector: 'usuario-profile'
})
export class UsuarioProfileComponent implements AfterViewInit {

 @Input('Usuario') public usuarioModel: UsuarioModel;
 public profileSrc: string = "assets/images/default-user-image.png";

 constructor(){

 }

 private errorHandler(err: any) {
    if(err.status == 404) {
           this.profileSrc = "assets/images/default-user-image.png";
       }
}


 ngAfterViewInit() {
      if(this.usuarioModel.profileImage64String != null && this.usuarioModel.profileImage64String != "" ) {
         this.profileSrc = "data:image/jpg;base64," + this.usuarioModel.profileImage64String;
      }
 }

}