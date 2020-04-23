import { Component, OnInit, NgZone, ViewChild, AfterViewInit, ChangeDetectorRef } from "@angular/core";
import { UsuarioService } from "../../services/http/usuario.service";
import { UsuarioHubService } from "../../services/http/usuarioHub.service";
import { Usuario } from "../../models/usuario.model";
import { CargoService } from "../../services/http/cargo.service";
import { DepartamentoService } from "../../services/http/departamento.service";
import { AreaService } from "../../services/http/area.service";
import { Filterable } from "../../classTemplates/filterable-template";
import { CategoriaConhecimentoService } from "../../services/http/categoriaconhecimento.service";
import { CategoriaConhecimento } from "../../models/categoria-conhecimento.model";
import { SPUsersService } from "../../services/http/spusuario.service";
import { SPUser } from "../../models/spuser.model";
import { NivelAcessoService } from "../../services/http/nivel-acesso.service";
import { Status } from "../../models/status.model";
import { NivelAcesso } from "../../models/nivel-acesso.model";
import { Cargo } from "../../models/cargo.model";
import { StatusService } from "../../services/http/status.service";
import { MaskedSKFoldingCubeComponent } from "../../loaders/masked-sk-folding-cube.component";
import { SidePanelComponent } from "src/app/panels/side-panel.component";
import { ModalContentComponent } from "src/app/custommodals/modalContent.component";

@Component({
  templateUrl: 'index.html',
  selector: 'usuarioIndex'
})
export class UsuarioIndexComponent extends Filterable implements AfterViewInit {

  public Usuarios: Usuario[];
  @ViewChild('loadingIcon') public loadingIcon: MaskedSKFoldingCubeComponent;
  @ViewChild('atualizarUsuarioPainel') public atualizarUsuarioPainel: SidePanelComponent;
  @ViewChild('userProfileModal') public userProfileModal: ModalContentComponent;
  public cargos: Cargo[] = [];
  public nivelacessos: NivelAcesso[] = [];
  public status: Status[] = [];
  public departamentos: any;
  public areas: any;
  public categoriaConhecimentos: CategoriaConhecimento[] = [];
  public spUsers: SPUser[] = [];
  public currentSelectedUsuario = new Usuario();

  constructor(private usuarioService: UsuarioService,
    private usuarioHubService: UsuarioHubService,
    public nivelAcessoService: NivelAcessoService,
    public statusService: StatusService,
    private spUserService: SPUsersService,
    private cargoService: CargoService,
    private categoriaConhecimentoService: CategoriaConhecimentoService,
    private departamentoService: DepartamentoService,
    private areaService: AreaService,
    private changeDetection: ChangeDetectorRef,
    public zone: NgZone) {

    super({

      Nome: "",
      AreaNome: "",
      CargoNome: "",
      DepartamentoNome: "",
      ConhecimentoIds: []

    });

    this.limit = 6;

    this.initializeHubService();

  }

  Edit(usuarioId: number) {

    this.loadingIcon.show();
    this.usuarioService.getSingle(usuarioId).subscribe((usuario: Usuario) => {

      this.currentSelectedUsuario = usuario;
      this.atualizarUsuarioPainel.show();
      this.changeDetection.detectChanges();
      this.loadingIcon.hide();

    });
  }


  
  GetForOpenModal(usuarioId: number) {

    this.loadingIcon.show();
    this.usuarioService.getSingle(usuarioId).subscribe((usuario: Usuario) => {

      this.currentSelectedUsuario = usuario;
      this.userProfileModal.openModal();
      this.changeDetection.detectChanges();
      this.loadingIcon.hide();

    });
  }



  OnCheck(value) {


    if (!this.filterQueryHandler.ConhecimentoIds.includes(value)) {
      this.filterQueryHandler.ConhecimentoIds.push(value);
    } else {

      for (let i = 0; i < this.filterQueryHandler.ConhecimentoIds.length; i++) {

        if (this.filterQueryHandler.ConhecimentoIds[i] == value) {

          this.filterQueryHandler.ConhecimentoIds.splice(i, 1);
        }

      }

    }


  }



  public trackUsuarios(index, usuario) {
    if (!usuario) return null;
    return usuario.Id;

  }


  private initializeHubService() {

    this.usuarioHubService.proxy.on('newUsuario', (data) => {

      this.zone.run(() => { this.Usuarios.push(data); this.Usuarios.sort() });

    });


    this.usuarioHubService.proxy.on('updateUsuario', (data) => {

      this.zone.run(() => {

        for (var $i = 0; $i < this.Usuarios.length; $i++) {

          if (this.Usuarios[$i].Id == data.Id) {
            this.Usuarios[$i] = data;
            this.Usuarios = this.Usuarios;

          }
        }
      });

    });

    this.usuarioHubService.proxy.on('deleteUsuario', (data) => {

      this.zone.run(() => {

        for (var $i = 0; $i < this.Usuarios.length; $i++) {

          if (this.Usuarios[$i].Id == data.Id) {

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


                this.usuarioService.get().subscribe((res: Usuario[]) => {




                  this.spUserService.get().subscribe((spUsers: SPUser[]) => {

                    this.spUsers = spUsers;

                  });
                  this.Usuarios = res;

                  this.loadingIcon.hide();

                  this.Usuarios = this.Usuarios.sort((a, b) => {
                    if (a.Nome < b.Nome) return -1;
                    else if (a.Nome > b.Nome) return 1;
                    else return 0;
                  });



                });

              });

            });

          });

        });

      });

    });

  }

}