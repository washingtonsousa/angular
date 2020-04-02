import { Component, OnInit } from "@angular/core";
import { StatisticsService } from "../../services/http/statistics.service";

@Component({
selector: 'log-access-bar-chart',
template: `
<simple-bar-chart *ngIf="localData.length"
[barChartLabels]="months"
[barChartData]="localData">
</simple-bar-chart>
`
})
export class LogAccessBarChartComponent implements OnInit {

private localData: any[] = [];
private months: string[] = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio',
 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro']


constructor(private statisticsService: StatisticsService) {}

initializeNewDataArray(label: string) {
    this.localData.push({data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], label: label})
}


initializeChart(data: Log_ActionStatistics[]) {

    for(let month = 1; month <= this.months.length; month++) {    
        for(let i = 0; i < data.length; i ++) {
         if(parseInt(data[i].Data_Acesso.split("T")[0].split("-")[1]) == month) {
                for(let l =0; l < this.localData.length; l++) {
                    if (this.localData[l].label == data[i].Action_Type) {
                        this.localData[l].data[month - 1] += data[i].Total;
                    }
                }                          
        }
    }
}



}

ngOnInit() {

    this.statisticsService.GetLogActionStatistics().subscribe((res  : Log_ActionStatistics[]) => {

            this.localData = [];
            for(var i = 0; i < res.length; i ++) {
                    if(this.localData.filter(x => x.label == res[i].Action_Type).length == 0)
                    {
                        this.initializeNewDataArray(res[i].Action_Type);
                    }                      
            }

            this.initializeChart(res);
    })
}

}

class Log_ActionStatistics {
Data_Acesso: string;
Total: number;
Action_Type: string;
}

