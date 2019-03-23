import { Injectable } from "@angular/core";
import { SignalRHubTemplate } from "./SignalRHubTemplate";

@Injectable()
export class StatisticsHubService extends SignalRHubTemplate {


constructor() {
    super();
    this.createProxyHub("StatisticsHub");
}

}