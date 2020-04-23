import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Endereco } from "../../models/endereco.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class EnderecoService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }

    getSingle(id : number) : Observable<Endereco> {
            return this.http.get<Endereco>(globals.apiUrl + "Endereco/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Endereco/Get", {headers: this.httpHeaders});
    }

    put(Usuario: Endereco) : Observable<Endereco>{
       return  this.http.put<Endereco>(globals.apiUrl + "Endereco/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: Endereco) {
       return  this.http.post<Endereco>(globals.apiUrl + "Endereco/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<Endereco>(globals.apiUrl + "Endereco/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}