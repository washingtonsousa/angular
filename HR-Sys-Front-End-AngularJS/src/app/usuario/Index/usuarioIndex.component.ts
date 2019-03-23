import { Component, OnInit, NgZone, ViewChild, AfterViewInit } from "@angular/core";
import { UsuarioService } from "../../services/http/usuario.service";
import { UsuarioHubService } from "../../services/http/usuarioHub.service";
import { UsuarioModel } from "../../models/Usuario.model";
import { CargoService } from "../../services/http/cargo.service";
import { DepartamentoService } from "../../services/http/departamento.service";
import { AreaService } from "../../services/http/area.service";
import { Filterable } from "../../classTemplates/filterable-template";
import { CategoriaConhecimentoService} from "../../services/http/categoriaconhecimento.service";
import { CategoriaConhecimentoModel } from "../../models/CategoriaConhecimento.model";
import { SPUsersService } from "../../services/http/spusuario.service";
import { SPUserModel } from "../../models/SPUser.model";
import { NivelAcessoService } from "../../services/http/nivel-acesso.service";
import { StatusModel } from "../../models/Status.model";
import { NivelAcessoModel } from "../../models/NivelAcesso.model";
import { CargoModel } from "../../models/Cargo.model";
import { StatusService } from "../../services/http/status.service";
import { MaskedSKFoldingCubeComponent } from "../../loaders/masked-sk-folding-cube.component";

@Component({
templateUrl: 'index.html',
selector: 'usuarioIndex'
})
export class UsuarioIndexComponent extends Filterable implements AfterViewInit{

public Usuarios: UsuarioModel[];
@ViewChild('loadingIcon') public loadingIcon: MaskedSKFoldingCubeComponent;

public cargos: CargoModel[] = [];
public nivelacessos: NivelAcessoModel[] = [];
public status: StatusModel[] = [];
public departamentos: any;
public areas: any;
public categoriaConhecimentos: CategoriaConhecimentoModel[] = [];
public spUsers: SPUserModel[] = [];


constructor(private usuarioService: UsuarioService, 
  private usuarioHubService: UsuarioHubService, 
  public nivelAcessoService: NivelAcessoService,
  public statusService: StatusService,
  private spUserService: SPUsersService,
  private cargoService: CargoService,
  private categoriaConhecimentoService: CategoriaConhecimentoService, 
  private departamentoService: DepartamentoService, 
  private areaService: AreaService,

  public zone: NgZone) {

      super({

        Nome : "",
        AreaNome: "",
        CargoNome: "",
        DepartamentoNome: "",
        ConhecimentoIds: []
      
      });

      this.limit = 6;

     this.initializeHubService();

}


OnCheck(value) {


  if(!this.filterQueryHandler.ConhecimentoIds.includes(value)) {
    this.filterQueryHandler.ConhecimentoIds.push(value);
  } else {

    for(let i = 0; i < this.filterQueryHandler.ConhecimentoIds.length; i++) {

        if(this.filterQueryHandler.ConhecimentoIds[i] == value) {

          this.filterQueryHandler.ConhecimentoIds.splice(i, 1);
        }
      
    }
    
  }

 
}



public trackUsuarios(index, usuario) {
   if(!usuario) return null;
  return usuario.Id;

}


private initializeHubService() {

    this.usuarioHubService.proxy.on('newUsuario', (data) => {
    
      this.zone.run(() =>  {this.Usuarios.push(data); this.Usuarios.sort()});
    
    });


    this.usuarioHubService.proxy.on('updateUsuario', (data) => {

      this.zone.run(() => {

        for(var $i = 0; $i < this.Usuarios.length; $i++) {
         
          if(this.Usuarios[$i].Id == data.Id) {
            this.Usuarios[$i] = data;
            this.Usuarios = this.Usuarios;
  
          }  
        }
      });
    
    });

    this.usuarioHubService.proxy.on('deleteUsuario', (data) => {
      
      this.zone.run(() => {

      for(var $i = 0; $i < this.Usuarios.length; $i++) {
       
        if(this.Usuarios[$i].Id == data.Id) {
    
          this.Usuarios.splice($i, 1);
          this.Usuarios = this.Usuarios;

        }  
      }
    });


    });

  this.usuarioHubService.start();
  
}



ngAfterViewInit() {

  this.loadingIcon.show();

  this.cargoService.get().subscribe((res) => { 
    
  this.cargos = res;

  this.departamentoService.get().subscribe((res) => {
    
  this.departamentos = res;

  this.areaService.get().subscribe((res) => {
    
  this.areas = res;

  this.categoriaConhecimentoService.get().subscribe(res => { 
    
  this.categoriaConhecimentos = res; 

  this.nivelAcessoService.get().subscribe(res => { 
    
  this.nivelacessos = res; 

  this.statusService.get().subscribe((res) => { 
    
  this.status = res; 


  this.usuarioService.get().subscribe((res: UsuarioModel[]) => {



      
  this.spUserService.get().subscribe((spUsers: SPUserModel[]) => {
    
    this.spUsers = spUsers; 
    
  });
            this.Usuarios = res;
    
            this.loadingIcon.hide();
            
            this.Usuarios = this.Usuarios.sort((a, b) =>  { if (a.Nome < b.Nome) return -1;
            else if (a.Nome > b.Nome) return 1;
            else return 0;});

                

                  });

                });

              });

          });

        });

      });

    });

}

}