import {Injectable} from '@angular/core';
import {Router, CanActivate} from '@angular/router';
import {LoginService} from './../login/login.service';

@Injectable()
export class AdministratorGuard implements CanActivate {

    constructor(private loginService: LoginService, private router: Router) {}

canActivate() {
let isAdministrator = this.loginService.isAdministrator();

if(!isAdministrator) {

    this.router.navigate(['/myaccount/personalinfo/']);

} 
 
return isAdministrator;

}


} 