import { Component, ViewChild, Input } from "@angular/core";
import { ModalContentComponent } from "../custommodals/modalContent.component";

import { DomSanitizer, SafeHtml, SafeStyle, SafeScript, SafeUrl, SafeResourceUrl } from '@angular/platform-browser';

@Component({
    selector: '[modal-pdf-viewer]',
    template: `<div #modal modal-content Title="Painel de visualização de PDF"> 
    
    <object [data]="trustedUrl" class="objectSet" type="application/pdf" width="100%" height="500px">
    </object>

    </div>`
})
export class ModalPdfViewerComponent {

       @ViewChild("modal") public modal: ModalContentComponent;
       @Input() public fileUrl: string;
       public trustedUrl: any;

       constructor(protected sanitizer: DomSanitizer) {}

       showPanel() {
            this.trustedUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.fileUrl);
             this.modal.openModal();
       }

}