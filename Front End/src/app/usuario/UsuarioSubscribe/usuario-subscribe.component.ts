import { Component , Input, OnInit, ViewChild, NgZone} from "@angular/core";
import { UsuarioModel } from "../../models/Usuario.model";
import { CargoModel } from "../../models/Cargo.model";
import { NivelAcessoModel } from "../../models/NivelAcesso.model";
import { StatusModel } from "../../models/Status.model";
import { UsuarioService } from '../../services/http/usuario.service';
import { DateTimeAdapterService } from "../../adapters/dateTime.adapter";
import { SPUserModel } from "../../models/SPUser.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import { ModalConfirmMessageComponent } from "../../custommodals/modalConfirmMessage.component";
import {NgSelectizeHelper} from "../../adapters/ngSelectizeHelper";

@Component({
    selector: '[usuario-subscribe]',
    templateUrl: 'usuario-subscribe.html'
})
export class UsuarioSubscribeComponent implements OnInit {

@Input() public usuarioModel: UsuarioModel = new UsuarioModel();
@Input() public submitButtonText: string  = "Enviar";
@Input() public spUsers: SPUserModel[] = [];
@Input() public status: StatusModel[] = [];
@Input() public cargos: CargoModel[] = [];
@Input() public nivelAcessos: NivelAcessoModel[] = [];
@Input() public isUpdate: boolean = false;


@ViewChild('loadingIcon') public loadingIcon: any;
@ViewChild('modalMessage') public modalMessage: ModalMessageComponent;
@ViewChild('modalConfirmMessage') public modalConfirmMessage: ModalConfirmMessageComponent;





public cargosAdapted : any[] = [];
public estadosCivis = [{'Nome': 'Solteiro'}, {'Nome':'Casado'}, {'Nome' : 'Viúvo'} , {'Nome': 'Divorciado'}];
public selectizeIdNomeConfig:any;
public selectizeIdNivelConfig:any;
public selectizeNomeNomeConfig:any;
public selectizeEmailConfig:any;
public usuarioFormGroup: FormGroup;

constructor(
  public zone: NgZone,
  public fb: FormBuilder,
  private usuarioService: UsuarioService, 
  private dateAdapter: DateTimeAdapterService) {

    this.selectizeIdNomeConfig = new NgSelectizeHelper("Nome", "Id").build(); 
    this.selectizeNomeNomeConfig = new NgSelectizeHelper("Nome", "Nome").build(); 
    this.selectizeIdNivelConfig = new NgSelectizeHelper("Nivel", "Id").build(); 
    this.selectizeEmailConfig = new NgSelectizeHelper("Email", "Email").build();  

}

private initializeComponents(){

    this.initializeFormBuilder();

}

private concatCargosForSelectize() {

  for(let cargo of this.cargos) {

    this.cargosAdapted.push({

            Id : cargo.Id,
            Nome: cargo.Nome + " - " + cargo.Departamento.Nome 

    })

  }

 this.cargosAdapted = this.cargosAdapted.reverse();

}

initializeFormBuilder() {

  

  this.usuarioFormGroup = this.fb.group({
    
    Id: [this.usuarioModel.Id],
    Nome: [this.usuarioModel.Nome, Validators.required],
    Email: [this.usuarioModel.Email, [Validators.required, 
      Validators.pattern("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,64}")]],
    Email_Secundario_Notificacao: [this.usuarioModel.Email_Secundario_Notificacao, [
      Validators.pattern("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,64}") ] ],
    Sexo: [this.usuarioModel.Sexo, Validators.required],
    Ramal: [this.usuarioModel.Ramal, Validators.required],
    Matricula: [this.usuarioModel.Matricula, Validators.required],
    NivelAcessoId: [this.usuarioModel.NivelAcessoId, Validators.required],
    StatusId: [this.usuarioModel.StatusId, Validators.required],
    CargoId: [this.usuarioModel.CargoId , Validators.required],
    DataAdmissao: [this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataAdmissao, "yyyy-mm-dd","-","-"),
     Validators.required],
    DataNasc: [this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataNasc, "yyyy-mm-dd","-","-"),
     Validators.required],
    Data_Demissao: [this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.Data_Demissao, "yyyy-mm-dd","-","-")],
    EstadoCivil: [this.usuarioModel.EstadoCivil, Validators.required]


  });


}

onEmailChange($event) {
console.log(this.cargos);

  for(let i = 0;i < this.spUsers.length; i++) {
     if(this.spUsers[i].Email == $event) {
       this.usuarioFormGroup.controls['Nome'].setValue(this.spUsers[i].DisplayName);
     }
  }
}

onDateTimeSelect(key:string, event) {
  this.usuarioFormGroup.controls[key].setValue(event.year + "-" + event.month + "-" + event.day);
}

Submit() {

this.loadingIcon.show();

this.usuarioService.post(this.usuarioFormGroup.value).subscribe((res) => {

this.loadingIcon.hide();    
this.usuarioFormGroup.reset();
this.modalMessage.Message= "Inserido com sucesso";
this.modalMessage.openModal();

}, (err:any) => {

  this.usuarioService.put(this.usuarioFormGroup.value).subscribe((res) => {

    this.loadingIcon.hide();  
    this.modalMessage.Message= "Atualizado com sucesso";
    this.modalMessage.openModal();

  }, (err:any) => {

    this.loadingIcon.hide(); 
    this.modalMessage.Message= "Ocorreu falha ao inserir ou atualizar Usuário erro: " + err.statusText;
    this.modalMessage.openModal();

  })
 
})

}

openDeleteConfirmMessage() {
  this.modalConfirmMessage.openModal();
}

Delete(Id: number) {

this.loadingIcon.show();

this.usuarioService.delete(Id).subscribe((res) => {
  this.loadingIcon.hide();   
  this.modalMessage.Message= "Deletado com sucesso";
this.modalMessage.openModal(); 
}, (err) => {  this.loadingIcon.hide(); 

  this.modalMessage.Message= "Ocorreu um erro ao tentar deletar, detalhes do erro: código: " + err.error.code + " mensagem: " + err.error.message;
  this.modalMessage.openModal(); 

})

}

ngOnInit() {

  this.initializeComponents();
  this.concatCargosForSelectize();
  
}

}