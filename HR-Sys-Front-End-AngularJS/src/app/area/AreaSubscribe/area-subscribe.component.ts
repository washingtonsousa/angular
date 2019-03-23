import { Component, Input, EventEmitter, ViewChild, Output} from "@angular/core";
import { AreaModel } from "../../models/area.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AreaService } from "../../services/http/area.service";
import { ModalMessageComponent } from "../../custommodals/modalMessage.component";
import { ImageConverter } from "../../adapters/imageConverter";

@Component({
selector: '[area-subscribe]',
templateUrl: 'area-subscribe.html'
})
export class AreaSubscribeComponent  {

   @Input() public areaModel: AreaModel = new AreaModel();
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
            this.modalMessage.Message = "Deletado com sucesso";
            this.modalMessage.openModal();

          }, err => {
            
            this.modalMessage.Message = "Não foi posssível deletar, verifique abaixo a mensagem de erro: " + err.message;
            this.modalMessage.openModal();

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
            this.modalMessage.Message = "Criado com sucesso";
            this.modalMessage.openModal();
            this.AreaForm.reset();

        }, err => {

                this.areaService.put(this.AreaForm.value).subscribe((res: AreaModel) => {

                    this.modalMessage.Message = "Atualizado com sucesso";
                    this.modalMessage.openModal();
                    this.emitter.emit(res);

                }, res => {  this.modalMessage.Message = "Falha ao executar a operação, consulte o erro para maiores detalhes: " 
                + err.message;
                    this.modalMessage.openModal(); 
                
                })

            });

        }
    }

}