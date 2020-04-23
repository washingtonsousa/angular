import { Component, OnInit, NgZone } from "@angular/core";
import { AreaService } from "../../services/http/area.service";
import { Area } from "../../models/Area.model";
import { DepartamentoService } from "../../services/http/departamento.service";
import { Filterable } from "../../classTemplates/filterable-template";


@Component({
    selector: "area-index",
    templateUrl: "area-index.html"
})
export class AreaIndexComponent extends Filterable implements OnInit{

   public Areas: Area[];
 
    constructor(private areaService: AreaService, private departamentoService: DepartamentoService, public zone: NgZone) {
        super({
            AreaNome: ""
        });
    }



    updateListOnCreate(event: Area) {
           this.Areas.push(event);
           this.Areas.sort( (a,b) => { if(a.Nome.toUpperCase() < b.Nome.toUpperCase()) { return -1; }
           if(a.Nome.toUpperCase() > b.Nome.toUpperCase()) { return 1; }
           return 0;
           });
       }

    updateListOnDelete(event) {

         for(let i = 0; i < this.Areas.length; i++) {
             
            if( this.Areas[i].Id == event) {
                this.Areas.splice(i, 1);
                this.Areas = this.Areas;
            }

         }  

    } 


    updateListOnUpdateEvent(event: Area) {

        for(let i = 0; i < this.Areas.length; i++) {
            
           if( this.Areas[i].Id == event.Id) {
               this.Areas[i] = event;
               this.Areas = this.Areas;
           }

        }  

   } 

    ngOnInit() {

        this.areaService.get().subscribe(res => {

             this.Areas = res;

        })
    }

}