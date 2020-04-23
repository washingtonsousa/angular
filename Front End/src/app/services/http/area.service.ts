import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Area } from "../../models/Area.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class AreaService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<Area> {
            return this.http.get<Area>(globals.apiUrl + "Area/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Area/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Area) : Observable<Area>{
       return  this.http.put<Area>(globals.apiUrl + "Area/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Area) {
       return  this.http.post<Area>(globals.apiUrl + "Area/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Area>(globals.apiUrl + "Area/Delete/"+ id, {headers: this.httpHeaders});
    }
}