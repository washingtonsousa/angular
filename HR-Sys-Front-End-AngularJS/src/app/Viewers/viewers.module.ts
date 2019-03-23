import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CustomModalsModule } from '../custommodals/custommodals.module';
import { NgModule } from '@angular/core';
import { ModalPdfViewerComponent } from './modal-pdf-viewer.component';




@NgModule({
    imports: [
        CustomModalsModule,
        BrowserModule,
        FormsModule
    ],
    providers : [],
    declarations: [ModalPdfViewerComponent],
    exports: [ModalPdfViewerComponent]
})
export class ViewersModule {

}