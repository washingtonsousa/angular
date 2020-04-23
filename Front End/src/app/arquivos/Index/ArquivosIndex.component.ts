import { Component, ViewChild, ViewChildren } from "@angular/core";
import { Arquivo } from "../../models/arquivo.model";
import { DateTimeAdapterService } from "../../adapters/dateTime.adapter";
import { ArquivoService } from "../../services/http/arquivos.service";
import { HttpResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { ArquivoHandler } from "../handler/arquivo.handler";
import { ModalPdfViewerComponent } from "../../Viewers/modal-pdf-viewer.component";
import { Filterable } from "../../classTemplates/filterable-template";
import * as $ from 'jquery';
import { ArquivosFilterPipe } from "../../pipe/arquivos-filter.pipe";


@Component({
    selector: 'arquivos-index',
    templateUrl: 'arquivos-index.html'
})
export class ArquivosIndexComponent extends Filterable {

    public Arquivos: Arquivo[];

    @ViewChild("loadingIcon") public loadingIcon: any;
    public arquivoHandler: ArquivoHandler = new ArquivoHandler();
    @ViewChild("modalPdf") public modal: ModalPdfViewerComponent;
    @ViewChildren("cardFileObject")  cardFiles;

    public JsonObjectIdsObject = {

      ArquivosIdsList : []

    }

    constructor( private dateAdapter: DateTimeAdapterService, 
        private arquivoService: ArquivoService, private router: Router) {

            super({
                Nome: "",
                UsuarioNome: "",
                Data_Referencia: ""
            })

        }

       


        PanelLoad(Id: number) {

            this.arquivoService.Download(Id).subscribe((res :HttpResponse<ArrayBuffer>) => {
    
               this.modal.fileUrl = this.arquivoHandler.generateFileLink(res.body, "application/pdf");
               this.modal.showPanel();
              
             })
    
        } 


        navigateToFileUploadRoute() {
         this.router.navigate(['/arquivos/upload'])
        }

        DeleteArquivo(Id: number) {

            this.arquivoService.delete(Id).subscribe(res => {

                  for(let i = 0; i < this.Arquivos.length; i++ ) {

                        if(this.Arquivos[i].Id == Id) {

                            this.Arquivos.splice(i, 1);
                            this.Arquivos = this.Arquivos;

                        }

                  }


            }, err => {})

        }


        public clearSelected() {

            for(let cardFile of this.cardFiles._results) {

                if(this.JsonObjectIdsObject.ArquivosIdsList.includes(cardFile.Arquivo.Id)) {

                    $(cardFile.inputCheck.nativeElement).click();

                } 

            }

            this.JsonObjectIdsObject.ArquivosIdsList = [];
        }

        public MassiveDelete() {


                 for(let arquivoId of this.JsonObjectIdsObject.ArquivosIdsList) {

                    let arquivoById = this.Arquivos.filter(arquivo =>  arquivo.Id == arquivoId)[0];

                    if(new ArquivosFilterPipe().transform(this.Arquivos, this.filterQueryHandler).includes(arquivoById))   

                    {
                        console.log(arquivoById.Id);
                      this.DeleteArquivo(arquivoById.Id);
                    }   
                 }

            this.clearSelected();
        }

        public selectAll() {
    
            for(let cardFile of this.cardFiles._results) {

                if(!this.JsonObjectIdsObject.ArquivosIdsList.includes(cardFile.Arquivo.Id)) {

                    this.JsonObjectIdsObject.ArquivosIdsList.push(cardFile.Arquivo.Id);
                    $(cardFile.inputCheck.nativeElement).click();

                } 

            }

        }


        OnArquivoCheck(Id: number) {

            if(!this.JsonObjectIdsObject.ArquivosIdsList.includes(Id)) {
                this.JsonObjectIdsObject.ArquivosIdsList.push(Id);
            }  else {
    
                for(let i = 0; i < this.JsonObjectIdsObject.ArquivosIdsList.length; i++) {
            
                    if(this.JsonObjectIdsObject.ArquivosIdsList[i] == Id) {
            
                      this.JsonObjectIdsObject.ArquivosIdsList.splice(i, 1);
                    }
                  
                }
                
              }

        }

        DownloadArquivo(Id: number) {
            this.arquivoService.Download(Id).subscribe((res : HttpResponse<ArrayBuffer>) => {

                this.arquivoHandler.renderAndDownloadFile(res.body, 
                    res.headers.get("Content-Disposition").split(';')[1].trim().split('=')[1].replace(/"/g,""))

            })
        }
         
        ngOnInit() {
        
        this.arquivoService.get().subscribe((res: Arquivo[]) => {

            this.Arquivos = res;  
        
            })
        }

}