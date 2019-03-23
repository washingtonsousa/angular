import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { ConhecimentoModel } from "../../models/Conhecimento.model";
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

    getSingle(id : number) : Observable<ConhecimentoModel> {
            return this.http.get<ConhecimentoModel>(globals.apiUrl + "Conhecimento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<ConhecimentoModel[]> {
        return this.http.get<ConhecimentoModel[]>(globals.apiUrl + "Conhecimento/Get", {headers: this.httpHeaders});
    }

    put(Usuario: ConhecimentoModel) : Observable<ConhecimentoModel>{
       return  this.http.put<ConhecimentoModel>(globals.apiUrl + "Conhecimento/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: ConhecimentoModel) {
       return  this.http.post<ConhecimentoModel>(globals.apiUrl + "Conhecimento/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<ConhecimentoModel>(globals.apiUrl + "Conhecimento/Delete/"+ id, {headers: this.httpHeaders});
    }
}