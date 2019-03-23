import {NgModule} from "@angular/core";
import { CargoIndexComponent } from "./Index/CargoIndex.Component";
import { CardCargoComponent } from "./CardCargo/card-Cargo.component";
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
import { CargoService } from "../services/http/cargo.service";
import { CargoSubscribeComponent } from "./CargoSubscribe/Cargo-subscribe.component";
import { CargosFilterPipe } from "../pipe/cargos-filter.pipe";
import {AreaService} from "../services/http/area.service";
import { DepartamentoService } from "../services/http/departamento.service";

@NgModule({
providers : [CargoService, AreaService, DepartamentoService],
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
    exports : [CargoIndexComponent, CardCargoComponent, CargoSubscribeComponent],
    declarations: [CargoIndexComponent,CardCargoComponent, CargoSubscribeComponent, CargosFilterPipe]
}
)
export class CargoModule {

}