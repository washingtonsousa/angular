import { Component, OnInit, ViewChild } from "@angular/core";
import { StatisticsService } from "../../services/http/statistics.service";
import { ComponentInnerLoader } from "../../loaders/component-inner-loader.component";

@Component({
    selector: 'usuarios-table',
    template: `<div id="usuarios-table" class="relative"><table class="table table-striped">
<thead class="thead-dark-blue"> 
    <tr> <th>Tipo</th> <th>Quantidade</th></tr>
</thead>
<tbody> 
    <tr> <td>Ativos </td> <td> {{ tableModel?.Ativos }} </td> </tr> 
    <tr> <td>Desativados</td> <td> {{ tableModel?.Desativados }}  </td> </tr> 
    <tr> <td>Do Sharepoint</td> <td> {{ tableModel?.UsuariosSharepoint }} </td> </tr> 
    <tr> <td>Total Cadastrado </td> <td> {{ tableModel?.Total_Cadastrado }} </td> </tr> 
</tbody>
</table>
<div *ngIf="!tableModel" #Loader component-inner-loader (OnClick)="reload()"></div>
</div>

`
})
export class UsuariosTableComponent implements OnInit {

    private tableModel: any = {};
    @ViewChild('Loader')  public loader: ComponentInnerLoader;

    constructor(private statisticsService: StatisticsService) {}

    reload() {
        this.loader.reset();
        this.ngOnInit();
    }

    ngOnInit() {
   
    this.statisticsService.getUsuarioBasic().subscribe(res => {

               this.tableModel = res;

    }, err => {
        
        this.loader.onErrorHandler(err.message);

    })
}
}