import { Component, Input, ViewChild, Output, EventEmitter, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {Idioma} from '../../../../models/idioma.model';
import { IdiomaService } from "../../../../services/http/Idioma.service";
import { ModalConfirmMessageComponent } from "../../../../custommodals/modalConfirmMessage.component";

@Component({
selector: 'idioma-form',
templateUrl: 'idioma_form.html'
})
export class IdiomaFormComponent implements OnInit {

    @Input('IdiomaObject') public IdiomaObject: Idioma = new Idioma() || new Idioma();
    @Input() public buttonText: string;
    @ViewChild('loadingIcon') loadingIcon: any
    @Output('Emitter') public Emitter: EventEmitter<any> =  new EventEmitter<any>();
    @Output('IdEmitter') public IdEmitter: EventEmitter<any> =  new EventEmitter<any>();
    @ViewChild('modalConfirmMessage') public modalConfirmMessage: ModalConfirmMessageComponent;
    public  IdiomaForm:FormGroup;
    public selectizeConfig: any;
    public Idiomas: any = [];
    public Fluencias: any = [];

    constructor(private fb: FormBuilder, private IdiomaService: IdiomaService) {

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

    this.Idiomas = [{"value" : "Inglês"} , {"value" : "Espanhol"} , {"value" : "Italiano"} , {"value" : "Francês"}];
    this.Fluencias = [{"value" : "Básico"} , {"value" : "Intermediário"} , {"value" : "Avançado"} , {"value" : "Fluente"}];

    }

    OnSubmit(event) {

            event.preventDefault();

            this.IdiomaService.post(this.IdiomaForm.value).subscribe((res: Idioma) => {

                        this.Emitter.emit(res);
                        this.IdiomaForm.reset();
                        this.IdiomaForm.controls['UsuarioId'].setValue(parseInt(localStorage.getItem('user_id')));
                        

            }, (err) => {

                        this.IdiomaService.put(this.IdiomaForm.value).subscribe((res) => {

                                this.Emitter.emit(res);


                        }, err => {console.log(err)})

            });

    }

    Delete(Id: number) {
        this.IdiomaService.delete(Id).subscribe(res => {

          this.IdEmitter.emit(Id);

        });
    }


    


    ngOnInit() {

        if(!this.IdiomaObject.UsuarioId) {
            this.IdiomaObject.UsuarioId = parseInt(localStorage.getItem('user_id'));
        }
     
        this.IdiomaForm = this.fb.group({
    
        Id: [this.IdiomaObject.Id],
        Nome: [this.IdiomaObject.Nome, Validators.required],
        Fluencia: [this.IdiomaObject.Fluencia, Validators.required],
        UsuarioId: [this.IdiomaObject.UsuarioId],
        
    
        });

    }

}