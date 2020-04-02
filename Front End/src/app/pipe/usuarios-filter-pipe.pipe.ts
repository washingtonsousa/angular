import {Pipe, PipeTransform} from '@angular/core';
import { UsuarioModel } from '../models/Usuario.model';
import { UsuarioConhecimentoModel } from '../models/UsuarioConhecimento.model';


@Pipe({name: 'usuarioPipe', pure: false})
export class  UsuariosFilterPipe implements PipeTransform {
   transform(Usuarios : UsuarioModel[], filterQueryHandler: any) {

        if(filterQueryHandler) {
               
                    if(filterQueryHandler.Nome != "" && filterQueryHandler.Nome) {
                        Usuarios = Usuarios.filter(usuario => usuario.Nome.toLowerCase()
                        .includes(filterQueryHandler.Nome.trim().toLowerCase()));  
                    }
                    
                    if(filterQueryHandler.AreaNome != "" && filterQueryHandler.AreaNome) {
                        Usuarios = Usuarios.filter(usuario => usuario.Cargo.Departamento.Area.Nome.toLowerCase()
                        .includes(filterQueryHandler.AreaNome.trim().toLowerCase()));  
                    }

                    if(filterQueryHandler.CargoNome != "" && filterQueryHandler.CargoNome) {
                        Usuarios = Usuarios.filter(usuario => usuario.Cargo.Nome.toLowerCase()
                        .includes(filterQueryHandler.CargoNome.trim().toLowerCase()));  
                    }

                    if(filterQueryHandler.DepartamentoNome != "" && filterQueryHandler.DepartamentoNome) {
                        Usuarios = Usuarios.filter(usuario => usuario.Cargo.Departamento.Nome.toLowerCase()
                        .includes(filterQueryHandler.DepartamentoNome.trim().toLowerCase()));  
                    }

                    
                    if(filterQueryHandler.ConhecimentoIds.length) {


                        var FilteredUsuarios = [];

                        filterQueryHandler.ConhecimentoIds.forEach((Id:Number) => {

                            for(let i = 0; i < Usuarios.length; i++) {


                                for(let c = 0; c < Usuarios[i].UsuarioConhecimentos.length; c++) {
                                  
                                    if(Usuarios[i].UsuarioConhecimentos[c].ConhecimentoId == Id) {

                                        if(!FilteredUsuarios.includes(Usuarios[i])) {
                                            FilteredUsuarios.push(Usuarios[i]);
                                        }
                                        
                                    }

                                }

                            }

                        });


                        Usuarios = FilteredUsuarios;
                       
                    } 

                    return Usuarios;

            }
           else {

               return Usuarios;
               
           }

   }
} 