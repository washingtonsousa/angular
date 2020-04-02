import { NgModule } from "@angular/core";
import {LoginComponent} from './login.component';
import {FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';  
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from "./login.service";
import { LoadersModule } from "../loaders/loaders.module";

@NgModule({
providers: [LoginService],
imports: [RouterModule, FormsModule, CommonModule, HttpClientModule, LoadersModule],
exports: [LoginComponent],
declarations: [LoginComponent]
})
export class LoginModule {}