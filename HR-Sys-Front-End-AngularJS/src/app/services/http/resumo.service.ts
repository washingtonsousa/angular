import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { ResumoModel } from "../../models/Resumo.model";
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

    getSingle(id : number) : Observable<ResumoModel> {
            return this.http.get<ResumoModel>(globals.apiUrl + "Resumo/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Resumo/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: ResumoModel) : Observable<ResumoModel>{
       return  this.http.put<ResumoModel>(globals.apiUrl + "Resumo/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: ResumoModel) {
       return  this.http.post<ResumoModel>(globals.apiUrl + "Resumo/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<ResumoModel>(globals.apiUrl + "Resumo/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}