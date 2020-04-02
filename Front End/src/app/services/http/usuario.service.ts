import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';
import { Injectable } from "@angular/core";
import { UsuarioModel } from "../../models/Usuario.model";

@Injectable()
export class UsuarioService {
    
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"

            })
    }

    getSingle(id : number) : Observable<UsuarioModel> {
            return this.http.get<UsuarioModel>(globals.apiUrl + "Usuario/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<UsuarioModel[]> {
        return this.http.get<UsuarioModel[]>(globals.apiUrl + "Usuario/Get", {headers: this.httpHeaders});
    }

    put(Usuario: UsuarioModel) : Observable<UsuarioModel>{
       return  this.http.put<UsuarioModel>(globals.apiUrl + "Usuario/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: UsuarioModel) {
       return  this.http.post<UsuarioModel>(globals.apiUrl + "Usuario/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete(globals.apiUrl + "Usuario/Delete/"+ id, {headers: this.httpHeaders});
    }
    
}