import { Component, OnInit, ViewChild } from "@angular/core";
import { DateTimeAdapterService } from "../../../adapters/dateTime.adapter";
import { ArquivoService } from "../../../services/http/arquivos.service";
import { Arquivo } from "../../../models/arquivo.model";
import { HttpResponse } from "@angular/common/http";
import { ArquivoHandler } from "../../../arquivos/handler/arquivo.handler";
import { ModalPdfViewerComponent } from "../../../viewers/modal-pdf-viewer.component";

@Component({
    selector: 'document-list',
    templateUrl: 'document-list.html' 
})
export class DocumentListComponent implements OnInit{


    public Arquivos: Arquivo[];
    public arquivoHandler: ArquivoHandler = new ArquivoHandler();
    public filterQueryHandler = {
        Nome: "",
        Data_Referencia: ""
    };

    @ViewChild("modalPdf") public modal: ModalPdfViewerComponent;



    constructor( private dateAdapter: DateTimeAdapterService, 
        private arquivoService: ArquivoService) {}


    PanelLoad(Id: number) {

        this.arquivoService.DownloadSingle(Id).subscribe((res :HttpResponse<ArrayBuffer>) => {

           this.modal.fileUrl = this.arquivoHandler.generateFileLink(res.body, "application/pdf");
           this.modal.showPanel();
          
         })

    } 

    onFilterUpdate(event, value_type: string) {
    
        if(event.target) {
            this.filterQueryHandler[value_type] = event.target.value;
        } else {
            this.filterQueryHandler[value_type] = event;
        }
    
          this.filterQueryHandler =  this.filterQueryHandler;

    }

    toggleOrderBy() {
        this.Arquivos = this.Arquivos.reverse();
    }

    dataReferenciaFilterHandler(event) {

        this.onFilterUpdate(event.year + "-" + event.month + "-" + ("0" + parseInt(event.day)).slice(-2) , 'Data_Referencia');

    }

    DownloadArquivo(Id: number) {

        this.arquivoService.DownloadSingle(Id).subscribe((res :HttpResponse<ArrayBuffer>) => {

                 this.arquivoHandler.renderAndDownloadFile(res.body,
                    res.headers.get("Content-Disposition").split(';')[1].trim().split('=')[1].replace(/"/g,""));


        })
    }
    
    ngOnInit() {
    
    this.arquivoService.getSingle().subscribe((res: Arquivo[]) => {

        this.Arquivos = res;  
    
        })
    }


}