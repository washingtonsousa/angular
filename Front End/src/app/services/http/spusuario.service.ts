import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';
import { Injectable } from "@angular/core";
import { SPUser } from "../../models/spuser.model";

@Injectable()
export class SPUsersService {
    
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"

            })
    }

    getSingle(id : number) : Observable<SPUser> {
            return this.http.get<SPUser>(globals.apiUrl + "SPUsers/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<SPUser[]> {
        return this.http.get<SPUser[]>(globals.apiUrl + "SPUsers/Get", {headers: this.httpHeaders});
    }

    put(SPUsers: SPUser) : Observable<SPUser>{
       return  this.http.put<SPUser>(globals.apiUrl + "SPUsers/Put", SPUsers, {headers: this.httpHeaders});
    }

    post(SPUsers: SPUser) {
       return  this.http.post<SPUser>(globals.apiUrl + "SPUsers/Post", SPUsers, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete(globals.apiUrl + "SPUsers/Delete/"+ id, {headers: this.httpHeaders});
    }
    
}