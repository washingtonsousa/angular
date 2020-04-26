import { ViewChild, Component, ElementRef, Input, OnInit } from '@angular/core';
import { SkFoldingCubeComponent } from './sk-folding-cube.component';
import * as $ from 'jquery';
import { LoadingIconService } from '../services/emitters/loading-icon.service';

@Component({
    template: `
<div class="topMask">

        <div class="obj-center" sk-folding-cube #maskedLoader iconColorClass="sk-bg-white" 
        textColorClass="white" [visible]="true" text="Carregando..." ></div>

</div>`,
    selector: '[mskfolding]'
})
export class MaskedSKFoldingCubeComponent implements OnInit {

    @Input() public visible: boolean = true;
    @ViewChild('maskedLoader') loadingIcon: SkFoldingCubeComponent;
    @Input() public iconColorClass: string;
    @Input() public textColorClass: string;
    @Input() public maskClass: string;

    constructor(private eRef: ElementRef) {
    }

    ngOnInit() {

        this.toggle(this.visible);

        LoadingIconService.listen().subscribe((visible = false) => {
            this.toggle(visible);
        })

    }

    public toggle(status: boolean) {

        if (status == true) {
            this.show();
        } else {
            this.hide();
        }

    }

    public hide() {
        this.visible = false;
        $(this.eRef.nativeElement).hide();
    }

    public show() {
        this.visible = true;
        $(this.eRef.nativeElement).show();
    }

}