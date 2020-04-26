import { Component, Input, ViewChild, OnChanges } from "@angular/core";
import {UsuarioConhecimento} from '../../../../models/usuario-conhecimento.model';
import { UsuarioConhecimentoService } from "../../../../services/http/usuarioconhecimento.service";
import { trigger, state , transition, animate, style} from '@angular/animations';
import { CategoriaConhecimentoService } from "../../../../services/http/categoriaConhecimento.service";
import { CategoriaConhecimento } from "../../../../models/categoria-conhecimento.model";
import { LoadingIconService } from "src/app/services/emitters/loading-icon.service";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
selector: '[usuarioconhecimento-form]',
templateUrl: 'usuarioconhecimento_form.html',
animations:[
    trigger('verticalOpen',[
        state('inactive',style({
            opacity:'0',
            height: '0px'
        })),
        state('active',style({
            opacity:'1',
            height: '100%'
        })),
        transition('active => inactive', animate('100ms ease-in')),
        transition('inactive => active', animate('100ms ease-out'))
    ])
]
})
export class UsuarioConhecimentoFormComponent implements OnChanges {

    @Input() public UsuarioConhecimentoList: UsuarioConhecimento[] = [] || [];
    public categoriaConhecimentos: CategoriaConhecimento[] = [];

    public state: string = "inactive";
    private JsonObjectIdsObject = {

     "UsuarioId" : parseInt(localStorage.getItem('user_id')),
     "ConhecimentoIds" : []

    };
    @Input() public buttonText: string;
 
    constructor(
    private UsuarioConhecimentoService: UsuarioConhecimentoService,
    private categoriaConhecimentoService: CategoriaConhecimentoService) {}


    animateList() {
        this.state = (this.state === 'inactive' ? 'active' : 'inactive');
    }

    OnSubmit() {

           LoadingIconService.show();
           this.UsuarioConhecimentoService.post(this.JsonObjectIdsObject).subscribe(res => {

                LoadingIconService.hide();
                ModalMessageService.open("Atualizado com sucesso");

           }, err => {LoadingIconService.hide();})
    }

    OnCheck(value) {

        value = parseInt(value);

        if(!this.JsonObjectIdsObject.ConhecimentoIds.includes(value)) {
            this.JsonObjectIdsObject.ConhecimentoIds.push(value);
        }  else {

            for(let i = 0; i < this.JsonObjectIdsObject.ConhecimentoIds.length; i++) {
        
                if(this.JsonObjectIdsObject.ConhecimentoIds[i] == value) {
        
                  this.JsonObjectIdsObject.ConhecimentoIds.splice(i, 1);
                }
              
            }
            
          }

          console.log(this.JsonObjectIdsObject);
    }



    ngOnChanges() {

        for(let $i = 0; $i < this.UsuarioConhecimentoList.length; $i++) {

            this.JsonObjectIdsObject.ConhecimentoIds.push(this.UsuarioConhecimentoList[$i].ConhecimentoId);

        }


       this.categoriaConhecimentoService.get().subscribe((res) => {

           this.categoriaConhecimentos = res;
      
       }, err => {

       })
    }

}