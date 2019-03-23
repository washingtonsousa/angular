import { Component, ViewChildren } from "@angular/core";
import {UsuarioService} from '../../../services/http/usuario.service';
import { UsuarioModel } from "../../../models/Usuario.model";

@Component({
    selector: 'upload-panel',
    templateUrl: 'upload-panel.html'
})
export class UploadPanelComponent {

      @ViewChildren('uploadItem') public uploadItems: any;
     public arquivoItemsObject: any[] = [];
     public usuarios: UsuarioModel[] = [];

     constructor() {}

      uploadAll() {

            for(var i = 0; i < this.arquivoItemsObject.length; i++ ) {

                  this.uploadItems._results[i].executeUpload()
            }

      }

      addItems(event) {
            this.arquivoItemsObject = [];
            this.arquivoItemsObject = event;
      }

      removeItem(index:number) {

                   for(let i = 0; i < this.arquivoItemsObject.length; i++) {

                                if(this.arquivoItemsObject[i].index == index) {
                                    this.arquivoItemsObject.splice(i, 1);  
                                }
                   }

                   this.arquivoItemsObject = this.arquivoItemsObject;
      }

      clearList() {
        this.arquivoItemsObject = [];
        this.arquivoItemsObject = this.arquivoItemsObject;
      }

}