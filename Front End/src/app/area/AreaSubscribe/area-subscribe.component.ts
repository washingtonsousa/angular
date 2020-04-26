import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { Area } from "../../models/area.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AreaService } from "../../services/http/area.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import { ImageConverter } from "../../adapters/imageConverter";
import { ModalMessageService } from "src/app/services/emitters/modal-message.service";

@Component({
selector: '[area-subscribe]',
templateUrl: 'area-subscribe.html'
})
export class AreaSubscribeComponent  {

   @Input() public areaModel: Area = new Area();
   @Input() public buttonText: string;
   @Output('emitter') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   @Output('IdEmitter') public IdEmitter: EventEmitter<number> =  new EventEmitter<number>();
   public  AreaForm:FormGroup;
   @ViewChild('modalMessage') modalMessage: ModalMessageComponent;
   @ViewChild('modalConfirmMessage') modalConfirmMessage: ModalMessageComponent;
   constructor(private fb: FormBuilder, private areaService: AreaService) {}

   Delete(Id: number) {
          this.areaService.delete(Id).subscribe(res => {

            this.IdEmitter.emit(Id);
            ModalMessageService.open("Deletado com sucesso");

          }, err => {
            
            ModalMessageService.open("Não foi posssível deletar, verifique abaixo a mensagem de erro: " + err.message);
          });
   }

   readLocalImageUrl(event) {
       let imgConv = new ImageConverter(event.target.files[0]);
       imgConv.getBin64ImageStringReader().onload = (event: ProgressEvent) => {
        this.AreaForm.controls['imgStr'].setValue((<FileReader>event.target).result);
       }
   }

   ngOnInit() {
   this.AreaForm = this.fb.group({
        Id: [this.areaModel.Id],
        Nome : [this.areaModel.Nome, [Validators.required]],
        imgStr :  [this.areaModel.imgStr],
        
       });
   }

   OnSubmit(event) {

   event.preventDefault();

   if(this.AreaForm.valid) {

        this.areaService.post(this.AreaForm.value).subscribe(res => { 
            
            this.emitter.emit(res);
            ModalMessageService.open("Criado com sucesso");
            this.AreaForm.reset();

        }, err => {

                this.areaService.put(this.AreaForm.value).subscribe((res: Area) => {

           
                    ModalMessageService.open("Atualizado com sucesso");
                    this.emitter.emit(res);

                }, res => {  this.modalMessage.Message = "Falha ao executar a operação, consulte o erro para maiores detalhes: " 
                + err.message;
                    this.modalMessage.openModal(); 
                
                })

            });

        }
    }

}