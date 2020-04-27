import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { Conhecimento } from "../../models/conhecimento.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConhecimentoService } from "../../services/http/conhecimento.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import { CategoriaConhecimento } from "../../models/categoria-conhecimento.model";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";
import { DomainNotification } from "src/app/models/notification.model";

@Component({
selector: '[conhecimento-subscribe]',
templateUrl: 'conhecimento-subscribe.html'
})
export class ConhecimentoSubscribeComponent  {

   @Input() public conhecimentoModel: Conhecimento = new Conhecimento();
   @Input() public categoriaConhecimentos: CategoriaConhecimento[];
   @Input() public buttonText: string;
   @Output('emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  ConhecimentoForm:FormGroup;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private conhecimentoService: ConhecimentoService) {}

   Delete(Id: number) {

          this.conhecimentoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            ModalMessageService.open("Deletado com sucesso");
          }, err => {
            ModalMessageService.handleHttpResponse(err);

          });
   }


   ngOnInit() {
   this.ConhecimentoForm = this.fb.group({
        Id: [this.conhecimentoModel.Id],
        Nome : [this.conhecimentoModel.Nome, [Validators.required]],
        CategoriaConhecimentoId: [this.conhecimentoModel.CategoriaConhecimentoId, [Validators.required]]
       });
   }



   OnSubmit(event) {

   event.preventDefault();

   if(this.ConhecimentoForm.valid) {

        this.conhecimentoService.post(this.ConhecimentoForm.value).subscribe(res => { 
            
            this.emitter.emit(res);

            ModalMessageService.open("Criado com sucesso");
            this.ConhecimentoForm.reset();

        }, err => {

            if (err.status == 400) {

                let notifications = <DomainNotification[]>err.error;
                ModalMessageService.notify(notifications);
                return;
            }

                this.conhecimentoService.put(this.ConhecimentoForm.value).subscribe((res: Conhecimento) => {         
                    ModalMessageService.open("Atualizado com sucesso");
                    this.emitter.emit(res);

                }, res => { 
                    ModalMessageService.handleHttpResponse(err);
                })

            });

        }
    }

}