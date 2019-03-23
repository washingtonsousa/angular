import { Component, NgZone, OnInit, ViewChild } from "@angular/core";
import { StatisticsHubService } from "../services/http/statisticsHub.service";
import { LogAccessBarChartComponent } from "./statistics/log_accessBarChart.component";
import { LogAccessTableComponent } from "./statistics/log_accessTable.component";

@Component({
selector: 'home',
templateUrl: 'home.html'
})
export class HomeComponent implements OnInit {

    public username: string = localStorage.getItem('username');
     @ViewChild('accessLogChart') public accessLogChart: LogAccessBarChartComponent; 
     @ViewChild('accessLogTable') public accessLogTable: LogAccessTableComponent;

    constructor(private statisticsHubService: StatisticsHubService,
        public zone: NgZone) {
    }

    private initializeHubService() {

        this.statisticsHubService.proxy.on('updateLog_Action', (data) => {
        
                this.zone.run(() =>  {
                    
                this.accessLogChart.ngOnInit();
                this.accessLogTable.dataFromServer.unshift(data);
     
                });
    
        });
    
      this.statisticsHubService.start();
      
    }

    ngOnInit() {
        this.initializeHubService();
    }

}