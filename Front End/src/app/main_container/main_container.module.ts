import { NgModule } from "@angular/core";
import { TopMenuComponent } from "./topMenu/top-menu.component";
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import { MainContainerComponent } from "./main_container.component";
import { RouterModule } from "@angular/router";
import {LoginService} from '../login/login.service';
import { ProfilePictureModule } from "../profilePicture/profile-picture.module";
import { SideMenuComponent } from "./sideMenu/side-menu.component";
import { BsDropdownModule } from 'ngx-bootstrap';
import { DefaultPageComponent } from "./defaultPageContainer/default-page-container.component";
import { ContainerWithFixedSideNavComponent } from "./containerWithNav/containerwithfixedsidenav.component";

@NgModule({
    providers: [LoginService],
    imports: [BrowserModule, CommonModule, BsDropdownModule, RouterModule, ProfilePictureModule],
    declarations: [TopMenuComponent, MainContainerComponent, DefaultPageComponent, SideMenuComponent, ContainerWithFixedSideNavComponent],
    exports: [TopMenuComponent, MainContainerComponent, DefaultPageComponent, SideMenuComponent, ContainerWithFixedSideNavComponent]
})
export class MainContainerModule {}