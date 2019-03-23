import { Injectable } from "@angular/core";
import { HttpHeaders,HttpResponse, HttpClient, HttpParams, HttpRequest } from "@angular/common/http";
import { ArquivoModel } from "../../models/Arquivo.model";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class ArquivoService {
    protected httpHeaders: HttpHeaders;
    protected httpDownloadHeaders: HttpHeaders;
   protected httpUploadHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
       
        this.httpHeaders = new HttpHeaders({
            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
            })


        this.httpDownloadHeaders = new HttpHeaders({
        "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
        })


        this.httpUploadHeaders = new HttpHeaders({
            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            })
    }

    getSingle() : Observable<ArquivoModel[]> {
      
            return this.http.get<ArquivoModel[]>(globals.apiUrl + "Arquivo/GetSingle", {headers: this.httpHeaders});
    }

    get() : Observable<ArquivoModel[]> {

        return this.http.get<ArquivoModel[]>(globals.apiUrl + "Arquivo/Get", {headers: this.httpHeaders});
    }


    postWithTracking(Arquivo: FormData) {
        let req = new HttpRequest('POST', globals.apiUrl + "Arquivo/Post", Arquivo, 
        {headers: this.httpUploadHeaders, reportProgress: true} );

        return this.http.request(req);
    }

    DownloadSingle(Id: number) : Observable<HttpResponse<ArrayBuffer>> {
        
        return this.http.post(globals.apiUrl + "Arquivo/DownloadSingle/" + Id, {},
         {headers: this.httpDownloadHeaders, observe: 'response', responseType: 'arraybuffer'});
    }

    Download(Id: number) : Observable<HttpResponse<ArrayBuffer>>{

        return this.http.post(globals.apiUrl + "Arquivo/Download/" + Id, {}, 
        {headers : this.httpDownloadHeaders, observe: 'response', responseType: 'arraybuffer'});
    }

    post(Arquivo: FormData) {
    
       return  this.http.post<FormData>(globals.apiUrl + "Arquivo/Post", Arquivo, {headers: this.httpUploadHeaders, 
        reportProgress: true, observe: 'events'});
    }
    
    delete(Id: number) {

       return  this.http.delete<ArquivoModel>(globals.apiUrl + "Arquivo/Delete/"+ Id, {headers: this.httpHeaders});
    }
}