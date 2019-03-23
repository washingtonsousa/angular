import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { AreaModel } from "../../models/Area.model";
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

    getSingle(id : number) : Observable<AreaModel> {
            return this.http.get<AreaModel>(globals.apiUrl + "Area/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Area/Get", {headers: this.httpHeaders});
    }

    put(Usuario: AreaModel) : Observable<AreaModel>{
       return  this.http.put<AreaModel>(globals.apiUrl + "Area/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: AreaModel) {
       return  this.http.post<AreaModel>(globals.apiUrl + "Area/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<AreaModel>(globals.apiUrl + "Area/Delete/"+ id, {headers: this.httpHeaders});
    }
}