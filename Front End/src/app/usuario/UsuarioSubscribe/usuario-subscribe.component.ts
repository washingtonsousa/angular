import { Component, Input, OnInit, ViewChild, NgZone, OnChanges, SimpleChanges } from "@angular/core";
import { Usuario } from "../../models/usuario.model";
import { Cargo } from "../../models/cargo.model";
import { NivelAcesso } from "../../models/nivel-acesso.model";
import { Status } from "../../models/status.model";
import { UsuarioService } from '../../services/http/usuario.service';
import { DateTimeAdapterService } from "../../adapters/dateTime.adapter";
import { SPUser } from "../../models/spuser.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import { ModalConfirmMessageComponent } from "../../custommodals/modalConfirmMessage.component";
import { NgSelectizeHelper } from "../../adapters/ngSelectizeHelper";
import { LoadingIconService } from "src/app/services/emitters/loading-icon.service";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
  selector: '[usuario-subscribe]',
  templateUrl: 'usuario-subscribe.html'
})
export class UsuarioSubscribeComponent implements OnInit, OnChanges {

  @Input() public set SetUsuario(usuario) {

    this.usuarioModel = (usuario == null || usuario == undefined) ? new Usuario() : usuario;

  }
  @Input() public usuarioModel = new Usuario();
  @Input() public submitButtonText: string = "Enviar";
  @Input() public spUsers: SPUser[] = [];
  @Input() public status: Status[] = [];
  @Input() public cargos: Cargo[] = [];
  @Input() public nivelAcessos: NivelAcesso[] = [];
  @Input() public isUpdate: boolean = false;
  @ViewChild('modalConfirmMessage') public modalConfirmMessage: ModalConfirmMessageComponent;


  public cargosAdapted: any[] = [];
  public estadosCivis = [{ 'Nome': 'Solteiro' }, { 'Nome': 'Casado' }, { 'Nome': 'Viúvo' }, { 'Nome': 'Divorciado' }];
  public selectizeIdNomeConfig: any;
  public selectizeIdNivelConfig: any;
  public selectizeNomeNomeConfig: any;
  public selectizeEmailConfig: any;
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

  private initializeComponents() {

    this.initializeFormBuilder();

  }

  private concatCargosForSelectize() {

    for (let cargo of this.cargos) {

      this.cargosAdapted.push({

        Id: cargo.Id,
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
      Validators.pattern("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]{2,64}")]],
      Email_Secundario_Notificacao: [this.usuarioModel.Email_Secundario_Notificacao, [
        Validators.pattern("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]{2,64}")]],
      Sexo: [this.usuarioModel.Sexo, Validators.required],
      Ramal: [this.usuarioModel.Ramal, Validators.required],
      Matricula: [this.usuarioModel.Matricula, Validators.required],
      NivelAcessoId: [this.usuarioModel.NivelAcessoId, Validators.required],
      StatusId: [this.usuarioModel.StatusId, Validators.required],
      CargoId: [this.usuarioModel.CargoId, Validators.required],
      DataAdmissao: [this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataAdmissao, "yyyy-mm-dd", "-", "-"),
      Validators.required],
      DataNasc: [this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataNasc, "yyyy-mm-dd", "-", "-"),
      Validators.required],
      Data_Demissao: [this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.Data_Demissao, "yyyy-mm-dd", "-", "-")],
      EstadoCivil: [this.usuarioModel.EstadoCivil, Validators.required],
      Password: [this.usuarioModel.Password, Validators.required, Validators.minLength(8)]


    });


  }

  onEmailChange($event) {
    console.log(this.cargos);

    for (let i = 0; i < this.spUsers.length; i++) {
      if (this.spUsers[i].Email == $event) {
        this.usuarioFormGroup.controls['Nome'].setValue(this.spUsers[i].DisplayName);
      }
    }
  }

  onDateTimeSelect(key: string, event) {
    this.usuarioFormGroup.controls[key].setValue(event.year + "-" + event.month + "-" + event.day);
  }

  Submit() {

    LoadingIconService.show();

    this.usuarioService.post(this.usuarioFormGroup.value).subscribe((res) => {

      LoadingIconService.hide();
      this.usuarioFormGroup.reset();

      ModalMessageService.open("Inserido com sucesso");


    }, (err: any) => {

      this.usuarioService.put(this.usuarioFormGroup.value).subscribe((res) => {

        LoadingIconService.hide();

        ModalMessageService.open("Atualizado com sucesso");

      }, (err: any) => {

        LoadingIconService.hide();

        ModalMessageService.open("Ocorreu falha ao inserir ou atualizar Usuário erro: " + err.statusText);



      })

    })

  }

  openDeleteConfirmMessage() {
    this.modalConfirmMessage.openModal();
  }

  Delete(Id: number) {

    LoadingIconService.show();

    this.usuarioService.delete(Id).subscribe((res) => {
      LoadingIconService.hide();
      ModalMessageService.open("Deletado com sucesso");

    }, (err) => {
      LoadingIconService.hide();
      ModalMessageService.open("Ocorreu um erro ao tentar deletar, detalhes do erro: código: " + err.error.code + " mensagem: " + err.error.message);

    })

  }


  ngOnChanges(changes: SimpleChanges) {

    this.usuarioModel = (changes.usuarioModel != undefined && changes.usuarioModel != null) ? changes.usuarioModel.currentValue : this.usuarioModel;
    this.ngOnInit();
  }

  ngOnInit() {

    this.initializeComponents();
    this.concatCargosForSelectize();

  }

}