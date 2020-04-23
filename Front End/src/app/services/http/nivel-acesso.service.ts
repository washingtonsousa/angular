import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { NivelAcesso } from "../../models/nivel-acesso.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class NivelAcessoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<NivelAcesso> {
            return this.http.get<NivelAcesso>(globals.apiUrl + "NivelAcesso/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "NivelAcesso/Get", {headers: this.httpHeaders});
    }

    put(Usuario: NivelAcesso) : Observable<NivelAcesso>{
       return  this.http.put<NivelAcesso>(globals.apiUrl + "NivelAcesso/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: NivelAcesso) {
       return  this.http.put<NivelAcesso>(globals.apiUrl + "NivelAcesso/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.put<NivelAcesso>(globals.apiUrl + "NivelAcesso/Delete/"+ id, {headers: this.httpHeaders});
    }
}