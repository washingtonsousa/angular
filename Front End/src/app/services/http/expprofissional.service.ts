import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { ExpProfissional } from "../../models/exp-profissional.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class ExpProfissionalService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<ExpProfissional> {
            return this.http.get<ExpProfissional>(globals.apiUrl + "ExpProfissional/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<ExpProfissional[]> {
        return this.http.get<ExpProfissional[]>(globals.apiUrl + "ExpProfissional/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: ExpProfissional) : Observable<ExpProfissional>{
       return  this.http.put<ExpProfissional>(globals.apiUrl + "ExpProfissional/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: ExpProfissional) {
       return  this.http.post<ExpProfissional>(globals.apiUrl + "ExpProfissional/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<ExpProfissional>(globals.apiUrl + "ExpProfissional/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}