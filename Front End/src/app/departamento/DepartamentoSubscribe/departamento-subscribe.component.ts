import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { Departamento } from "../../models/departamento.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DepartamentoService } from "../../services/http/departamento.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import {Area} from "../../models/Area.model";
import {NgSelectizeHelper} from "../../adapters/ngSelectizeHelper";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
selector: '[departamento-subscribe]',
templateUrl: 'departamento-subscribe.html'
})
export class DepartamentoSubscribeComponent  {

   @Input() public DepartamentoModel: Departamento = new Departamento();
   @Input() public AreasList: Area[];
   @Input() public buttonText: string;
   public selectizeConfig: any;
   @Output('emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  DepartamentoForm:FormGroup;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private departamentoService: DepartamentoService) {

  this.selectizeConfig = new NgSelectizeHelper("Nome", "Id").build(); 

   }

   Delete(Id: number) {
          this.departamentoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            ModalMessageService.open("Deletado com sucesso");

          }, err => {
            
            ModalMessageService.open("Não foi posssível deletar, verifique abaixo a mensagem de erro: " + err.message);

          });
   }

   ngOnInit() {
   this.DepartamentoForm = this.fb.group({
        Id: [this.DepartamentoModel.Id],
        Nome : [this.DepartamentoModel.Nome, [Validators.required]],
        AreaId :  [this.DepartamentoModel.AreaId, [Validators.required]],
        
       });
   }




   OnSubmit(event) {

   event.preventDefault();

   if(this.DepartamentoForm.valid) {

        this.departamentoService.post(this.DepartamentoForm.value).subscribe(res => { 
            
            this.emitter.emit(res);
            ModalMessageService.open("Criado com sucesso");
            this.DepartamentoForm.reset();

        }, err => {

                this.departamentoService.put(this.DepartamentoForm.value).subscribe((res: Departamento) => {

                    ModalMessageService.open("Atualizado com sucesso");
                    this.emitter.emit(res);

                }, res => { 

                ModalMessageService.open("Falha ao executar a operação, consulte o erro para maiores detalhes: " 
                + err.message);
                
                })

            });

        }
    }

}