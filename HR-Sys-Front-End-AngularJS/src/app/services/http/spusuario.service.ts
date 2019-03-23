import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';
import { Injectable } from "@angular/core";
import { SPUserModel } from "../../models/SPUser.model";

@Injectable()
export class SPUsersService {
    
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"

            })
    }

    getSingle(id : number) : Observable<SPUserModel> {
            return this.http.get<SPUserModel>(globals.apiUrl + "SPUsers/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<SPUserModel[]> {
        return this.http.get<SPUserModel[]>(globals.apiUrl + "SPUsers/Get", {headers: this.httpHeaders});
    }

    put(SPUsers: SPUserModel) : Observable<SPUserModel>{
       return  this.http.put<SPUserModel>(globals.apiUrl + "SPUsers/Put", SPUsers, {headers: this.httpHeaders});
    }

    post(SPUsers: SPUserModel) {
       return  this.http.post<SPUserModel>(globals.apiUrl + "SPUsers/Post", SPUsers, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete(globals.apiUrl + "SPUsers/Delete/"+ id, {headers: this.httpHeaders});
    }
    
}