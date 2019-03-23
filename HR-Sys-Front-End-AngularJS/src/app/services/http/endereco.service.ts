import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { EnderecoModel } from "../../models/Endereco.model";
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

    getSingle(id : number) : Observable<EnderecoModel> {
            return this.http.get<EnderecoModel>(globals.apiUrl + "Endereco/GetSingle/" + id, {headers: this.httpHeaders});
    }

    get() : Observable<any> {
        return this.http.get<any>(globals.apiUrl + "Endereco/Get", {headers: this.httpHeaders});
    }

    put(Usuario: EnderecoModel) : Observable<EnderecoModel>{
       return  this.http.put<EnderecoModel>(globals.apiUrl + "Endereco/PutSingle", Usuario, {headers: this.httpHeaders});
    }

    post(Usuario: EnderecoModel) {
       return  this.http.post<EnderecoModel>(globals.apiUrl + "Endereco/PostSingle", Usuario, {headers: this.httpHeaders});
    }
    
    delete(id: number) {
       return  this.http.delete<EnderecoModel>(globals.apiUrl + "Endereco/DeleteSingle/"+ id, {headers: this.httpHeaders});
    }
}