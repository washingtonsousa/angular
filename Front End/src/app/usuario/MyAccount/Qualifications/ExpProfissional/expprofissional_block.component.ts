import { Component, Input } from "@angular/core";
import { ExpProfissionalModel } from "../../../../models/ExpProfissional.model";
import { DateTimeAdapterService } from "../../../../adapters/dateTime.adapter";

@Component({
    
    selector: '[expprofissional-block]',

    template: `
<div content-box iconClass="fa-briefcase" Title="Experiências profissionais: " (btnAddAction)="ExpProfissionalPanel.show()">

    <div class="col-xl-6 col-12 no-padding" *ngFor="let expprofissional of ExpProfissionais" 
    (editEmitter)="atualizarExpProfissionalPanel.show()" (deleteEmitter)="expProfissionalForm.Delete(expprofissional.Id)" info-box>
        
    <div info-box-key-value key="Empresa" [value]="expprofissional?.Empresa">   </div>
    <div info-box-key-value key="Início" [value]='dateAdapter.dateTimeStringToStringDate(expprofissional?.Inicio, "yyyy-mm-dd","-","-")'>  
        </div>
    <div info-box-key-value key="Fim" [value]='dateAdapter.dateTimeStringToStringDate(expprofissional?.Fim, "yyyy-mm-dd","-","-")'>   </div>
    <div info-box-key-value key="Ultimo salário" [value]="expprofissional?.UltimoSalario">   </div>
    <div info-box-key-value key="Descrição" [value]="expprofissional?.Descricao">   </div>

    <div side-panel #atualizarExpProfissionalPanel panelTitle="Atualizar experiência">
        <expprofissional-form #expProfissionalForm  (Emitter)="Update($event)" (IdEmitter)="Delete($event)" [expProfessionalObject]="expprofissional" buttonText="Salvar"></expprofissional-form>
    </div>

    </div>

    <div side-panel #ExpProfissionalPanel panelTitle="Adicionar experiência profissional">
        <expprofissional-form (Emitter)="Push($event)" buttonText="Salvar"></expprofissional-form>        
    </div> 

</div>`,


})
export class ExpProfissionalBlockComponent {

    @Input() public ExpProfissionais: ExpProfissionalModel[] = [];

  constructor( private dateAdapter: DateTimeAdapterService) {}

    Push(value) {
        this.ExpProfissionais.push(value);
    }

    Update(value: ExpProfissionalModel) {
        for(let $i = 0; $i < this.ExpProfissionais.length; $i++) {

            if(this.ExpProfissionais[$i].Id == value.Id) {
    

                this.ExpProfissionais[$i].Empresa = value.Empresa;
                this.ExpProfissionais[$i].Cargo = value.Cargo;
                this.ExpProfissionais[$i].Descricao = value.Descricao;
                this.ExpProfissionais[$i].Inicio = value.Inicio;
                this.ExpProfissionais[$i].Fim = value.Fim;
                this.ExpProfissionais[$i].UltimoSalario = value.UltimoSalario;
                

        }

        }
    }



    Delete(Id) {
        for(let $i = 0; $i <= this.ExpProfissionais.length; $i++) {

            if(this.ExpProfissionais[$i].Id == Id) {

                this.ExpProfissionais.splice($i, 1);
                this.ExpProfissionais = this.ExpProfissionais;
        
        }

        }
    }




}