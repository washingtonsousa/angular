import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Status } from "../../models/status.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class StatusService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<Status> {
            return this.http.get<Status>(globals.apiUrl + "Status/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Status/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Status) : Observable<Status>{
       return  this.http.put<Status>(globals.apiUrl + "Status/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Status) {
       return  this.http.put<Status>(globals.apiUrl + "Status/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.put<Status>(globals.apiUrl + "Status/Delete/"+ id, {headers: this.httpHeaders});
    }
}