import { Component, Input, ViewChild } from "@angular/core";
import { Contato } from "../../../../models/Contato.model";


@Component({
    selector: 'contato-content-block',
    template: `
    <div content-box  Title="Contatos adicionais: "  (btnAddAction)="novoContatoPainel.show()" >

        <div info-box (editEmitter)="atualizarContatoPainel.show()" (deleteEmitter)="contatoForm.Delete(contato.Id)"
        class="col-xl-3 col-lg-4 col-md-6 col-12 no-padding" boxTitle="Contato" *ngFor="let contato of contatos">
            <div info-box-key-value keyIconClass="fa-phone" key="Fixo" [value]="contato.Fixo">   </div>
            <div info-box-key-value keyIconClass="fa-mobile" key="Celular" [value]="contato.Celular"></div>
            <div info-box-key-value keyIconClass="fa-envelope" key="Email Contato" [value]="contato.EmailContato">   </div>
            <div info-box-key-value key="Descricao" [value]="contato.Descricao ">   </div>
            
            <div side-panel #atualizarContatoPainel panelTitle="Atualizar Contato">
                <div contato-form #contatoForm buttonText="Atualizar" [contato]="contato" (IdEmitter)="Delete($event)"
                 (Emitter)="Update($event)">
                </div>
            </div>


        </div>

        <div side-panel #novoContatoPainel panelTitle="Novo contato">
                <div contato-form (Emitter)="Push($event)" buttonText="Salvar"></div>
        </div> 
</div>` 
})
export class ContatoBlockComponent {

@Input() public contatos: Contato[];
@ViewChild('novoContatoPainel') public novoContatoPainel: any;
@ViewChild('atualizarContatoPainel') public atualizarContatoPainel: any;

Push(value) {

    this.contatos.push(value);
    this.novoContatoPainel.hide();
}

Update(value: Contato) {
    

    for(let $i = 0; $i <= this.contatos.length; $i++) {

        if(this.contatos[$i].Id == value.Id) {

            this.contatos[$i].Celular = value.Celular;
            this.contatos[$i].Fixo = value.Fixo;
            this.contatos[$i].EmailContato = value.EmailContato;
            this.contatos[$i].Fixo = value.Fixo;
            this.contatos[$i].Descricao = value.Descricao;

      }

      this.atualizarContatoPainel.hide();
}
}

Delete(value) {
 
    for(let $i = 0; $i <= this.contatos.length; $i++) {

           if(this.contatos[$i].Id == value) {

             this.contatos.splice($i, 1);
             this.contatos = this.contatos;
            

        }

     }

}


  }
  


