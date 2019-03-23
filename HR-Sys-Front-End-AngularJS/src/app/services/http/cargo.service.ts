import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { CargoModel } from "../../models/Cargo.model";
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

    getSingle(id : number) : Observable<CargoModel> {
            return this.http.get<CargoModel>(globals.apiUrl + "Cargo/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<CargoModel[]> {
        return this.http.get<CargoModel[]>(globals.apiUrl + "Cargo/Get", {headers: this.httpHeaders});
    }

    put(Usuario: CargoModel) : Observable<CargoModel>{
       return  this.http.put<CargoModel>(globals.apiUrl + "Cargo/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: CargoModel) {
       return  this.http.put<CargoModel>(globals.apiUrl + "Cargo/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.put<CargoModel>(globals.apiUrl + "Cargo/Delete/"+ id, {headers: this.httpHeaders});
    }
}