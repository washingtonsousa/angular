import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import * as globals from '../../globals/variables';

@Injectable()
export class StatisticsService {
    protected httpHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpHeaders = new HttpHeaders({

            "Authorization": `Bearer ${localStorage.getItem('access_token')}`,
            "Content-type": "application/json"
   
            })
    }


    getUsuarioBasic() {
        return this.http.get<any>(globals.apiUrl + "Statistics/GetUsuarioBasic", {headers : this.httpHeaders});
    }

    getEntidadesBasic() {
        return this.http.get<any>(globals.apiUrl + "Statistics/GetEntidadesBasic", {headers : this.httpHeaders});
    }
    GetLogActionStatistics(Year?: number, Month?:number, Day?:number) {


        let QueryString = "";

        if(Year) {
            QueryString += "/"+Year;
            if(Month) {
                QueryString += "/"+Month;
                if(Day) {
                    QueryString += "/"+Day;
                }
            }
        }


        return this.http.get<any>(globals.apiUrl + "Statistics/GetLogActionStatistics", {headers : this.httpHeaders});
    }

    GetLogActionLimitedList(Year?: number, Month?:number, Day?:number) {


        let QueryString = "";

        if(Year) {
            QueryString += "/"+Year;
            if(Month) {
                QueryString += "/"+Month;
                if(Day) {
                    QueryString += "/"+Day;
                }
            }
        }

        return this.http.get<any>(globals.apiUrl + "Statistics/GetLogActionLimitedList", {headers : this.httpHeaders});
    }
}