import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { DepartamentoModel } from "../../models/Departamento.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class DepartamentoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<DepartamentoModel> {
            return this.http.get<DepartamentoModel>(globals.apiUrl + "Departamento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Departamento/Get", {headers: this.httpHeaders});
    }

    put(Usuario: DepartamentoModel) : Observable<DepartamentoModel>{
       return  this.http.put<DepartamentoModel>(globals.apiUrl + "Departamento/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: DepartamentoModel) {
       return  this.http.post<DepartamentoModel>(globals.apiUrl + "Departamento/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<DepartamentoModel>(globals.apiUrl + "Departamento/Delete/"+ id, {headers: this.httpHeaders});
    }
}