import { Component, Input, ViewChild, Output, EventEmitter, OnInit, OnChanges } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {CertCursoModel} from '../../../../models/CertCurso.model';
import { CertCursoService } from "../../../../services/http/CertCurso.service";
import { ModalMessageComponent } from "../../../../custommodals/modalMessage.component";
import { ModalConfirmMessageComponent } from "src/app/custommodals/modalConfirmMessage.component";

@Component({
selector: 'certcurso-form',
templateUrl: 'certcurso_form.html'
})
export class CertCursoFormComponent implements OnInit {

    @Input('certcursoObject') public CertCursoObject: CertCursoModel = new CertCursoModel() || new CertCursoModel();
    @Input() public buttonText: string;
    @ViewChild('loadingIcon') loadingIcon: any
    @Output('Emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<any>();
    public  CertCursoForm:FormGroup;
    @ViewChild('modalMessage') modalMessage: ModalMessageComponent;

    constructor(private fb: FormBuilder, private CertCursoService: CertCursoService) {}

    OnSubmit($event) {
            $event.preventDefault();

            

            this.CertCursoService.post(this.CertCursoForm.value).subscribe((res: CertCursoModel) => {

                        this.emitter.emit(res);
                        this.CertCursoForm.reset();
                        this.CertCursoForm.controls['UsuarioId'].setValue(parseInt(localStorage.getItem('user_id')));
                        this.modalMessage.Message = "Criado com sucesso";
                        this.modalMessage.openModal();


            }, (err) => {

                        this.CertCursoService.put(this.CertCursoForm.value).subscribe((res) => {
                            this.modalMessage.Message = "Atualizado com sucesso";
                            this.modalMessage.openModal();
                                this.emitter.emit(res);

                        }, err => {
                            

                            this.modalMessage.Message = "Ocorreu falha ao tentar inserir ou atualizar dado";
                            this.modalMessage.openModal();
                        
                        
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