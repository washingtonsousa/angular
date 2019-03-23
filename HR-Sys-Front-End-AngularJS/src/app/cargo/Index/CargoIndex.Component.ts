import { Component, OnInit, NgZone } from "@angular/core";
import { CargoService } from "../../services/http/cargo.service";
import { CargoModel } from "../../models/Cargo.model";
import { DepartamentoModel } from "../../models/Departamento.model";
import { DepartamentoService } from "../../services/http/departamento.service";
import { AreaModel } from "../../models/Area.model";
import { AreaService } from "../../services/http/area.service";
import { Filterable } from "../../classTemplates/filterable-template";

@Component({
    selector: "cargo-index",
    templateUrl: "cargo-index.html"
})
export class CargoIndexComponent extends Filterable implements OnInit{

public Cargos: CargoModel[];
public AreasList: AreaModel[];
public DepartamentosList: DepartamentoModel[];


        constructor(private cargoService: CargoService, 
            private areaService: AreaService, 
            private departamentoService: DepartamentoService) {

        super({

            Nome : "",
            DepartamentoNome: "",
            AreaNome: ""

        });

        }

    toggleOrderBy() {

        this.Cargos = this.Cargos.reverse();
       
       }



       updateListOnCreate(event: CargoModel) {
           this.Cargos.push(event);
           this.Cargos.sort( (a,b) => { if(a.Nome.toUpperCase() < b.Nome.toUpperCase()) { return -1; }
           if(a.Nome.toUpperCase() > b.Nome.toUpperCase()) { return 1; }
           return 0;
           });
       }

       updateListOnDelete(event) {
  
         for(let i = 0; i < this.Cargos.length; i++) {
             
            if( this.Cargos[i].Id == event) {
                this.Cargos.splice(i, 1);
                this.Cargos = this.Cargos;
            }

         }  

    } 


    updateListOnUpdateEvent(event: CargoModel) {

        for(let i = 0; i < this.Cargos.length; i++) {
           if( this.Cargos[i].Id == event.Id) {
               this.Cargos[i] = event;
               this.Cargos = this.Cargos;
           }

        }  

   } 

    ngOnInit() {

        this.cargoService.get().subscribe(res => {

             this.Cargos = res;

             this.departamentoService.get().subscribe(res => {


                this.DepartamentosList = res;

             })


             this.areaService.get().subscribe(res => {


                this.AreasList = res;

             })

        })
    }

}