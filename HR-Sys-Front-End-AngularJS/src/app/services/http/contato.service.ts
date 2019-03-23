import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { ContatoModel } from "../../models/Contato.model";
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

    getSingle(id : number) : Observable<ContatoModel> {
            return this.http.get<ContatoModel>(globals.apiUrl + "Contato/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<ContatoModel[]> {
        return this.http.get<ContatoModel[]>(globals.apiUrl + "Contato/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: ContatoModel) : Observable<ContatoModel>{
       return  this.http.put<ContatoModel>(globals.apiUrl + "Contato/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: ContatoModel) {
       return  this.http.post<ContatoModel>(globals.apiUrl + "Contato/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<ContatoModel>(globals.apiUrl + "Contato/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}