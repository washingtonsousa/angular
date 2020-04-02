import { Component, ElementRef, Output, EventEmitter } from "@angular/core";
import { trigger, state , transition, animate, style} from '@angular/animations';

@Component({
    selector: 'right-arrow-animated-btn',
    template: `
    
    <a (click)="toggleTurn()" class="angle-accordeon-btn" >
        <i class="fa fa-angle-right" [@turn]="turnTransitionState"></i> 
    </a>
    
    `,
    animations:[
        trigger('turn',[
            state('default',style({
                transform: 'rotate(0deg)'
            })),
            state('turned',style({
                transform: 'rotate(90deg)'
            })),
            transition('default <=> turned', animate('300ms ease'))
        ]),
    ]
})
export class RightArrowAnimatedBtnComponent {
            
    @Output('onTurn') public onTurnEmitter: EventEmitter<any> = new EventEmitter<any>();

    public turnTransitionState: string = 'default';

    constructor(private element: ElementRef) {
    }


     toggleTurn() {
        this.turnTransitionState = (this.turnTransitionState === 'default' ? 'turned' : 'default');
           this.onTurnEmitter.emit();
     }

}