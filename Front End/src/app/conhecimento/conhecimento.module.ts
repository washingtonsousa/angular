import {NgModule} from "@angular/core";
import { ConhecimentoIndexComponent } from "./Index/ConhecimentoIndex.Component";
import { LineConhecimentoComponent } from "./LineConhecimento/line-conhecimento.component";
import { BrowserModule } from "@angular/platform-browser";
import { CustomModalsModule } from "../custommodals/custommodals.module";
import { ModalModule, TooltipModule } from "ngx-bootstrap";
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { VisualComponentsModule } from "../visualcomponents/visualcomponents.module";
import { CommonModule } from "@angular/common";
import { MainContainerModule } from "../main_container/main_container.module";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { PanelsModule } from "../panels/panels.module";
import { AnimatedElementsModule } from "../animatedelements/animatedelements.module";
import { LoadersModule } from "../loaders/loaders.module";
import { NgSelectizeModule } from "ng-selectize";
import { ConhecimentoService } from "../services/http/conhecimento.service";
import { ConhecimentoSubscribeComponent } from "./ConhecimentoSubscribe/conhecimento-subscribe.component";
import { CategoriaConhecimentoModule } from "./Categorias/categoria.module";
import { CategoriaConhecimentoService } from "../services/http/categoriaConhecimento.service";
import { ConhecimentosFilterPipe } from "../pipe/conhecimentos-filter.pipe";


@NgModule({
providers : [ConhecimentoService, CategoriaConhecimentoService],
imports : [BrowserModule, 
    CustomModalsModule,
    CategoriaConhecimentoModule,
    ModalModule, 
    RouterModule, 
    ReactiveFormsModule, 
    TooltipModule,  
    VisualComponentsModule, 
    ReactiveFormsModule, 
    CommonModule, 
    MainContainerModule, 
    NgbModule, 
    PanelsModule, 
    FormsModule, 
    AnimatedElementsModule,
    ReactiveFormsModule,
    LoadersModule, 
    NgSelectizeModule],
exports : [ConhecimentoIndexComponent, LineConhecimentoComponent, ConhecimentoSubscribeComponent],
declarations: [ConhecimentoIndexComponent,LineConhecimentoComponent, ConhecimentoSubscribeComponent, ConhecimentosFilterPipe]
}
)
export class ConhecimentoModule {

}