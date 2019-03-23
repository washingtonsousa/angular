import { Component, ViewChild, Output, EventEmitter, OnInit } from "@angular/core";
import { ProfilePictureService } from "../../../profilePicture/profile-picture.service";
import { ProfilePictureComponent } from "../../../profilePicture/profile-picture.component";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { HttpClient } from "@angular/common/http";
import * as globals from "../../../globals/variables";

@Component({
    selector: 'profile-photo-form',
    template: `
    
    <form [formGroup]="formGroup" (ngSubmit)=Submit($event)> 

    <profile-picture #profilePicture cssClass="img-fluid img-thumbnail"></profile-picture>
   
    <br />
    <br />
    <input type="file" name="photo" (change)="readLocalImageUrl($event)"/>
    <br />
    <br />

    <button type="submit" [disabled]="!formGroup.valid" class="btn-sm btn btn-primary"> <i class="fa fa-save"></i> Salvar </button>
   
    <br />
    <br />


    <div *ngIf="Mensagem" class="alert alert-info"> 
    
    {{ Mensagem }}

    </div>
    

    </form>


    `
})
export class ProfilePhotoFormComponent implements OnInit {
   
    @ViewChild('profilePicture') public profilePicture: ProfilePictureComponent;
    public formData: FormData = new FormData();
    public arquivo: File;
    public Mensagem: string;
    public formGroup: FormGroup;

    @Output() public OnSubmitEmitter: EventEmitter<any> = new EventEmitter<any>();

    constructor(private profilePictureService: ProfilePictureService,
         private $http : HttpClient,
          private fb: FormBuilder) {

        this.formData.append('file', '');

    }


    ngOnInit() {
         this.formGroup = this.fb.group({

            file_Url: [null, Validators.required] 

         })
    }

    readImageFromSharepoint() {
       
            var reader = new FileReader();
        
            reader.onload = (event: ProgressEvent) => {
              this.profilePicture.src = (<FileReader>event.target).result;
            }



           
    
        const downloadLink = document.createElement("img");
        downloadLink.style.display = "none";
        document.body.appendChild(downloadLink);
        downloadLink.setAttribute("src", globals.sharepointSiteUrl + 
            "_layouts/15/userphoto.aspx?size=L&username=washington.meneses@riscservices.com.br");


        console.log(downloadLink.getAttribute("src"));
        
           // reader.readAsDataURL(event.target.files[0]);
  
           // this.arquivo = event.target.files[0];
            this.formGroup.setValue({'file_Url': this.profilePicture.src});
          
    }

    readLocalImageUrl(event:any) {
        if (event.target.files && event.target.files[0]) {
          var reader = new FileReader();
      
          reader.onload = (event: ProgressEvent) => {
            this.profilePicture.src = (<FileReader>event.target).result;
          }
      
          reader.readAsDataURL(event.target.files[0]);

          this.arquivo = event.target.files[0];
          this.formGroup.setValue({'file_Url': this.profilePicture.src});
        }
      }

    Submit($event: any) {

       $event.preventDefault();

       this.formData.set('file', this.arquivo);

       this.profilePictureService.post(this.formData).subscribe((res) => {

        this.Mensagem = "Inserido com sucesso, recarregue a página para ver as alterações";

        this.OnSubmitEmitter.emit();

       }, err => {

        this.profilePictureService.put(this.formData).subscribe(res => {


            this.Mensagem = "Inserido com sucesso, recarregue a página para ver as alterações";

            this.OnSubmitEmitter.emit();

        })
              

       })
        
    }


}