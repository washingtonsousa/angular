import { Component, OnInit, NgZone, Output, EventEmitter } from "@angular/core";
import { CategoriaConhecimentoService } from "../../../services/http/categoriaConhecimento.service";
import { CategoriaConhecimentoModel } from "../../../models/CategoriaConhecimento.model";
import { DepartamentoService } from "../../../services/http/departamento.service";


@Component({
    selector: "[categoriaConhecimento-index]",
    templateUrl: "categoria-index.html"
})
export class CategoriaConhecimentoIndexComponent implements OnInit {

   @Output("onUpdateCategoriasList") public onUpdateCategoriasListEmitter:  EventEmitter<any> =
   new EventEmitter<CategoriaConhecimentoModel>();

   public CategoriaConhecimentos: CategoriaConhecimentoModel[];
   public filterQueryHandler = {
       Categoria: ""
   }
    constructor(private categoriaConhecimentoService: CategoriaConhecimentoService,
         private departamentoService: DepartamentoService,
         public zone: NgZone) {

this.departamentoService.get().subscribe(res => {});

    }

    onFilterUpdate(event, value_type: string) {


        this.filterQueryHandler[value_type] = event.target.value;

        this.filterQueryHandler =  this.filterQueryHandler;


     }

    toggleOrderBy() {

        this.CategoriaConhecimentos = this.CategoriaConhecimentos.reverse();
       
       }

       updateListOnCreate(event: CategoriaConhecimentoModel) {
           this.CategoriaConhecimentos.push(event);
           this.CategoriaConhecimentos.sort( (a,b) => { if(a.Categoria.toUpperCase() < b.Categoria.toUpperCase()) { return -1; }
           
           
           if(a.Categoria.toUpperCase() > b.Categoria.toUpperCase()) { return 1; }
           return 0;
           });

           this.onUpdateCategoriasListEmitter.emit();

       }

       updateListOnDelete(event: number) {

         for(let i = 0; i < this.CategoriaConhecimentos.length; i++) {
             
            if( this.CategoriaConhecimentos[i].Id == event) {
                this.CategoriaConhecimentos.splice(i, 1);
                this.CategoriaConhecimentos = this.CategoriaConhecimentos;
            }

         }  

         this.onUpdateCategoriasListEmitter.emit();

    } 


    updateListOnUpdateEvent(event: CategoriaConhecimentoModel) {

        for(let i = 0; i < this.CategoriaConhecimentos.length; i++) {
            
           if( this.CategoriaConhecimentos[i].Id == event.Id) {
               this.CategoriaConhecimentos[i] = event;
               this.CategoriaConhecimentos = this.CategoriaConhecimentos;
           }

        } 
        
        this.onUpdateCategoriasListEmitter.emit();

   } 

    ngOnInit() {

        this.categoriaConhecimentoService.get().subscribe(res => {

             this.CategoriaConhecimentos = res;

        })
    }

}