import { Component, Input, ViewChild, Output, EventEmitter, OnInit, OnChanges } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {EnderecoModel} from '../../../../models/Endereco.model';
import { EnderecoService } from "../../../../services/http/endereco.service";
import { ModalMessageComponent } from "../../../../custommodals/modalMessage.component";

@Component({
selector: 'endereco-form',
templateUrl: 'endereco_form.html'
})
export class EnderecoFormComponent implements OnInit, OnChanges {

    @Input('enderecoObject') public enderecoObject: EnderecoModel = new EnderecoModel();
    @Input() public buttonText: string;
    @ViewChild('loadingIcon') loadingIcon: any
    @Output('Emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
    public  EnderecoForm:FormGroup;
    @ViewChild('modalMessage') modalMessage: ModalMessageComponent;

    constructor(private fb: FormBuilder, private enderecoService: EnderecoService) {}

    OnSubmit($event) {
            $event.preventDefault();
            this.enderecoService.post(this.EnderecoForm.value).subscribe((res: EnderecoModel) => {

                        this.emitter.emit(res);
                        this.modalMessage.Message = "Atualizado com sucesso";
                        this.modalMessage.openModal();
                        
            }, (err) => {

                        this.enderecoService.put(this.EnderecoForm.value).subscribe((res) => {

                                this.modalMessage.Message = "Atualizado com sucesso";
                                this.emitter.emit(res);
                                this.modalMessage.openModal();

                        }, err => {console.log(err)})

            });
    }

   ngOnChanges() {

    if(!this.enderecoObject.UsuarioId) {
        this.enderecoObject.UsuarioId = parseInt(localStorage.getItem('user_id'));
    }

    this.EnderecoForm = this.fb.group({

    Id: [this.enderecoObject.Id],
    Rua : [this.enderecoObject.Rua, Validators.required],
    Numero  : [this.enderecoObject.Numero, [ Validators.pattern("^[0-9]*$") , Validators.required ]],
    Complemento :  [this.enderecoObject.Complemento],
    CEP : [this.enderecoObject.CEP, [Validators.required, Validators.pattern("^[0-9]*$"),
     Validators.minLength(8), Validators.maxLength(8)]],
    Bairro : [this.enderecoObject.Bairro, Validators.required], 
    Referencia : [this.enderecoObject.Referencia, [Validators.required]],
    Cidade : [this.enderecoObject.Cidade, Validators.required],
    UsuarioId: [this.enderecoObject.UsuarioId, Validators.required]


    });
   }

    ngOnInit() {}

}