import { Component, EventEmitter, ElementRef, OnInit, Input, Output, ViewChild } from "@angular/core";
import * as $ from 'jquery';
import { SkFoldingCubeComponent } from "./sk-folding-cube.component";


@Component({
    selector: "[component-inner-loader]",
    template: `
    <div sk-folding-cube #maskedLoader iconColorClass="sk-bg-white" 
        textColorClass="white" [visible]="LoaderIconVisible" [text]="text" ></div> 
        <button *ngIf="buttonVisible" class=" btn btn-warning btn-sm" (click)="OnClick()"> <i class="fa fa-refresh" aria-hidden="true"></i>
         {{ buttonText }} </button>  
    `
})
export class ComponentInnerLoader implements OnInit {

 @Input() public text: string = "Carregando...";
 @Input() public buttonText:string = "Tentar novamente";
 @Input() public LoaderIconVisible: boolean = true;
 public buttonVisible: boolean = false;

 @Output('OnClick') public OnClickEmitter: EventEmitter<any> = new EventEmitter<any>();
 @ViewChild('maskedLoader') public maskedLoader: SkFoldingCubeComponent;

    constructor(private eRef: ElementRef) {}


    OnClick() {
    this.OnClickEmitter.emit();
    }


    reset() {
        this.text="Carregando...";
        this.maskedLoader.IconVisible = true;
        this.buttonVisible = false;
    }

    onErrorHandler(errorMessage: string) {
        this.maskedLoader.IconVisible = false;
        this.buttonVisible = true;
        this.text = "Falha ao carregar o componente, detalhes do erro: " + errorMessage;
    }


   ngOnInit() {
       $(this.eRef.nativeElement).addClass("component-inner-loader");
   }


}