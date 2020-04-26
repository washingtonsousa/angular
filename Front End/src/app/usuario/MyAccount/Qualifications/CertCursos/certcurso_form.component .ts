import { Component, Input, ViewChild, Output, EventEmitter, OnInit, OnChanges } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {CertCurso} from '../../../../models/cert-curso.model';
import { CertCursoService } from "../../../../services/http/CertCurso.service";
import { ModalMessageComponent } from "../../../../custommodals/modalMessage.component";
import { ModalConfirmMessageComponent } from "src/app/custommodals/modalConfirmMessage.component";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
selector: 'certcurso-form',
templateUrl: 'certcurso_form.html'
})
export class CertCursoFormComponent implements OnInit {

    @Input('certcursoObject') public CertCursoObject: CertCurso = new CertCurso() || new CertCurso();
    @Input() public buttonText: string;
    @Output('Emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<any>();
    public  CertCursoForm:FormGroup;

    constructor(private fb: FormBuilder, private CertCursoService: CertCursoService) {}

    OnSubmit($event) {
            $event.preventDefault();

            

            this.CertCursoService.post(this.CertCursoForm.value).subscribe((res: CertCurso) => {

                        this.emitter.emit(res);
                        this.CertCursoForm.reset();
                        this.CertCursoForm.controls['UsuarioId'].setValue(parseInt(localStorage.getItem('user_id')));


                        ModalMessageService.open("Criado com sucesso");


            }, (err) => {

                        this.CertCursoService.put(this.CertCursoForm.value).subscribe((res) => {

                            ModalMessageService.open("Atualizado com sucesso");
                                this.emitter.emit(res);

                        }, err => {
                    
                            ModalMessageService.open("Ocorreu falha ao tentar inserir ou atualizar dado");
                        })

            });
    }

    Delete(Id: number) {
        this.CertCursoService.delete(Id).subscribe(res => {

          this.IdEmitter.emit(Id);

        });
    }




    ngOnInit() {

        if(!this.CertCursoObject.UsuarioId) {
            this.CertCursoObject.UsuarioId = parseInt(localStorage.getItem('user_id'));
        }
     
        this.CertCursoForm = this.fb.group({
    
        Id: [this.CertCursoObject.Id],
        Instituicao : [this.CertCursoObject.Instituicao, Validators.required],
        Nome : [this.CertCursoObject.Nome, Validators.required],
        Certificadora : [this.CertCursoObject.Certificadora],
        Periodo : [this.CertCursoObject.Periodo, Validators.required],
        Descricao : [this.CertCursoObject.Descricao],
        UsuarioId: [this.CertCursoObject.UsuarioId]
    
        });

    }

}