import { NgModule } from "@angular/core";
import { UsuarioHubService } from "../services/http/usuarioHub.service";
import { UsuarioService } from "../services/http/usuario.service";
import { UsuarioIndexComponent } from "./Index/usuario-index.component";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { MainContainerModule } from "../main_container/main_container.module";
import { CardUsuarioComponent } from "./CardUsuario/card-usuario.component";
import { UsuariosFilterPipe } from "../pipe/usuarios-filter-pipe.pipe";
import { PanelsModule} from '../panels/panels.module';
import { UsuarioSubscribeComponent } from "./UsuarioSubscribe/usuario-subscribe.component";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoadersModule } from "../loaders/loaders.module";
import { NgSelectizeModule} from 'ng-selectize';
import { CargoService } from "../services/http/cargo.service";
import { NivelAcessoService } from "../services/http/nivel-acesso.service";
import { StatusService } from "../services/http/status.service";
import { NgbModule, NgbDateParserFormatter} from '@ng-bootstrap/ng-bootstrap';
import { DateTimeAdapterService } from "../adapters/dateTime.adapter";
import { NgbDateCustomParserFormatter } from "../adapters/ngbcustomparseformatter.adapter";
import { ProfilePictureService } from "../profilePicture/profile-picture.service";
import { MyAccountComponent } from "./MyAccount/my-account.component";
import { RouterModule } from "@angular/router";
import { ProfilePictureModule } from "../profilePicture/profile-picture.module";
import { PersonalInfoComponent } from "./MyAccount/PersonalInfo/personalinfo.component";
import { VisualComponentsModule } from "../visualcomponents/visualcomponents.module";
import { QualificationsComponent } from "./MyAccount/Qualifications/qualifications.component";
import { ContatoService } from "../services/http/contato.service";
import { ContatoContainerComponent } from "./MyAccount/PersonalInfo/Contato/contato_form.component";
import { ContatoBlockComponent } from "./MyAccount/PersonalInfo/Contato/contato_block.component";
import { EnderecoFormComponent } from "./MyAccount/PersonalInfo/Endereco/endereco_form.component";
import { EnderecoService } from "../services/http/endereco.service";
import { ResumoFormComponent } from "./MyAccount/Qualifications/Resumo/resumo_form.component";
import { ResumoService } from "../services/http/resumo.service";
import { ResumoBlockComponent } from "./MyAccount/Qualifications/Resumo/resumo_block.component";
import { FormAcademicaFormComponent } from "./MyAccount/Qualifications/FormAcademicas/formacademica_form.component";
import { FormAcademicaService } from "../services/http/FormAcademica.service";
import { FormAcademicaBlockComponent } from "./MyAccount/Qualifications/FormAcademicas/formacademica_block.component";
import { CertCursoFormComponent } from "./MyAccount/Qualifications/CertCursos/certcurso_form.component ";
import { CertCursoBlockComponent } from "./MyAccount/Qualifications/CertCursos/certcurso_block.component ";
import { CertCursoService } from "../services/http/CertCurso.service";
import { UsuarioConhecimentoFormComponent } from "./MyAccount/Qualifications/Conhecimentos/usuarioconhecimento_form.component";
import { UsuarioConhecimentoService } from "../services/http/usuarioconhecimento.service";
import { ConhecimentoService } from "../services/http/conhecimento.service";
import { ModalModule, TooltipModule } from 'ngx-bootstrap';
import { IdiomaService } from "../services/http/Idioma.service";
import { IdiomaFormComponent } from "./MyAccount/Qualifications/Idiomas/idioma_form.component";
import { IdiomaBlockComponent } from "./MyAccount/Qualifications/Idiomas/idioma_block.component";
import { CustomModalsModule } from "../custommodals/custommodals.module";
import { ProfilePhotoFormComponent } from "./MyAccount/PersonalInfo/profilePhotoForm.component";
import { SPUsersService } from "../services/http/spusuario.service";
import { ExpProfissionalBlockComponent } from "./MyAccount/Qualifications/ExpProfissional/expprofissional_block.component";
import { ExpProfissionalComponent } from "./MyAccount/Qualifications/ExpProfissional/expprofissional_form.component";
import { ExpProfissionalService } from "../services/http/ExpProfissional.service";
import { AnimatedElementsModule } from "../animatedelements/animatedelements.module";
import { DepartamentoService } from "../services/http/departamento.service";
import { AreaService } from "../services/http/area.service";
import { DepartamentoModule } from "../departamento/departamento.module";
import { CustomPipesModule } from "../pipe/custom-pipes.module";
import { DocumentListComponent } from "./MyAccount/Documents/documentList.component";
import { ArquivoService } from "../services/http/arquivos.service";
import { ViewersModule } from "../viewers/viewers.module";
import { ArquivosModule } from "../arquivos/arquivos.module";
import { UsuarioProfileComponent } from "./UsuarioProfile/usuario-profile.component";
import { CategoriaConhecimentoService } from "../services/http/categoriaconhecimento.service";
import {NgxPaginationModule} from 'ngx-pagination'; 

