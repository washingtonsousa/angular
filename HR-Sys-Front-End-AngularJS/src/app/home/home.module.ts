import { NgModule } from "@angular/core";
import { HomeComponent } from "./home.component";
import { MainContainerModule } from "../main_container/main_container.module";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { ChartsModule } from "ng2-charts";
import { CustomChartsModule } from "../charts/charts.module";
import { StatisticsService } from "../services/http/statistics.service";
import { UsuariosTableComponent } from "./statistics/usuarios-table.component";
import { LoadersModule } from "../loaders/loaders.module";
import { EntidadesTableComponent } from "./statistics/entidades-table.component";
import { LogAccessBarChartComponent } from "./statistics/log_accessBarChart.component";
import { TooltipModule } from "ngx-bootstrap";
import { LogAccessTableComponent } from "./statistics/log_accessTable.component";
import { StatisticsHubService } from "../services/http/statisticsHub.service";
import {NotFoundComponent} from './notfound.component';

@NgModule({
    providers: [StatisticsService, StatisticsHubService],
    imports: [MainContainerModule, LoadersModule, TooltipModule, ChartsModule, CustomChartsModule ,BrowserModule, RouterModule, CommonModule],
    exports: [HomeComponent, NotFoundComponent, UsuariosTableComponent, EntidadesTableComponent, LogAccessBarChartComponent,LogAccessTableComponent],
    declarations: [HomeComponent, NotFoundComponent, UsuariosTableComponent, EntidadesTableComponent, LogAccessBarChartComponent, LogAccessTableComponent]
})
export class HomeModule {}