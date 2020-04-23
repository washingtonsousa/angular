import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { CategoriaConhecimento } from "../../../models/categoria-conhecimento.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CategoriaConhecimentoService } from "../../../services/http/categoriaConhecimento.service";
import { ModalMessageComponent } from "../../../custommodals/modalMessage.component";
import { ImageConverter } from "../../../adapters/imageConverter";

@Component({
selector: '[categoriaConhecimento-subscribe]',
templateUrl: 'categoria-subscribe.html'
})
export class CategoriaConhecimentoSubscribeComponent  {

   @Input() public categoriaConhecimentoModel: CategoriaConhecimento = new CategoriaConhecimento();
   @Input() public buttonText: string;
   @Output('emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  CategoriaConhecimentoForm:FormGroup;
   @ViewChild('modalMessage') modalMessage: ModalMessageComponent;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private categoriaConhecimentoService: CategoriaConhecimentoService) {}

   Delete(Id: number) {
          this.categoriaConhecimentoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            this.modalMessage.Message = "Deletado com sucesso";
            this.modalMessage.openModal();

          }, err => {
            this.modalMessage.Message = "Não foi posssível deletar, verifique abaixo a mensagem de erro: " + 
            this.handleErrorMessage(err);
            this.modalMessage.openModal();
        
          });
   }


   ngOnInit() {
   this.CategoriaConhecimentoForm = this.fb.group({
        Id: [this.categoriaConhecimentoModel.Id],
        Categoria : [this.categoriaConhecimentoModel.Categoria, [Validators.required]],

        
       });
   }


   handleErrorMessage(err) : string {
 
    if (err.error.message) {
         return "Código: " + err.error.code + " Detalhes: " + err.error.message;
    }
    
    return err.message;

   }


   OnSubmit(event) {

   event.preventDefault();

   if(this.CategoriaConhecimentoForm.valid) {

        this.categoriaConhecimentoService.post(this.CategoriaConhecimentoForm.value).subscribe(res => { 
            
            this.emitter.emit(res);
            this.modalMessage.Message = "Criado com sucesso";
            this.modalMessage.openModal();
            this.CategoriaConhecimentoForm.reset();

        }, err => {

                this.categoriaConhecimentoService.put(this.CategoriaConhecimentoForm.value).subscribe((res: CategoriaConhecimento) => {

                    this.modalMessage.Message = "Atualizado com sucesso";
                    this.modalMessage.openModal();
                    this.emitter.emit(res);

                }, res => {  this.modalMessage.Message = "Falha ao executar a operação, consulte o erro para maiores detalhes: " 
                +  this.handleErrorMessage(err);
                
                    this.modalMessage.openModal(); 
                
                })

            });

        }
    }

}