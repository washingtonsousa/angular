import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Cargo } from "../../models/cargo.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class CargoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
   
            })
    }

    getSingle(id : number) : Observable<Cargo> {
            return this.http.get<Cargo>(globals.apiUrl + "Cargo/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<Cargo[]> {
        return this.http.get<Cargo[]>(globals.apiUrl + "Cargo/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Cargo) : Observable<Cargo>{
       return  this.http.put<Cargo>(globals.apiUrl + "Cargo/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Cargo) {
       return  this.http.post<Cargo>(globals.apiUrl + "Cargo/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Cargo>(globals.apiUrl + "Cargo/Delete/"+ id, {headers: this.httpHeaders});
    }
}