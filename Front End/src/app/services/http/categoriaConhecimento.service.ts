import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { CategoriaConhecimentoModel } from "../../models/CategoriaConhecimento.model";
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

    getSingle(id : number) : Observable<CategoriaConhecimentoModel> {
            return this.http.get<CategoriaConhecimentoModel>(globals.apiUrl + "CategoriaConhecimento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<CategoriaConhecimentoModel[]> {
        return this.http.get<CategoriaConhecimentoModel[]>(globals.apiUrl + "CategoriaConhecimento/Get", {headers: this.httpHeaders});
    }

    put(Usuario: CategoriaConhecimentoModel) : Observable<CategoriaConhecimentoModel>{
       return  this.http.put<CategoriaConhecimentoModel>(globals.apiUrl + "CategoriaConhecimento/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: CategoriaConhecimentoModel) {
       return  this.http.post<CategoriaConhecimentoModel>(globals.apiUrl + "CategoriaConhecimento/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<CategoriaConhecimentoModel>(globals.apiUrl + "CategoriaConhecimento/Delete/"+ id, {headers: this.httpHeaders});
    }
}