import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Contato } from "../../models/Contato.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class ContatoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<Contato> {
            return this.http.get<Contato>(globals.apiUrl + "Contato/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<Contato[]> {
        return this.http.get<Contato[]>(globals.apiUrl + "Contato/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: Contato) : Observable<Contato>{
       return  this.http.put<Contato>(globals.apiUrl + "Contato/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Contato) {
       return  this.http.post<Contato>(globals.apiUrl + "Contato/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Contato>(globals.apiUrl + "Contato/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}