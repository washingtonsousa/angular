import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { UsuarioConhecimento } from "../../models/usuario-conhecimento.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class UsuarioConhecimentoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<UsuarioConhecimento> {
            return this.http.get<UsuarioConhecimento>(globals.apiUrl + "UsuarioConhecimento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<UsuarioConhecimento[]> {
        return this.http.get<UsuarioConhecimento[]>(globals.apiUrl + "UsuarioConhecimento/Get", {headers: this.httpHeaders});
    }

    post(object: {}) {
       return  this.http.post<{}>(globals.apiUrl + "UsuarioConhecimento/PostSingle", object, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<UsuarioConhecimento>(globals.apiUrl + "UsuarioConhecimento/Delete/"+ id, {headers: this.httpHeaders});
    }
}