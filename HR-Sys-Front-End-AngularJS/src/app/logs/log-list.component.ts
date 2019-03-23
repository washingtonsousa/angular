import { Component, OnInit, OnChanges, DoCheck } from "@angular/core";
import { StatisticsService } from "../services/http/statistics.service";
import { Filterable } from "../classTemplates/filterable-template";



@Component({
    selector: 'log-list',
    templateUrl: 'log-list.html'
})
export class LogListComponent extends Filterable implements OnInit {

    public logData: any[] = [];
    
    constructor(private statisticsService: StatisticsService) {

        super( {

            UsuarioNome : "",
            DataStr: "",
    
        } );

    }
    
    teste($event) {
        console.log($event);
    }

    ngOnInit() {

        this.statisticsService.GetLogActionLimitedList().subscribe( res => {
            this.logData = res;     
        })
    }


}

