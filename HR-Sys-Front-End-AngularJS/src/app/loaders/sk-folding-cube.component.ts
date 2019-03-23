import { Component , Input, ElementRef} from "@angular/core";
import * as $ from 'jquery';


@Component({

selector: '[sk-folding-cube]',
template: `<div class="text-center">
<div *ngIf="IconVisible" class="sk-folding-cube">
        <div [className]="'sk-cube1 sk-cube ' + iconColorClass"></div>
        <div [className]="'sk-cube2 sk-cube ' + iconColorClass"></div>
        <div [className]="'sk-cube3 sk-cube ' + iconColorClass"></div>
        <div [className]="'sk-cube4 sk-cube ' + iconColorClass"></div>
</div>

<div *ngIf="text" [class]="textColorClass">{{text}}</div>
</div>`
})
export class SkFoldingCubeComponent {
   
   @Input() public visible: boolean = true;
   @Input() public text: string;
   @Input() public iconColorClass: string;
   @Input() public textColorClass: string;
   @Input() public IconVisible: boolean = true;

constructor(private eRef: ElementRef) {

}

ngOnInit() {
    if(this.visible == true) {
        this.show();
    } else {
        this.hide();
    }
}

public hide(){
$(this.eRef.nativeElement).hide();
}

public show() {
$(this.eRef.nativeElement).show();
}

}