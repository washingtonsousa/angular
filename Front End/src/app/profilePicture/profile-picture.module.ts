import {NgModule} from '@angular/core';
import { ProfilePictureComponent } from './profile-picture.component';
import { ProfilePictureService } from './profile-picture.service';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

@NgModule({
providers: [ProfilePictureService],
imports:[CommonModule, BrowserModule],
declarations: [ProfilePictureComponent],
exports: [ProfilePictureComponent]
})
export class ProfilePictureModule {

}
