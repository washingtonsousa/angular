import { Component, Input, ViewChild } from "@angular/core";
import { IdiomaModel } from "../../../../models/Idioma.model";
import { trigger, state, style, animate, transition } from '@angular/animations';


@Component({
    
    selector: '[idioma-block]',
    template: `
    <div content-box iconClass="fa-language" Title="Idiomas: " (btnAddAction)="IdiomaPanel.show()">

        <div *ngFor="let idioma of Idiomas" class="card bg-light w-100" [@scaleInOut]>
        <div class="card-body">
        <h5 class="card-title idioma-title">{{idioma.Nome}}</h5>
        <p class="card-text">{{idioma.Fluencia}}</p>
        </div>

        <div bottom-right-side-panel #atualizarIdiomaPanel panelTitle="Atualizar">
        <idioma-form [IdiomaObject]="idioma" (IdEmitter)="Delete($event)" (Emitter)="Update($event)"
        #IdiomaForm  buttonText="Salvar"></idioma-form>
        </div>

        <div class="card-controls">

        <button class="card-controls-item btn-transparent" (click)="atualizarIdiomaPanel.show()">
        <i class="fa fa-pencil"></i> </button>
        <button class="card-controls-item btn-transparent" (click)="IdiomaForm.modalConfirmMessage.openModal()">
        <i class="fa fa-times"></i> </button>
    
        </div>

    </div>
 
    <div bottom-right-side-panel #IdiomaPanel panelTitle="Adicionar Idioma">
        <idioma-form (Emitter)="Push($event)" buttonText="Salvar"></idioma-form>     
    </div>       
 
</div>`,
    animations: [trigger('scaleInOut', [
        state('void', style({
          transform: 'scale(0)'
        })),
        transition('void <=> *', animate('300ms')),
        
      ])]

})
export class IdiomaBlockComponent {

    @Input() public Idiomas: IdiomaModel[] = [];
    @ViewChild('atualizarIdiomaPanel') _atualizarPanel: any;
    @ViewChild('IdiomaPanel') _idiomaPanel: any;
    

    Push(value: IdiomaModel) {

        this.Idiomas.push(value);
        this._idiomaPanel.hide();

    }

    Update(value: IdiomaModel) {
        for(let $i = 0; $i <= this.Idiomas.length; $i++) {

            if(this.Idiomas[$i].Id == value.Id) {
 
              this.Idiomas[$i].Nome = value.Nome;
              this.Idiomas[$i].Fluencia = value.Fluencia;
              this.Idiomas = this.Idiomas;
 
         }
      }

      this._atualizarPanel.hide();
    }

    Delete(Id) {
        
        for(let $i = 0; $i <= this.Idiomas.length; $i++) {

            if(this.Idiomas[$i].Id == Id) {
 
              this.Idiomas.splice($i, 1);
              this.Idiomas = this.Idiomas;
             
 
         }
      }
    }
}