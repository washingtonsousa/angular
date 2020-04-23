import {Cargo} from './cargo.model';
import { Endereco } from './endereco.model';
import { NivelAcesso } from './nivel-acesso.model';
import { Contato } from './Contato.model';
import { Resumo } from './resumo.model';
import { Idioma } from './idioma.model';
import {  CertCurso } from './cert-curso.model';
import { FormAcademica } from './form-academica.model';
import { UsuarioConhecimento } from './usuario-conhecimento.model';
import { ExpProfissional } from './exp-profissional.model';

export class Usuario {
    Id: number;
    Nome: string;
    Email: string;
    Email_Secundario_Notificacao: string;
    Sexo: string;
    profileImage64String: string;
    Ramal: number;
    Matricula: string;
    NivelAcessoId: number;
    StatusId: number;
    CargoId: number;
    DataAdmissao: string;
    DataNasc: string;
    Data_Demissao: string;
    EstadoCivil: string;
    Cargo: Cargo = new Cargo();
    Endereco: Endereco = new Endereco();
    NivelAcesso: NivelAcesso = new NivelAcesso();
    Contatos: Contato[] = [];
    Idiomas: Idioma[] = [];
    CertCursos: CertCurso[] = [];
    Resumo: Resumo = new Resumo();
    FormAcademicas: FormAcademica[]  = [];
    ExpProfissionais: ExpProfissional[] = [];
    UsuarioConhecimentos:UsuarioConhecimento[] = [];
}

