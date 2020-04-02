import {NgModule} from "@angular/core";
import { DepartamentoIndexComponent } from "./Index/DepartamentoIndex.Component";
import { CardDepartamentoComponent } from "./CardDepartamento/card-Departamento.component";
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
import { DepartamentoService } from "../services/http/departamento.service";
import { DepartamentoSubscribeComponent } from "./DepartamentoSubscribe/Departamento-subscribe.component";
import { DepartamentosFilterPipe } from "../pipe/departamentos-filter.pipe";
import {AreaService} from "../services/http/area.service";

@NgModule({
providers : [DepartamentoService, AreaService],
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
    exports : [DepartamentoIndexComponent, CardDepartamentoComponent, DepartamentoSubscribeComponent],
    declarations: [DepartamentoIndexComponent,CardDepartamentoComponent, DepartamentoSubscribeComponent, DepartamentosFilterPipe]
}
)
export class DepartamentoModule {

}