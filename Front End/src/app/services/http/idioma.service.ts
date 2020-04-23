import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Idioma } from "../../models/idioma.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class IdiomaService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<Idioma> {
            return this.http.get<Idioma>(globals.apiUrl + "Idioma/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Idioma/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: Idioma) : Observable<Idioma>{
       return  this.http.put<Idioma>(globals.apiUrl + "Idioma/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Idioma) {
       return  this.http.post<Idioma>(globals.apiUrl + "Idioma/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Idioma>(globals.apiUrl + "Idioma/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}