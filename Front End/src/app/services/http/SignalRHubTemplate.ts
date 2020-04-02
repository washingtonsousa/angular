import 'jquery';
import 'ms-signalr-client';
import * as globals from '../../globals/variables';

declare var jQuery:any;
declare var $:any;

export class SignalRHubTemplate {


protected connection : any;
public proxy: any;


constructor() {

        this.connection = $.hubConnection(globals.hubUrl);
        $.connection.hub.url = globals.hubUrl;
}


createProxyHub(HubName: string) {
    this.proxy = this.connection.createHubProxy(HubName);
}

public start() {
    this.connection.start( { transport:  ['webSockets', 'longPolling'] })
    .done(function(){ console.log('Now connected, connection ID=' + this.connection.id); }.bind(this))
    .fail(function(err){ console.log('Could not connect' + err); });
}

}