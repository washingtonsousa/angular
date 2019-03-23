import { Component, Input, OnInit, NgZone } from "@angular/core";


@Component({
    selector: '[info-box-key-value]',
    template: `<p><small class="text-muted"> <i *ngIf="keyIconClass" [class]="'fa '+ keyIconClass"></i> {{ key }}: </small></p> <p *ngIf="value" class="pre-wrap"> {{ value }} </p>`
 
})
export class InfoBoxKeyValueLineComponent implements OnInit {
@Input() public key: string;
@Input() public value: string;
@Input() public keyIconClass: string;
constructor() {

}

ngOnInit() {


this.key = this.key;
this.value= this.value;



}
}