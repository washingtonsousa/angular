import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { FormAcademicaModel } from "../../models/FormAcademica.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class FormAcademicaService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<FormAcademicaModel> {
            return this.http.get<FormAcademicaModel>(globals.apiUrl + "FormAcademica/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<FormAcademicaModel[]> {
        return this.http.get<FormAcademicaModel[]>(globals.apiUrl + "FormAcademica/GetSingle", {headers: this.httpHeaders});
    }

    put(FormAcademica: FormAcademicaModel) : Observable<FormAcademicaModel>{
       return  this.http.put<FormAcademicaModel>(globals.apiUrl + "FormAcademica/PutSingle", FormAcademica, {headers: this.httpHeaders});
    }

    post(FormAcademica: FormAcademicaModel) {
       return  this.http.post<FormAcademicaModel>(globals.apiUrl + "FormAcademica/PostSingle", FormAcademica, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<FormAcademicaModel>(globals.apiUrl + "FormAcademica/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}