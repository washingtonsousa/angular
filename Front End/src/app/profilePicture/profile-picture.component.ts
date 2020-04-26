import { Component, OnInit, Input } from "@angular/core";
import { ProfilePictureService } from "./profile-picture.service";
import { DomSanitizer } from "@angular/platform-browser";

@Component({
selector: 'profile-picture',
templateUrl: 'profile-picture.html'
})
export class ProfilePictureComponent implements OnInit {

    @Input() public src: any = "assets/images/default-user-image.png";
    @Input() public cssClass: string;
    public safeUrl: string;
    private defaultImageUrl:String = "assets/images/default-user-image.png";
    constructor(private profilePictureService: ProfilePictureService,
        private sanitizer:DomSanitizer) {

    }

    ngOnInit() {
         this.profilePictureService.getSingle().subscribe(
             
            
            res => {
                
                
                this.src = (res != null)  ? this.sanitizer.bypassSecurityTrustResourceUrl("data:image/jpeg;base64, "+ res) : this.defaultImageUrl;
            
            
            }, 
            
            
            err => {this.errorHandler(err)});
    }

    private errorHandler(err: any) {
      
    }

}