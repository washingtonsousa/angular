import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import * as globals from '../globals/variables';
import { Injectable } from '@angular/core';

@Injectable()
export class ProfilePictureService {

private httpHeaders : HttpHeaders;

constructor(private http: HttpClient) {

      this.httpHeaders = new HttpHeaders({

         'Authorization': `Bearer ${localStorage.getItem('access_token')}`,

      })

}

get(id: number) : Observable<string> {
   return this.http.get<string>(globals.apiUrl + "ProfilePicture/Get/" + id , {headers: this.httpHeaders});
}

getSingle() : Observable<string> {
  return this.http.get<string>(globals.apiUrl + "ProfilePicture/GetSingle" , {headers: this.httpHeaders});
}

post(FormData: FormData): Observable<Response> {
  return this.http.post<Response>(globals.apiUrl + "ProfilePicture/Post", FormData, {headers: this.httpHeaders});
}

put(FormData: FormData): Observable<Response> {
    return this.http.put<Response>(globals.apiUrl + "ProfilePicture/Put", FormData, {headers: this.httpHeaders});
  }

delete() : Observable<string> {
    return this.http.get<string>(globals.apiUrl + "ProfilePicture/Delete" , {headers: this.httpHeaders});
 }
 



}