import {Component, ViewChild} from '@angular/core';
import { LoginService } from '../../login/login.service';
import { Router } from '@angular/router';
import { SideMenuComponent } from '../sideMenu/side-menu.component';


@Component({
selector: 'top-menu',
templateUrl: 'top-menu.html'
})
export class TopMenuComponent {
public username: string = localStorage.getItem("username");

@ViewChild('sideMenu') public sideMenu: SideMenuComponent;

  constructor(private loginService: LoginService, private Router: Router) {
      
  }

  logOut() 
  {

    this.loginService.logOut();
    this.Router.navigate(['/login']);

  }

}