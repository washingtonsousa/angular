import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { CertCursoModel } from "../../models/CertCurso.model";
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

    getSingle(id : number) : Observable<CertCursoModel> {
            return this.http.get<CertCursoModel>(globals.apiUrl + "CertCurso/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<CertCursoModel[]> {
        return this.http.get<CertCursoModel[]>(globals.apiUrl + "CertCurso/GetSingle", {headers: this.httpHeaders});
    }

    put(Usuario: CertCursoModel) : Observable<CertCursoModel>{
       return  this.http.put<CertCursoModel>(globals.apiUrl + "CertCurso/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: CertCursoModel) {
       return  this.http.post<CertCursoModel>(globals.apiUrl + "CertCurso/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<CertCursoModel>(globals.apiUrl + "CertCurso/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}