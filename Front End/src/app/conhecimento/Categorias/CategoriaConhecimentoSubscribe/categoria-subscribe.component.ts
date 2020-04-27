import { Component, Input, EventEmitter, ViewChild, Output } from "@angular/core";
import { CategoriaConhecimento } from "../../../models/categoria-conhecimento.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CategoriaConhecimentoService } from "../../../services/http/categoriaConhecimento.service";
import { ModalMessageComponent } from "../../../custommodals/modalMessage.component";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";
import { DomainNotification } from "src/app/models/notification.model";

@Component({
    selector: '[categoriaConhecimento-subscribe]',
    templateUrl: 'categoria-subscribe.html'
})
export class CategoriaConhecimentoSubscribeComponent {

    @Input() public categoriaConhecimentoModel: CategoriaConhecimento = new CategoriaConhecimento();
    @Input() public buttonText: string;
    @Output('emitter') public emitter: EventEmitter<any> = new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<number> = new EventEmitter<number>();
    public CategoriaConhecimentoForm: FormGroup;
    @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
    constructor(private fb: FormBuilder, private categoriaConhecimentoService: CategoriaConhecimentoService) { }

    Delete(Id: number) {
        this.categoriaConhecimentoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            ModalMessageService.open("Deletado com sucesso");
        }, err => {

            ModalMessageService.handleHttpResponse(err);
        });
    }


    ngOnInit() {
        this.CategoriaConhecimentoForm = this.fb.group({
            Id: [this.categoriaConhecimentoModel.Id],
            Categoria: [this.categoriaConhecimentoModel.Categoria, [Validators.required]],


        });
    }

    OnSubmit(event) {

        event.preventDefault();

        if (this.CategoriaConhecimentoForm.valid) {

            this.categoriaConhecimentoService.post(this.CategoriaConhecimentoForm.value).subscribe(res => {

                this.emitter.emit(res);
                ModalMessageService.open("Criado com sucesso");
                this.CategoriaConhecimentoForm.reset();

            }, err => {



                if (err.status == 400) {

                    let notifications = <DomainNotification[]>err.error;
                    ModalMessageService.notify(notifications);
                    return;
                }


                this.categoriaConhecimentoService.put(this.CategoriaConhecimentoForm.value).subscribe((res: CategoriaConhecimento) => {

                    ModalMessageService.open("Atualizado com sucesso");
                    this.emitter.emit(res);

                }, res => {
                    ModalMessageService.handleHttpResponse(err);
                })

            });

        }
    }

}