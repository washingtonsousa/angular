import {CargoModel} from './Cargo.model';
import { EnderecoModel } from './Endereco.model';
import { NivelAcessoModel } from './NivelAcesso.model';
import { ContatoModel } from './Contato.model';
import { ResumoModel } from './resumo.model';
import { IdiomaModel } from './Idioma.model';
import {  CertCursoModel } from './CertCurso.model';
import { FormAcademicaModel } from './FormAcademica.model';
import { UsuarioConhecimentoModel } from './UsuarioConhecimento.model';
import { ExpProfissionalModel } from './ExpProfissional.model';

export class UsuarioModel {
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
    Cargo: CargoModel = new CargoModel();
    Endereco: EnderecoModel = new EnderecoModel();
    NivelAcesso: NivelAcessoModel = new NivelAcessoModel();
    Contatos: ContatoModel[] = [];
    Idiomas: IdiomaModel[] = [];
    CertCursos: CertCursoModel[] = [];
    Resumo: ResumoModel = new ResumoModel();
    FormAcademicas: FormAcademicaModel[]  = [];
    ExpProfissionais: ExpProfissionalModel[] = [];
    UsuarioConhecimentos:UsuarioConhecimentoModel[] = [];
}

