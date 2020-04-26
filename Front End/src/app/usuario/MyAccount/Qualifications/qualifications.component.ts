import { Component, Input, Output, EventEmitter } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { DateTimeAdapterService } from "../../../adapters/dateTime.adapter";
import { UsuarioService } from "../../../services/http/usuario.service";
import { Usuario } from "../../../models/usuario.model";


@Component({
selector: 'qualifications',
templateUrl: 'qualifications.html'
})
export class QualificationsComponent{

    public usuarioModel: Usuario = new Usuario();
    public title: string = "Qualificações";


    constructor(private route: ActivatedRoute,  private dateAdapter: DateTimeAdapterService, 
        private usuarioService: UsuarioService) {



        }

        ngOnInit() {
          
        
                this.usuarioService.getSingle(parseInt(localStorage.getItem("user_id"))).subscribe((res: Usuario) => {
        
                    this.usuarioModel = res;
                console.log(res);

                    });
        
        
        }

        
}