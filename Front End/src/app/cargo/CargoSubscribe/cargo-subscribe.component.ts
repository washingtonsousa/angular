import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { Cargo } from "../../models/cargo.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CargoService } from "../../services/http/cargo.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import {Area} from "../../models/Area.model";
import {NgSelectizeHelper} from "../../adapters/ngSelectizeHelper";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
selector: '[cargo-subscribe]',
templateUrl: 'cargo-subscribe.html'
})
export class CargoSubscribeComponent  {

   @Input() public Cargo: Cargo = new Cargo();
   @Input() public DepartamentosList: Area[];
   @Input() public buttonText: string;
   public selectizeConfig: any;
   @Output('emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  CargoForm:FormGroup;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private cargoService: CargoService) {

  this.selectizeConfig = new NgSelectizeHelper("Nome", "Id").build(); 

   }

   Delete(Id: number) {
          this.cargoService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);

            ModalMessageService.open("Deletado com sucesso");

          }, err => {
  

            ModalMessageService.open("Não foi posssível deletar, verifique abaixo a mensagem de erro: " + err.message);
          });
   }

   ngOnInit() {
   this.CargoForm = this.fb.group({
        Id: [this.Cargo.Id],
        Nome : [this.Cargo.Nome, [Validators.required]],
        DepartamentoId :  [this.Cargo.DepartamentoId, [Validators.required]],
        
       });
   }




   OnSubmit(event) {

   event.preventDefault();

   if(this.CargoForm.valid) {

        this.cargoService.post(this.CargoForm.value).subscribe(res => { 
            
            this.emitter.emit(res);
            this.CargoForm.reset();
            ModalMessageService.open("Criado com sucesso");
        }, err => {

                this.cargoService.put(this.CargoForm.value).subscribe((res: Cargo) => {

                    ModalMessageService.open("Atualizado com sucesso");
                    this.emitter.emit(res);

                }, res => { ModalMessageService.open("Falha ao executar a operação, consulte o erro para maiores detalhes: " 
                + err.message);
           
                
                })

            });

        }
    }

}