import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Departamento } from "../../models/departamento.model";
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

    getSingle(id : number) : Observable<Departamento> {
            return this.http.get<Departamento>(globals.apiUrl + "Departamento/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Departamento/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Departamento) : Observable<Departamento>{
       return  this.http.put<Departamento>(globals.apiUrl + "Departamento/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Departamento) {
       return  this.http.post<Departamento>(globals.apiUrl + "Departamento/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Departamento>(globals.apiUrl + "Departamento/Delete/"+ id, {headers: this.httpHeaders});
    }
}