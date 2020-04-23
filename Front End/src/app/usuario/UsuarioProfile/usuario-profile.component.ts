import {Component, Input, AfterViewInit, OnChanges, SimpleChange, SimpleChanges} from '@angular/core';
import { Usuario } from '../../models/usuario.model';


@Component({
   templateUrl: 'usuario-profile.html',
   selector: 'usuario-profile'
})
export class UsuarioProfileComponent implements AfterViewInit, OnChanges {

   
 @Input('Usuario') public usuarioModel: Usuario;
 public profileSrc: string = "assets/images/default-user-image.png";

 constructor(){

 }

 private errorHandler(err: any) {
    if(err.status == 404) {
           this.profileSrc = "assets/images/default-user-image.png";
       }
}
 
 ngOnChanges(changes: SimpleChanges) {
   this.usuarioModel = (changes.usuarioModel != undefined && changes.usuarioModel != null) ? changes.usuarioModel.currentValue : this.usuarioModel;
}

 ngAfterViewInit() {
      if(this.usuarioModel.profileImage64String != null && this.usuarioModel.profileImage64String != "" ) {
         this.profileSrc = "data:image/jpg;base64," + this.usuarioModel.profileImage64String;
      }
 }

}