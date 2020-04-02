import {Injectable} from '@angular/core';
import {Router, CanActivate} from '@angular/router';
import {LoginService} from './../login/login.service';

@Injectable()
export class LoggedInGuard implements CanActivate {

    constructor(private loginService: LoginService, private router: Router) {

    }

canActivate() {
let isLoggedIn = this.loginService.isLoggedIn();

if(!isLoggedIn) {

    this.router.navigate(['login']);

} else {
    
    this.loginService.validateToken().subscribe(res => {

        return isLoggedIn;
        
        }, err => {
        
            this.router.navigate(['login']);
          
        
        })
}

return isLoggedIn;

}


} 