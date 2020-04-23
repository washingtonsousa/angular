import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';
import { Injectable } from "@angular/core";
import { Usuario } from "../../models/usuario.model";

@Injectable()
export class UsuarioService {
    
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"

            })
    }

    getSingle(id : number) : Observable<Usuario> {
            return this.http.get<Usuario>(globals.apiUrl + "Usuario/Get/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<Usuario[]> {
        return this.http.get<Usuario[]>(globals.apiUrl + "Usuario/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Usuario) : Observable<Usuario>{
       return  this.http.put<Usuario>(globals.apiUrl + "Usuario/Put", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Usuario) {
       return  this.http.post<Usuario>(globals.apiUrl + "Usuario/Post", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete(globals.apiUrl + "Usuario/Delete/"+ id, {headers: this.httpHeaders});
    }
    
}