import { Component, Input, OnInit, Output, EventEmitter, ViewChildren } from "@angular/core";
import {trigger, state, style, transition, animate} from "@angular/animations";
import { HttpEventType, HttpEvent } from "@angular/common/http";
import { ArquivoService } from "../../../../services/http/arquivos.service";

@Component({
    selector: '[upload-item]',
    template: `
    <div class="card" style="width: 100%" @scaleInOut>
    <div  class="card-header text-center"> 
    <h1 class="upload-item-icon"> <i [class]="'fa fa-file-'+arquivoUploadItem.Ext+'-o ' + arquivoUploadItem.Ext"></i>  </h1>
    </div>
    <div class="card-body">
      <ul class="list-group list-group-flush">
      <li class="list-group-item">{{arquivoUploadItem.ArquivoNome}}</li>
      <li class="list-group-item">{{arquivoUploadItem.UsuarioNome}}</li>
      <li class="list-group-item"><ngb-progressbar [type]="progressBarStatus" [value]="uploadProgress"
       [striped]="true"> {{ uploadProgress }}  </ngb-progressbar></li>
       <li class="list-group-item" *ngIf="statusMessage"> <small> {{statusMessage}} </small> </li>
    </ul>
    </div>
    <div class="card-bottom-controls">
      <a  class="card-link" (click)="removeEventMethod()"><i class="fa fa-times"></i></a>
    </div>
  </div>
    `,
    animations: [trigger('scaleInOut', [
        state('void', style({
          transform: 'scale(0)'
        })),
        transition('void <=> *', animate('200ms')),
        
      ])]
})
export class UploadItemComponent {

 public progressBarStatus: string = "primary";
 @Input() public arquivoUploadItem: any;
 @Output("onDeleteClick") public onDeleteButtonClickEmitter: EventEmitter<any> = new EventEmitter<any>();
 @Input() public uploadProgress: number = 0; 
 @Input() public statusMessage: string = ""; 

 constructor(private arquivosService: ArquivoService) {}

 removeEventMethod() {
           this.onDeleteButtonClickEmitter.emit();
 }


 executeUpload() {
  
 let formData = new FormData();
  
 formData.append("Matricula", this.arquivoUploadItem.Matricula);
 formData.append("TipoDoc", this.arquivoUploadItem.TipoDoc);
 formData.append("Descricao", this.arquivoUploadItem.Descricao);
 formData.append("File", this.arquivoUploadItem.Arquivo);
 formData.append("Data_Referencia", this.arquivoUploadItem.Data_Referencia)


 this.arquivosService.postWithTracking(formData).subscribe((event: HttpEvent<any>) => {

             if (event.type == HttpEventType.UploadProgress) {

                   this.uploadProgress =
                    Math.round(100 * event.loaded / event.total);
    
                 } 

                 if (event.type == HttpEventType.Response) {
                  this.statusMessage = "Upload realizado com sucesso" 
                  this.progressBarStatus = "success";
                 }
                       
 }, err => {  

  this.progressBarStatus = "danger";
       this.statusMessage = "Ocorreu um erro durante o upload, detalhes do erro: " + 
       "código: " + err.error.code + " message: " + err.error.message; 
    })    
}

}