@NgModule({
providers: [UsuarioHubService, 
            ContatoService,
            CategoriaConhecimentoService,
            ArquivoService,
            UsuarioService, 
            ExpProfissionalService,
            SPUsersService,
            ProfilePictureService, 
            CargoService, 
            NivelAcessoService,
            StatusService, 
            DateTimeAdapterService,
            EnderecoService, 
            IdiomaService,
            ResumoService, 
            CertCursoService, 
            DepartamentoService,
            ConhecimentoService, 
            UsuarioConhecimentoService,
            FormAcademicaService,
            AreaService,

    {provide: NgbDateParserFormatter, useClass:NgbDateCustomParserFormatter}],

    imports: [BrowserModule, 
        NgxPaginationModule,
        CustomModalsModule,
        DepartamentoModule,
        ModalModule, 
        ArquivosModule,
        ViewersModule,
        CustomPipesModule,
        RouterModule, 
        ReactiveFormsModule, 
        TooltipModule, 
        ProfilePictureModule, 
        VisualComponentsModule, 
        ReactiveFormsModule, 
        CommonModule, 
        MainContainerModule, 
        NgbModule, 
        PanelsModule, 
        FormsModule, 
        AnimatedElementsModule,
        ReactiveFormsModule,
        LoadersModule, 
        NgSelectizeModule],

    exports: [UsuarioIndexComponent, 
        ResumoBlockComponent, 
        ContatoContainerComponent,  
        UsuarioConhecimentoFormComponent,
        FormAcademicaFormComponent,  
        CertCursoBlockComponent,
        IdiomaBlockComponent, 
        IdiomaFormComponent,
        CardUsuarioComponent, 
        ResumoFormComponent,
        EnderecoFormComponent, 
        FormAcademicaBlockComponent, 
        CertCursoFormComponent,
        MyAccountComponent, 
        ExpProfissionalBlockComponent,
        ExpProfissionalComponent,
        UsuarioSubscribeComponent,
        PersonalInfoComponent],

    declarations: [UsuarioIndexComponent,
        DocumentListComponent,
        ProfilePhotoFormComponent,
        ResumoBlockComponent, 
        FormAcademicaFormComponent, 
        ExpProfissionalBlockComponent,
        ExpProfissionalComponent,
        FormAcademicaBlockComponent,
        CertCursoBlockComponent, 
        UsuarioProfileComponent,
        UsuarioConhecimentoFormComponent,
        IdiomaBlockComponent, 
        IdiomaFormComponent,
        CardUsuarioComponent, 
        ContatoContainerComponent, 
        EnderecoFormComponent, 
        CertCursoFormComponent,
        ContatoBlockComponent, 
        MyAccountComponent, 
        QualificationsComponent, 
        UsuarioSubscribeComponent, 
        PersonalInfoComponent, 
        ResumoFormComponent,
        UsuariosFilterPipe]
})
export class UsuarioModule {}
