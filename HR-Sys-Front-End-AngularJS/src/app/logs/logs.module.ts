import {NgModule} from '@angular/core';
import { LogListComponent } from './log-list.component';
import {CommonModule} from '@angular/common';
import { MainContainerModule } from '../main_container/main_container.module';
import { TooltipModule } from 'ngx-bootstrap';
import { CustomModalsModule } from '../custommodals/custommodals.module';
import { StatisticsService } from '../services/http/statistics.service';
import { PanelsModule } from '../panels/panels.module';
import { LogListFilterPipe } from '../pipe/log-list-pipe';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginateFilterPipe } from '../pipe/paginate-filter.pipe';
import {NgxPaginationModule} from 'ngx-pagination'; 

@NgModule({
    providers: [StatisticsService],
    imports: [CommonModule, NgbModule, NgxPaginationModule, MainContainerModule, TooltipModule, CustomModalsModule, PanelsModule],
    declarations: [LogListComponent, LogListFilterPipe, PaginateFilterPipe],
    exports: [LogListComponent]
})
export class LogsModule {   }