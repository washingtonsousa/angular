import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { Conhecimento } from "../../models/conhecimento.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConhecimentoService } from "../../services/http/conhecimento.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import { CategoriaConhecimento } from "../../models/categoria-conhecimento.model";

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
   @ViewChild('modalMessage') modalMessage: ModalMessageComponent;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private conhecimentoService: ConhecimentoService) {}

   Delete(Id: number) {

          this.conhecimentoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            this.modalMessage.Message = "Deletado com sucesso";
            this.modalMessage.openModal();

          }, err => {
            
            this.modalMessage.Message = "Não foi posssível deletar, verifique abaixo a mensagem de erro: " + err.message;
            this.modalMessage.openModal();

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
            this.modalMessage.Message = "Criado com sucesso";
            this.modalMessage.openModal();
            this.ConhecimentoForm.reset();

        }, err => {

                this.conhecimentoService.put(this.ConhecimentoForm.value).subscribe((res: Conhecimento) => {

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