import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { FormAcademica } from "../../models/form-academica.model";
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

    getSingle(id : number) : Observable<FormAcademica> {
            return this.http.get<FormAcademica>(globals.apiUrl + "FormAcademica/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<FormAcademica[]> {
        return this.http.get<FormAcademica[]>(globals.apiUrl + "FormAcademica/GetSingle", {headers: this.httpHeaders});
    }

    put(FormAcademica: FormAcademica) : Observable<FormAcademica>{
       return  this.http.put<FormAcademica>(globals.apiUrl + "FormAcademica/PutSingle", FormAcademica, {headers: this.httpHeaders});
    }

    post(FormAcademica: FormAcademica) {
       return  this.http.post<FormAcademica>(globals.apiUrl + "FormAcademica/PostSingle", FormAcademica, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<FormAcademica>(globals.apiUrl + "FormAcademica/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}