import {NgModule} from "@angular/core";
import { ArquivosIndexComponent } from "./Index/ArquivosIndex.component";
import { PanelsModule } from "../panels/panels.module";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { ArquivoService } from "../services/http/arquivos.service";
import { UsuarioService} from "../services/http/usuario.service";
import { CustomModalsModule } from "../custommodals/custommodals.module";
import { ArquivosFilterPipe } from "../pipe/arquivos-filter.pipe";
import { ArquivoCardComponent } from "./CardArquivo/card-arquivo.component";
import { MainContainerModule } from "../main_container/main_container.module";
import { UploadPanelComponent } from "./Upload/panel/upload-panel.component";
import { UploadFormComponent } from "./Upload/forms/upload-form.component";
import { ModalModule, TooltipModule } from "ngx-bootstrap";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { LoadersModule } from "../loaders/loaders.module";
import { UploadItemComponent } from "./Upload/panel/item/upload-item.component";
import { RouterModule } from "@angular/router";
import { ViewersModule } from "../viewers/viewers.module";
import { DateTimeAdapterService } from "../adapters/dateTime.adapter";


@NgModule({
    imports: [PanelsModule, 
        BrowserModule, 
        CommonModule,
        RouterModule,
        ModalModule,
        NgbModule,
        ViewersModule,
        LoadersModule,        
        ReactiveFormsModule,
        FormsModule,
        PanelsModule,
        TooltipModule,
        CustomModalsModule,
        MainContainerModule],
    exports: [ArquivosIndexComponent, ArquivoCardComponent, ArquivosFilterPipe],
    declarations: [ArquivosIndexComponent, ArquivoCardComponent, ArquivosFilterPipe, 
        UploadItemComponent, UploadFormComponent, UploadPanelComponent],
    providers: [ArquivoService, UsuarioService, DateTimeAdapterService]
})
export class ArquivosModule {}