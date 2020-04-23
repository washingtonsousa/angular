import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Conhecimento } from "../../models/conhecimento.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class ConhecimentoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<Conhecimento> {
            return this.http.get<Conhecimento>(globals.apiUrl + "Conhecimento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<Conhecimento[]> {
        return this.http.get<Conhecimento[]>(globals.apiUrl + "Conhecimento/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Conhecimento) : Observable<Conhecimento>{
       return  this.http.put<Conhecimento>(globals.apiUrl + "Conhecimento/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Conhecimento) {
       return  this.http.post<Conhecimento>(globals.apiUrl + "Conhecimento/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Conhecimento>(globals.apiUrl + "Conhecimento/Delete/"+ id, {headers: this.httpHeaders});
    }
}