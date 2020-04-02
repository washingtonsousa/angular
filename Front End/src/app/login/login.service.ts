import {Injectable} from '@angular/core';
import {HttpHeaders, HttpClient} from '@angular/common/http';
import {AuthenticationModel} from '../models/authentication.model';
import {Observable, BehaviorSubject} from 'rxjs';
import * as globals from '../globals/variables';
import { UserModel } from '../models/userModel.model';

@Injectable()
export class LoginService {

httpHeaders : HttpHeaders;

public _loggedIn: BehaviorSubject<boolean> = new BehaviorSubject(false);
public _administrator: BehaviorSubject<boolean> = new BehaviorSubject(false);
public loggedIn: Observable<boolean> = this._loggedIn.asObservable();
public administrator: Observable<boolean> = this._administrator.asObservable();

constructor(private http: HttpClient) {

this.httpHeaders = new HttpHeaders({

"Content-Type": "application/x-www-form-urlencoded"


});


}


public Authenticate(User : string, Password: string) : Observable<UserModel> {

let login_model = new AuthenticationModel();
login_model.username = User;
login_model.password = Password;

let params = new URLSearchParams();
  
  params.set("client_id",  login_model.client_id);
  params.set("client_secret",  login_model.client_secret);
  params.set("grant_type",  login_model.grant_type);
  params.set("username",  login_model.username);
  params.set("password",  login_model.password);


return this.http.post<UserModel>(globals.apiUrl + 'token', params.toString() , {headers : this.httpHeaders});

}


validateToken() : Observable<any> {

  return new Observable((observer) => {

    
    var now: Date = new Date();
    var expiration = new Date(localStorage.getItem('expire_date'));
    var timeout = expiration.getTime() - now.getTime();
  

   if(timeout >= 0) {

    observer.next(timeout);

    observer.complete();
    
   } else {
    observer.error("Token expired");
   }

  })
}


public logOut() {

  localStorage.removeItem('access_token');
  localStorage.removeItem('email');
  localStorage.removeItem('user_id');
  localStorage.removeItem('username');
  localStorage.removeItem('expires_in');
  localStorage.removeItem('expire_date');
  localStorage.removeItem('access_level');

}

public isLoggedIn() {
    
    let token = localStorage.getItem('access_token');

    if(token) {  
     
      this._loggedIn.next(true);

    } else {

      this._loggedIn.next(false);

    }

    return this._loggedIn.getValue();
  }


  public isAdministrator() {
    
    let access_level = localStorage.getItem('access_level');

    if(access_level == "Administrador") {  
     
      this._administrator.next(true);

    } else {

      this._administrator.next(false);

    }

    return this._administrator.getValue();
  }


}