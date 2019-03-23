import { Component, OnInit, NgZone } from "@angular/core";
import { ConhecimentoService } from "../../services/http/conhecimento.service";
import { ConhecimentoModel } from "../../models/Conhecimento.model";
import { CategoriaConhecimentoModel } from "../../models/CategoriaConhecimento.model";
import { CategoriaConhecimentoService } from "../../services/http/categoriaConhecimento.service";
import { NgSelectizeHelper } from "../../adapters/ngSelectizeHelper";
import { Filterable } from "../../classTemplates/filterable-template";


@Component({
    selector: "conhecimento-index",
    templateUrl: "conhecimento-index.html"
})
export class ConhecimentoIndexComponent extends  Filterable implements OnInit {

   public Conhecimentos: ConhecimentoModel[];
   public CategoriaConhecimentos: CategoriaConhecimentoModel[];

    constructor(private conhecimentoService: ConhecimentoService, 
        private categoriaConhecimentoService: CategoriaConhecimentoService) {
            super({
                Nome: "",
                CategoriaNome: ""
            });
    }


    

    updateListOnCreate(event: ConhecimentoModel) {
        this.Conhecimentos.push(event);
        this.Conhecimentos.sort( (a,b) => { if(a.Nome.toUpperCase() < b.Nome.toUpperCase()) { return -1; }
        if(a.Nome.toUpperCase() > b.Nome.toUpperCase()) { return 1; }
        return 0;
        });
    }

    updateListOnDelete(event) {

        for(let i = 0; i < this.Conhecimentos.length; i++) {
            
        if( this.Conhecimentos[i].Id == event) {
            this.Conhecimentos.splice(i, 1);
            this.Conhecimentos = this.Conhecimentos;
        }

    }  

    } 


    updateListOnUpdateEvent(event: ConhecimentoModel) {

        for(let i = 0; i < this.Conhecimentos.length; i++) {
            
           if( this.Conhecimentos[i].Id == event.Id) {
               this.Conhecimentos[i] = event;
               this.Conhecimentos = this.Conhecimentos;
           }

        }  

   } 


private initializeComponents() {
    this.categoriaConhecimentoService.get().subscribe(res => {

        this.CategoriaConhecimentos = res;

        this.conhecimentoService.get().subscribe(res => {

           this.Conhecimentos = res;

      })

   });

}

   onUpdateCategoriasList(event) {
    this.initializeComponents();
   }

    ngOnInit() {


      this.initializeComponents();
       
    }

}