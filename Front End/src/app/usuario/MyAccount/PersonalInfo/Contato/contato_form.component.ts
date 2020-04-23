import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { Contato } from "../../../../models/Contato.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ContatoService } from "../../../../services/http/contato.service";
import { ModalMessageComponent } from "../../../../custommodals/modalMessage.component";

@Component({
selector: '[contato-form]',
templateUrl: 'contato_form.html'
})
export class ContatoContainerComponent  {

   @Input() public contato: Contato = new Contato();
   @Input() public buttonText: string;
   @Output('Emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  ContatoForm:FormGroup;
   @ViewChild('modalMessage') modalMessage: ModalMessageComponent;

   constructor(private fb: FormBuilder, private contatoService: ContatoService) {}

   Delete(Id: number) {
          this.contatoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);

          });
   }

   ngOnInit() {

   if(!this.contato.UsuarioId) {
       this.contato.UsuarioId = parseInt(localStorage.getItem('user_id'));
   }

   this.ContatoForm = this.fb.group({
        Id: [this.contato.Id],
        Fixo : [this.contato.Fixo, [Validators.pattern("^[0-9]*$"), Validators.minLength(10), Validators.maxLength(10)]],
        Celular :  [this.contato.Celular, [Validators.pattern("^[0-9]*$"), Validators.minLength(10), Validators.maxLength(11)]],
        EmailContato :  [this.contato.EmailContato, 
            [Validators.email, Validators.required]],
        Descricao :  [this.contato.Descricao, Validators.required],
        UsuarioId: [this.contato.UsuarioId, Validators.required]
       });
   }

   OnSubmit(event) {

   event.preventDefault();

   if(this.ContatoForm.valid) {

 

            this.contatoService.post(this.ContatoForm.value).subscribe(res => { 
                
                this.emitter.emit(res);
                this.modalMessage.Message = "Criado com sucesso";
                this.modalMessage.openModal();
                this.ContatoForm.reset();
                this.ContatoForm.controls['UsuarioId'].setValue(parseInt(localStorage.getItem('user_id')));

            }, err => {

               


                    this.contatoService.put(this.ContatoForm.value).subscribe((res: Contato) => {

                        this.modalMessage.Message = "Atualizado com sucesso";
                        this.modalMessage.openModal();
                        this.emitter.emit(res);

                    })

            });

        }
    }

}