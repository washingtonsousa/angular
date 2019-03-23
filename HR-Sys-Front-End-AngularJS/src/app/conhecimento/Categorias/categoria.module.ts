import {NgModule} from "@angular/core";
import { CategoriaConhecimentoIndexComponent } from "./Index/CategoriaConhecimentoIndex.Component";
import { CardCategoriaConhecimentoComponent } from "./CardCategoriaConhecimento/card-categoria.component";
import { BrowserModule } from "@angular/platform-browser";
import { CustomModalsModule } from "../../custommodals/custommodals.module";
import { ModalModule, TooltipModule } from "ngx-bootstrap";
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { VisualComponentsModule } from "../../visualcomponents/visualcomponents.module";
import { CommonModule } from "@angular/common";
import { MainContainerModule } from "../../main_container/main_container.module";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { PanelsModule } from "../../panels/panels.module";
import { AnimatedElementsModule } from "../../animatedelements/animatedelements.module";
import { LoadersModule } from "../../loaders/loaders.module";
import { NgSelectizeModule } from "ng-selectize";
import { CategoriaConhecimentoService } from "../../services/http/categoriaConhecimento.service";
import { CategoriaConhecimentoSubscribeComponent } from "./CategoriaConhecimentoSubscribe/categoria-subscribe.component";
import { CategoriaConhecimentosFilterPipe } from "../../pipe/categoriaConhecimentos-filter.pipe";


@NgModule({
providers : [CategoriaConhecimentoService],
imports : [BrowserModule, 
    CustomModalsModule,
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
exports : [CategoriaConhecimentoIndexComponent, CardCategoriaConhecimentoComponent, CategoriaConhecimentoSubscribeComponent],
declarations: [CategoriaConhecimentoIndexComponent,CardCategoriaConhecimentoComponent, CategoriaConhecimentoSubscribeComponent, CategoriaConhecimentosFilterPipe]
}
)
export class CategoriaConhecimentoModule {

}