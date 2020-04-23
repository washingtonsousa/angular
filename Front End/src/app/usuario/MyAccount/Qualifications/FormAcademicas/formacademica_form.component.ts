import { Component, Input, ViewChild, Output, EventEmitter, OnInit, OnChanges } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {FormAcademica} from '../../../../models/form-academica.model';
import { FormAcademicaService } from "../../../../services/http/FormAcademica.service";
import { ModalConfirmMessageComponent } from "../../../../custommodals/modalConfirmMessage.component";

@Component({
selector: 'formacademica-form',
templateUrl: 'formacademica_form.html'
})
export class FormAcademicaFormComponent implements OnInit {

    @Input('FormAcademicaObject') public FormAcademicaObject: FormAcademica = new FormAcademica() || new FormAcademica();
    @Input() public buttonText: string;
    @ViewChild('loadingIcon') loadingIcon: any
    @Output('Emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<any>();
    @ViewChild('modalMessage') modalMessage: ModalConfirmMessageComponent;
    public selectizeConfig: any;
    public TipoCursos: any = [];
    public SituacoesCursos: any = [];

    public  FormAcademicaForm:FormGroup;

    constructor(private fb: FormBuilder, private FormAcademicaService: FormAcademicaService) {

        this.selectizeConfig =  {
            labelField: 'value',
            valueField: 'value',
            highlight: true,
            create:false,
            persist:true,
            plugins: ['dropdown_direction'],
            dropdownDirection: 'down',
            maxItems: 1
            };

            this.TipoCursos = [{"value" : "Ensino Médio"} , 
            {"value" : "Ensino Técnico"} , {"value" : "Graduação"} , {"value" : "Pós Graduação"} ,
             {"value" : "Mestrado"} , {"value" : "Doutorado"}, {"value" : "Outros"}];

            this.SituacoesCursos = [{"value" : "Incompleto"} , {"value" : "Completo"} , 
            {"value" : "Cursando"}];

    }

    OnSubmit($event) {
            $event.preventDefault();
            this.FormAcademicaService.post(this.FormAcademicaForm.value).subscribe((res: FormAcademica) => {
                
                this.modalMessage.Message= "Criado com sucesso";
                this.modalMessage.openModal();

                        this.emitter.emit(res);
            }, (err) => {

                        this.FormAcademicaService.put(this.FormAcademicaForm.value).subscribe((res) => {

                                this.emitter.emit(res);
                                this.modalMessage.Message= "Atualizado com sucesso";
                                this.modalMessage.openModal();

                        }, err => {console.log(err)})

            });
    }

    Delete(Id: number) {
        this.FormAcademicaService.delete(Id).subscribe(res => {

          this.IdEmitter.emit(Id);

        });
    }




    ngOnInit() {

        if(!this.FormAcademicaObject.UsuarioId) {
            this.FormAcademicaObject.UsuarioId = parseInt(localStorage.getItem('user_id'));
        }
    
        this.FormAcademicaForm = this.fb.group({
    
        Id: [this.FormAcademicaObject.Id],
        Instituicao : [this.FormAcademicaObject.Instituicao, Validators.required],
        Curso : [this.FormAcademicaObject.Curso, Validators.required],
        TipoCurso : [this.FormAcademicaObject.TipoCurso, Validators.required],
        Situacao : [this.FormAcademicaObject.Situacao, Validators.required],
        UsuarioId: [this.FormAcademicaObject.UsuarioId]
    
        });

    }

}