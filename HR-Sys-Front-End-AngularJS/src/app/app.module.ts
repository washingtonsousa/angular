import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {LoggedInGuard} from './login/loggedin_guard';
import { RouterModule } from '@angular/router';
import { Routing } from './app.routes';
import {LoginModule} from './login/login.module';
import { UsuarioModule } from './usuario/usuario.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { MainContainerModule } from './main_container/main_container.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeModule } from './home/home.module';
import { AreaModule } from './area/area.module';
import { DepartamentoModule } from './departamento/departamento.module';
import { CargoModule } from './cargo/cargo.module';
import { ConhecimentoModule } from './conhecimento/conhecimento.module';
import { ArquivosModule } from './arquivos/arquivos.module';
import { AdministratorGuard } from './login/administrator_guard';
import { ChartsModule } from 'ng2-charts';
import {LogsModule} from './logs/logs.module';

@NgModule({
  providers: [LoggedInGuard, AdministratorGuard],
  declarations: [AppComponent],
  imports: [BrowserModule, ArquivosModule, ChartsModule, LogsModule,
     MainContainerModule, CargoModule, NgbModule.forRoot(), HomeModule, AreaModule, DepartamentoModule,
     RouterModule, LoginModule,  Routing, BrowserModule, ConhecimentoModule ,
     UsuarioModule, ModalModule.forRoot(), BsDropdownModule.forRoot(),
    TooltipModule.forRoot()], 
  bootstrap: [AppComponent]
})
export class AppModule { }
