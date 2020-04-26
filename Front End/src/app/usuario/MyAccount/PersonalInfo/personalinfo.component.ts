import { Component, OnInit, ViewChild } from "@angular/core";
import { Usuario } from "../../../models/usuario.model";
import { Cargo } from "../../../models/cargo.model";
import { NivelAcesso } from "../../../models/nivel-acesso.model";
import { Status } from "../../../models/status.model";
import { ActivatedRoute } from "@angular/router";
import { UsuarioService } from "../../../services/http/usuario.service";
import { DateTimeAdapterService } from "../../../adapters/dateTime.adapter";
import { LoadingIconService } from "src/app/services/emitters/loading-icon.service";


@Component({
  selector: 'personal-info',
  templateUrl: 'personal-info.html'
})
export class PersonalInfoComponent implements OnInit {



  public usuarioModel: Usuario = new Usuario();
  public cargos: Cargo[] = [];
  public nivelAcessos: NivelAcesso[] = [];
  public estadosCivis = [{ 'Nome': 'Solteiro' }, { 'Nome': 'Casado' }, { 'Nome': 'Viúvo' }, { 'Nome': 'Divorciado' }];
  public Status: Status[] = [];
  public selectizeIdNomeConfig: any;
  public selectizeIdNivelConfig: any;
  public selectizeNomeNomeConfig: any;


  constructor(private route: ActivatedRoute,
    private usuarioService: UsuarioService,
    private dateAdapter: DateTimeAdapterService
  ) { }


  updateEndereco(event) {
    this.usuarioModel.Endereco = event;
  }


  ngOnInit() {
    LoadingIconService.show();


    this.usuarioService.getSingle(parseInt(localStorage.getItem("user_id"))).subscribe((res: Usuario) => {

      this.usuarioModel = res;

      this.usuarioModel.DataNasc = this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataNasc, "yyyy-mm-dd", "-", "-");
      this.usuarioModel.DataAdmissao = this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataAdmissao, "yyyy-mm-dd", "-", "-");
      this.usuarioModel.Data_Demissao = this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.Data_Demissao, "yyyy-mm-dd", "-", "-");

      LoadingIconService.hide();
    });



  }


}