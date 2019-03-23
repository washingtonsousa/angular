import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { ExpProfissionalModel } from "../../models/ExpProfissional.model";
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

    getSingle(id : number) : Observable<ExpProfissionalModel> {
            return this.http.get<ExpProfissionalModel>(globals.apiUrl + "ExpProfissional/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<ExpProfissionalModel[]> {
        return this.http.get<ExpProfissionalModel[]>(globals.apiUrl + "ExpProfissional/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: ExpProfissionalModel) : Observable<ExpProfissionalModel>{
       return  this.http.put<ExpProfissionalModel>(globals.apiUrl + "ExpProfissional/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: ExpProfissionalModel) {
       return  this.http.post<ExpProfissionalModel>(globals.apiUrl + "ExpProfissional/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<ExpProfissionalModel>(globals.apiUrl + "ExpProfissional/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}