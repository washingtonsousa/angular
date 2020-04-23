import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { CategoriaConhecimento } from "../../models/categoria-conhecimento.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class CategoriaConhecimentoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<CategoriaConhecimento> {
            return this.http.get<CategoriaConhecimento>(globals.apiUrl + "CategoriaConhecimento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<CategoriaConhecimento[]> {
        return this.http.get<CategoriaConhecimento[]>(globals.apiUrl + "CategoriaConhecimento/Get", {headers: this.httpHeaders});
    }

    put(Usuario: CategoriaConhecimento) : Observable<CategoriaConhecimento>{
       return  this.http.put<CategoriaConhecimento>(globals.apiUrl + "CategoriaConhecimento/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: CategoriaConhecimento) {
       return  this.http.post<CategoriaConhecimento>(globals.apiUrl + "CategoriaConhecimento/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<CategoriaConhecimento>(globals.apiUrl + "CategoriaConhecimento/Delete/"+ id, {headers: this.httpHeaders});
    }
}