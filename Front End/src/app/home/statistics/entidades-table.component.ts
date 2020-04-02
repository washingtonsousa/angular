import { Component, OnInit, ViewChild } from "@angular/core";
import { StatisticsService } from "../../services/http/statistics.service";
import { ComponentInnerLoader } from "../../loaders/component-inner-loader.component";

@Component({
    selector: 'entidades-table',
    template: `<div id="entidades-table" class="relative"><table class="table table-striped">
<thead class="thead-dark-blue"> 
    <tr> <th>Tipo</th> <th>Quantidade</th></tr>
</thead>
<tbody> 
    <tr> <td>Cargos </td> <td> {{ tableModel?.Cargos }} </td> </tr> 
    <tr> <td>Departamentos</td> <td> {{ tableModel?.Departamentos }}  </td> </tr> 
    <tr> <td>Áreas</td> <td> {{ tableModel?.Areas }} </td> </tr> 
</tbody>
</table>
<div *ngIf="!tableModel" #Loader component-inner-loader (OnClick)="reload()"></div>
</div>
`
})
export class EntidadesTableComponent implements OnInit {

    private tableModel: any;
    @ViewChild('Loader')  public loader: ComponentInnerLoader;

    constructor(private statisticsService: StatisticsService) {}

    reload() {
        this.loader.reset();
        this.ngOnInit();
    }

    ngOnInit() {

   
    this.statisticsService.getEntidadesBasic().subscribe(res => {

               this.tableModel = res;

    }, err => {
        
        this.loader.onErrorHandler(err.message);

    })
}
}