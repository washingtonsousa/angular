import { Component, Input, Output, EventEmitter } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { DateTimeAdapterService } from "../../../adapters/dateTime.adapter";
import { UsuarioService } from "../../../services/http/usuario.service";
import { UsuarioModel } from "../../../models/Usuario.model";


@Component({
selector: 'qualifications',
templateUrl: 'qualifications.html'
})
export class QualificationsComponent{

    public usuarioModel: UsuarioModel = new UsuarioModel();
    public title: string = "Qualificações";


    constructor(private route: ActivatedRoute,  private dateAdapter: DateTimeAdapterService, 
        private usuarioService: UsuarioService) {



        }

        ngOnInit() {
          
        
                this.usuarioService.getSingle(parseInt(localStorage.getItem("user_id"))).subscribe((res: UsuarioModel) => {
        
                    this.usuarioModel = res;
                

                    });
        
        
        }

        
}