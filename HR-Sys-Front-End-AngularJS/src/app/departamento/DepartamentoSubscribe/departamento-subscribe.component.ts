import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { DepartamentoModel } from "../../models/Departamento.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DepartamentoService } from "../../services/http/departamento.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import {AreaModel} from "../../models/Area.model";
import {NgSelectizeHelper} from "../../adapters/ngSelectizeHelper";

@Component({
selector: '[departamento-subscribe]',
templateUrl: 'departamento-subscribe.html'
})
export class DepartamentoSubscribeComponent  {

   @Input() public DepartamentoModel: DepartamentoModel = new DepartamentoModel();
   @Input() public AreasList: AreaModel[];
   @Input() public buttonText: string;
   public selectizeConfig: any;
   @Output('emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  DepartamentoForm:FormGroup;
   @ViewChild('modalMessage') modalMessage: ModalMessageComponent;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private departamentoService: DepartamentoService) {

  this.selectizeConfig = new NgSelectizeHelper("Nome", "Id").build(); 

   }

   Delete(Id: number) {
          this.departamentoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            this.modalMessage.Message = "Deletado com sucesso";
            this.modalMessage.openModal();

          }, err => {
            
            this.modalMessage.Message = "Não foi posssível deletar, verifique abaixo a mensagem de erro: " + err.message;
            this.modalMessage.openModal();

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
            this.modalMessage.Message = "Criado com sucesso";
            this.modalMessage.openModal();
            this.DepartamentoForm.reset();

        }, err => {

                this.departamentoService.put(this.DepartamentoForm.value).subscribe((res: DepartamentoModel) => {

                    this.modalMessage.Message = "Atualizado com sucesso";
                    this.modalMessage.openModal();
                    this.emitter.emit(res);

                }, res => {  this.modalMessage.Message = "Falha ao executar a operação, consulte o erro para maiores detalhes: " 
                + err.message;
                    this.modalMessage.openModal(); 
                
                })

            });

        }
    }

}