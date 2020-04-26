import { Component, Input, ViewChild, Output, EventEmitter, OnInit, OnChanges } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ExpProfissional } from '../../../../models/exp-profissional.model';
import { ExpProfissionalService } from "../../../../services/http/ExpProfissional.service";
import { DateTimeAdapterService } from "../../../../adapters/dateTime.adapter";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
    selector: 'expprofissional-form',
    templateUrl: 'expprofissional_form.html'
})
export class ExpProfissionalComponent implements OnInit {

    @Input('expProfessionalObject') public expProfessionalObject: ExpProfissional = new ExpProfissional()
        || new ExpProfissional();
    @Input() public buttonText: string;
    @Output('Emitter') public emitter: EventEmitter<any> = new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<number> = new EventEmitter<any>();
    public ExpProfissionalForm: FormGroup;

    constructor(private fb: FormBuilder,
        private dateAdapter: DateTimeAdapterService,
        private ExpProfissionalService: ExpProfissionalService) { }

    OnSubmit($event) {
        $event.preventDefault();
        this.ExpProfissionalService.post(this.ExpProfissionalForm.value).subscribe((res: ExpProfissional) => {


            ModalMessageService.open("Criado com sucesso");

            this.emitter.emit(res);
            this.ExpProfissionalForm.reset();
            this.ExpProfissionalForm.controls['UsuarioId'].setValue(parseInt(localStorage.getItem('user_id')));
        }, (err) => {

            this.ExpProfissionalService.put(this.ExpProfissionalForm.value).subscribe((res) => {

                ModalMessageService.open("Atualizado com sucesso");
                this.emitter.emit(res);

            }, err => { console.log(err) })

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

        if (!this.expProfessionalObject.UsuarioId) {
            this.expProfessionalObject.UsuarioId = parseInt(localStorage.getItem('user_id'));
        }


        this.ExpProfissionalForm = this.fb.group({

            Id: [this.expProfessionalObject.Id],
            UsuarioId: [this.expProfessionalObject.UsuarioId],
            Empresa: [this.expProfessionalObject.Empresa, Validators.required],
            Cargo: [this.expProfessionalObject.Cargo, Validators.required],
            UltimoSalario: [this.expProfessionalObject.UltimoSalario, Validators.pattern("^\[0-9]+(\.[0-9][0-9])?$")],
            Inicio: [this.dateAdapter.dateTimeStringToStringDate(this.expProfessionalObject.Inicio, "yyyy-mm-dd", "-", "-"),
            Validators.required],
            Fim: [this.dateAdapter.dateTimeStringToStringDate(this.expProfessionalObject.Fim, "yyyy-mm-dd", "-", "-")],
            Descricao: [this.expProfessionalObject.Descricao, Validators.required]

        });

    }

}