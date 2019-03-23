import { NgModule } from "@angular/core";
import { ModalMessageComponent } from "./modalMessage.component";
import { ModalModule } from "ngx-bootstrap";
import { ModalConfirmMessageComponent } from "./modalConfirmMessage.component";
import { ModalContentComponent } from "./modalContent.component";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

@NgModule({
imports: [ModalModule, BrowserModule, CommonModule, FormsModule ],
exports: [ModalMessageComponent, ModalConfirmMessageComponent, ModalContentComponent],
declarations: [ModalMessageComponent, ModalConfirmMessageComponent, ModalContentComponent],
providers: []
})
export class CustomModalsModule {

}