import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { IdiomaModel } from "../../models/Idioma.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class IdiomaService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<IdiomaModel> {
            return this.http.get<IdiomaModel>(globals.apiUrl + "Idioma/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Idioma/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: IdiomaModel) : Observable<IdiomaModel>{
       return  this.http.put<IdiomaModel>(globals.apiUrl + "Idioma/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: IdiomaModel) {
       return  this.http.post<IdiomaModel>(globals.apiUrl + "Idioma/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<IdiomaModel>(globals.apiUrl + "Idioma/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}