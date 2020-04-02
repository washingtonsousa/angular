import { HttpHeaders } from "@angular/common/http";

export class OAuthHttpTemplate {

    protected httpHeaders: HttpHeaders;


     constructor() {

         this.httpHeaders = new HttpHeaders({

         "Authorization": `Bearer ${localStorage.getItem('token')}`,
         "Content-type": "application/json"


         })

     }



}