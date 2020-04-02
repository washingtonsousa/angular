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

    constructor(private profilePictureService: ProfilePictureService,
        private sanitizer:DomSanitizer) {

    }

    ngOnInit() {
         this.profilePictureService.getSingle().subscribe(
             
            
            res => {this.src =  this.sanitizer.bypassSecurityTrustResourceUrl("data:image/jpeg;base64, "+ res)}, 
            
            
            err => {this.errorHandler(err)});
    }

    private errorHandler(err: any) {
        if(err.status == 404) {
               this.src = "assets/images/default-user-image.png";
           }
    }

}