import { Component, OnInit } from "@angular/core";
import { StatisticsService } from "../../services/http/statistics.service";

@Component({
selector: 'log-access-table',
template: `<table class="table table-striped">
<thead> <tr> <th> Ação </th> <th> Usuário </th> <th> Data/Hora </th></tr> </thead>
<tbody> 

<tr *ngFor="let data of dataFromServer | slice:0:7" > 

<td> {{ data.Action_Type }} </td> 
<td>  {{ data.Usuario }}  </td>
<td>  <small> <strong> Data: {{ data.Data_Acesso.split("T")[0] }} 
<br /> Hora: {{ data.Data_Acesso.split("T")[1].split("-")[0].split(".")[0] }} </strong> </small>  </td>
</tr>

</tbody>
</table>`
})
export class LogAccessTableComponent implements OnInit {

public dataFromServer: any[] = [];


constructor(private statisticsService: StatisticsService) {}

ngOnInit() {

    this.statisticsService.GetLogActionLimitedList().subscribe((res  : any[]) => {

          this.dataFromServer = res;

    });

}

}

