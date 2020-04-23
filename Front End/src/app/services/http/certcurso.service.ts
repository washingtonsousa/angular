import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { CertCurso } from "../../models/cert-curso.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class CertCursoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<CertCurso> {
            return this.http.get<CertCurso>(globals.apiUrl + "CertCurso/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<CertCurso[]> {
        return this.http.get<CertCurso[]>(globals.apiUrl + "CertCurso/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: CertCurso) : Observable<CertCurso>{
       return  this.http.put<CertCurso>(globals.apiUrl + "CertCurso/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: CertCurso) {
       return  this.http.post<CertCurso>(globals.apiUrl + "CertCurso/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<CertCurso>(globals.apiUrl + "CertCurso/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}