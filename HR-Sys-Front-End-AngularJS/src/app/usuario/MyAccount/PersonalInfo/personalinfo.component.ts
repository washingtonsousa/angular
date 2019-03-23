import { Component, OnInit, ViewChild } from "@angular/core";
import { UsuarioModel } from "../../../models/Usuario.model";
import { CargoModel } from "../../../models/Cargo.model";
import { NivelAcessoModel } from "../../../models/NivelAcesso.model";
import { StatusModel } from "../../../models/Status.model";
import { ActivatedRoute } from "@angular/router";
import { UsuarioService } from "../../../services/http/usuario.service";
import { DateTimeAdapterService } from "../../../adapters/dateTime.adapter";


@Component({
    selector: 'personal-info',
    templateUrl: 'personal-info.html'
})
export class PersonalInfoComponent implements OnInit {
    
    
@ViewChild('loadingIcon') public loadingIcon: any;

public usuarioModel: UsuarioModel = new UsuarioModel();
public cargos: CargoModel[] = [];
public nivelAcessos: NivelAcessoModel[] = [];
public estadosCivis = [{'Nome': 'Solteiro'}, {'Nome':'Casado'}, {'Nome' : 'Viúvo'} , {'Nome': 'Divorciado'}];
public Status: StatusModel[] = [];
public selectizeIdNomeConfig:any;
public selectizeIdNivelConfig:any;
public selectizeNomeNomeConfig:any;


  constructor(private route: ActivatedRoute, 
private usuarioService: UsuarioService,
private dateAdapter: DateTimeAdapterService
        ) {}


  updateEndereco(event) {
       this.usuarioModel.Endereco = event;
  }

  
  ngOnInit() {
this.loadingIcon.show();
     

          this.usuarioService.getSingle(parseInt(localStorage.getItem("user_id"))).subscribe((res: UsuarioModel) => {

              this.usuarioModel = res;

              this.usuarioModel.DataNasc = this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataNasc, "yyyy-mm-dd","-","-");
              this.usuarioModel.DataAdmissao = this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.DataAdmissao, "yyyy-mm-dd","-","-");
              this.usuarioModel.Data_Demissao = this.dateAdapter.dateTimeStringToStringDate(this.usuarioModel.Data_Demissao, "yyyy-mm-dd","-","-");

              this.loadingIcon.hide();
              });

      

  }


}