import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Resumo } from "../../models/resumo.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class ResumoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<Resumo> {
            return this.http.get<Resumo>(globals.apiUrl + "Resumo/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Resumo/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: Resumo) : Observable<Resumo>{
       return  this.http.put<Resumo>(globals.apiUrl + "Resumo/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Resumo) {
       return  this.http.post<Resumo>(globals.apiUrl + "Resumo/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Resumo>(globals.apiUrl + "Resumo/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}