import {Routes, RouterModule} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {LoggedInGuard} from './login/loggedin_guard';
import { UsuarioIndexComponent } from './usuario/Index/usuario-index.component';
import { PersonalInfoComponent } from './usuario/MyAccount/PersonalInfo/personalinfo.component';
import {HomeComponent} from './home/home.component';
import { QualificationsComponent } from './usuario/MyAccount/Qualifications/qualifications.component';
import { AreaIndexComponent } from './area/Index/AreaIndex.Component';
import { DepartamentoIndexComponent } from './departamento/Index/DepartamentoIndex.Component';
import { CargoIndexComponent } from './cargo/Index/cargo-index.component';
import { ConhecimentoIndexComponent } from './conhecimento/Index/ConhecimentoIndex.Component';
import { DocumentListComponent } from './usuario/MyAccount/Documents/documentList.component';
import { ArquivosIndexComponent } from './arquivos/Index/ArquivosIndex.component';
import { UploadPanelComponent } from './arquivos/Upload/panel/upload-panel.component';
import { AdministratorGuard } from './login/administrator_guard';
import { LogListComponent } from './logs/log-list.component';
import { NotFoundComponent } from './home/notfound.component';

const routes : Routes = [
{path: '', component: HomeComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'usuarios', component: UsuarioIndexComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'areas', component: AreaIndexComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'departamentos', component: DepartamentoIndexComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'cargos', component: CargoIndexComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'conhecimentos', component: ConhecimentoIndexComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'arquivos', component:  ArquivosIndexComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'arquivos/upload', component: UploadPanelComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'logs', component: LogListComponent, canActivate: [LoggedInGuard, AdministratorGuard]},
{path: 'myaccount/personalinfo', component: PersonalInfoComponent, canActivate: [LoggedInGuard]},
{path: 'myaccount/qualifications', component: QualificationsComponent, canActivate: [LoggedInGuard]},
{path: 'myaccount/documentos', component: DocumentListComponent, canActivate: [LoggedInGuard]},
{path: 'login', component: LoginComponent},
{path: '**', component: NotFoundComponent}
];



export const Routing = RouterModule.forRoot(routes);