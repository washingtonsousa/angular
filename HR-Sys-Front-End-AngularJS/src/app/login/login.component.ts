import { Component , ViewChild} from "@angular/core";
import {LoginService} from './login.service';
import {UserModel} from '../models/userModel.model';
import { Router } from "@angular/router";
import { MaskedSKFoldingCubeComponent } from "../loaders/masked-sk-folding-cube.component";

@Component({
templateUrl : 'login.html',
selector: 'loginPage'
})
export class LoginComponent {

public username: string;
public password: string;
public Message: string;
@ViewChild('loaderMask') loaderMask:MaskedSKFoldingCubeComponent;
constructor(private loginService: LoginService, private router: Router) {
}


login(event:Event) {

this.loaderMask.show();

this.loginService.Authenticate(this.username, this.password).subscribe((res: UserModel) => { 
    
 localStorage.setItem('access_token', res.access_token);
 localStorage.setItem('email', res.email);
 localStorage.setItem('user_id', res.user_id.toString());
 localStorage.setItem('username', res.username);
 localStorage.setItem('expires_in', res.expires_in.toString());
 localStorage.setItem('expire_date', new Date(new Date().getTime() + res.expires_in * 1000).toString());
 localStorage.setItem('access_level', res.access_level);

 this.loginService._loggedIn.next(true);
 this.router.navigateByUrl('');

}, (err) => {   this.requestErrorHandler(err);  });

}



private requestErrorHandler(err: any){
    this.Message = err.error.error_description;
    this.loaderMask.hide(); 
}


}