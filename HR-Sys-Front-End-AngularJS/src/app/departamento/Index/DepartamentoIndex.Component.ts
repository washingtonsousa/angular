import { Component, OnInit, NgZone } from "@angular/core";
import { DepartamentoService } from "../../services/http/departamento.service";
import { DepartamentoModel } from "../../models/Departamento.model";
import { AreaService } from "../../services/http/area.service";
import { AreaModel } from "../../models/Area.model";
import { Filterable } from "../../classTemplates/filterable-template";

@Component({
    selector: "departamento-index",
    templateUrl: "departamento-index.html"
})
export class DepartamentoIndexComponent extends Filterable implements OnInit{

public Departamentos: DepartamentoModel[];
public AreasList: AreaModel[];


    constructor(private departamentoService: DepartamentoService, private areaService: AreaService) {

            super({

                Nome : "",
                AreaNome: ""

            })

    }



       updateListOnCreate(event: DepartamentoModel) {
           this.Departamentos.push(event);
           this.Departamentos.sort( (a,b) => { if(a.Nome.toUpperCase() < b.Nome.toUpperCase()) { return -1; }
           if(a.Nome.toUpperCase() > b.Nome.toUpperCase()) { return 1; }
           return 0;
           });
       }

       updateListOnDelete(event) {
  
         for(let i = 0; i < this.Departamentos.length; i++) {
             
            if( this.Departamentos[i].Id == event) {
                this.Departamentos.splice(i, 1);
                this.Departamentos = this.Departamentos;
            }

         }  

    } 


    updateListOnUpdateEvent(event: DepartamentoModel) {

        for(let i = 0; i < this.Departamentos.length; i++) {
           if( this.Departamentos[i].Id == event.Id) {
               this.Departamentos[i] = event;
               this.Departamentos = this.Departamentos;
           }

        }  

   } 

    ngOnInit() {




        this.departamentoService.get().subscribe(res => {

             this.Departamentos = res;

             this.areaService.get().subscribe(res => {


                this.AreasList = res;

             })

        })
    }

}