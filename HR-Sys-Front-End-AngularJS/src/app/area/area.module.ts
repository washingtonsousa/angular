import {NgModule} from "@angular/core";
import { AreaIndexComponent } from "./Index/AreaIndex.Component";
import { CardAreaComponent } from "./CardArea/card-area.component";
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
import { AreaService } from "../services/http/area.service";
import { AreaSubscribeComponent } from "./AreaSubscribe/area-subscribe.component";
import { AreasFilterPipe } from "../pipe/areas-filter.pipe";


@NgModule({
providers : [AreaService],
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
exports : [AreaIndexComponent, CardAreaComponent, AreaSubscribeComponent],
declarations: [AreaIndexComponent,CardAreaComponent, AreaSubscribeComponent, AreasFilterPipe]
}
)
export class AreaModule {

}