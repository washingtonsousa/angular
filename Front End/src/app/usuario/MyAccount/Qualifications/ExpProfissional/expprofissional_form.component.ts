import { Component, Input, ViewChild, Output, EventEmitter, OnInit, OnChanges } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {ExpProfissionalModel} from '../../../../models/ExpProfissional.model';
import { ExpProfissionalService } from "../../../../services/http/ExpProfissional.service";
import { DateTimeAdapterService } from "../../../../adapters/dateTime.adapter";
import { ModalConfirmMessageComponent } from "src/app/custommodals/modalConfirmMessage.component";

@Component({
selector: 'expprofissional-form',
templateUrl: 'expprofissional_form.html'
})
export class ExpProfissionalComponent implements OnInit {

    @Input('expProfessionalObject') public expProfessionalObject: ExpProfissionalModel = new ExpProfissionalModel() 
    || new ExpProfissionalModel();
    @Input() public buttonText: string;
    @ViewChild('loadingIcon') loadingIcon: any
    @Output('Emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<any>();
    @ViewChild('modalMessage') modalMessage: ModalConfirmMessageComponent;
    public ExpProfissionalForm:FormGroup;

    constructor(private fb: FormBuilder,
        private dateAdapter: DateTimeAdapterService,
         private ExpProfissionalService: ExpProfissionalService) {}

    OnSubmit($event) {
            $event.preventDefault();
            this.ExpProfissionalService.post(this.ExpProfissionalForm.value).subscribe((res: ExpProfissionalModel) => {
                this.modalMessage.Message= "Criado com sucesso";
                this.modalMessage.openModal();
                        this.emitter.emit(res);
                        this.ExpProfissionalForm.reset();
                        this.ExpProfissionalForm.controls['UsuarioId'].setValue(parseInt(localStorage.getItem('user_id')));
            }, (err) => {

                        this.ExpProfissionalService.put(this.ExpProfissionalForm.value).subscribe((res) => {
                            this.modalMessage.Message= "Atualizado com sucesso";
                            this.modalMessage.openModal();
                                this.emitter.emit(res);

                        }, err => {console.log(err)})

            });
    }

    Delete(Id: number) {
        this.ExpProfissionalService.delete(Id).subscribe(res => {

          this.IdEmitter.emit(Id);

        });
    }


    onData_DataInicioChange(event) {
        this.ExpProfissionalForm.controls['Inicio'].setValue(event.year + "-" + event.month + "-" + event.day);
    }

    onData_DataFimChange(event) {
        this.ExpProfissionalForm.controls['Fim'].setValue(event.year + "-" + event.month + "-" + event.day);
    }

    ngOnInit() {   

        if(!this.expProfessionalObject.UsuarioId) {
            this.expProfessionalObject.UsuarioId = parseInt(localStorage.getItem('user_id'));
        }
    
    
        this.ExpProfissionalForm = this.fb.group({
    
        Id: [this.expProfessionalObject.Id],
        UsuarioId: [this.expProfessionalObject.UsuarioId],
        Empresa : [this.expProfessionalObject.Empresa, Validators.required],
        Cargo : [this.expProfessionalObject.Cargo, Validators.required],
        UltimoSalario: [this.expProfessionalObject.UltimoSalario, Validators.pattern("^\[0-9]+(\.[0-9][0-9])?$")],
        Inicio : [this.dateAdapter.dateTimeStringToStringDate(this.expProfessionalObject.Inicio, "yyyy-mm-dd","-","-"),
         Validators.required],
        Fim : [this.dateAdapter.dateTimeStringToStringDate(this.expProfessionalObject.Fim, "yyyy-mm-dd","-","-")],
        Descricao :  [this.expProfessionalObject.Descricao, Validators.required]
    
        });

    }

}