import { NgModule } from "@angular/core";
import {SidePanelComponent} from './side-panel.component';
import { BasePanelComponent } from "./base-panel-component";
import { CrudTopPanelComponent } from "./crud-top-panel.component";
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BottomRightSidePanelComponent } from "./bottom-right-side-panel.component";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";


@NgModule({
imports: [TooltipModule, CommonModule, BrowserModule],
declarations: [SidePanelComponent, BottomRightSidePanelComponent, BasePanelComponent, CrudTopPanelComponent],
exports: [SidePanelComponent, BottomRightSidePanelComponent, BasePanelComponent, CrudTopPanelComponent],
providers: []
})
export class PanelsModule {}