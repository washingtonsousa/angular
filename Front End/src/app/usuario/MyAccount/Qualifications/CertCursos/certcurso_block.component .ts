import { Component, Input, ViewChild } from "@angular/core";
import { CertCursoModel } from "../../../../models/CertCurso.model";

@Component({
    
    selector: '[certcurso-block]',

    template: `
<div content-box iconClass="fa-book" Title="Cursos ou certificações: " (btnAddAction)="certCursoPanel.show()">

    <div class="col-xl-4 col-lg-6 col-md-6 col-12 no-padding" *ngFor="let certcurso of certCursos" 
    (editEmitter)="atualizarCertCursoPanel.show()" (deleteEmitter)="certcursoForm.Delete(certcurso.Id)" info-box>
    <div info-box-key-value key="Nome" [value]="certcurso?.Nome">   </div>
    <div info-box-key-value key="Instituição" [value]="certcurso?.Instituicao">   </div>
    <div info-box-key-value key="Certificadora" [value]="certcurso?.Certificadora">   </div>
    <div info-box-key-value key="Período" [value]="certcurso?.Periodo">   </div>
    <div info-box-key-value key="Descrição" [value]="certcurso?.Descricao">   </div>
    

    <div side-panel #atualizarCertCursoPanel panelTitle="Atualizar">
            <certcurso-form (Emitter)="Update($event)" (IdEmitter)="Delete($event)"  #certcursoForm [certcursoObject]="certcurso" buttonText="Salvar"></certcurso-form>
    </div>
    </div> 

    <div side-panel #certCursoPanel panelTitle="Adicionar Curso">
        <certcurso-form (Emitter)="Push($event)" buttonText="Salvar"></certcurso-form>        
</div> </div>`,


})
export class CertCursoBlockComponent {

    @Input() public certCursos: CertCursoModel[] = [];
    @ViewChild('certCursoPanel') public certCursoPanel: any;
    @ViewChild('atualizarCertCursoPanel') public atualizarCertCursoPanel: any;

    Push(value) {
          this.certCursos.push(value);
          this.certCursoPanel.hide();
    }

    Update(value: CertCursoModel) {
        for(let $i = 0; $i < this.certCursos.length; $i++) {

            if(this.certCursos[$i].Id == value.Id) {
 
                this.certCursos[$i].Instituicao = value.Instituicao;
                this.certCursos[$i].Nome = value.Nome;
                this.certCursos[$i].Periodo = value.Periodo;
                this.certCursos[$i].Descricao = value.Descricao;
                this.certCursos[$i].Certificadora = value.Certificadora;
 
         }
 
      }

      this.atualizarCertCursoPanel.hide();
    }

    Delete(Id) {
        for(let $i = 0; $i <= this.certCursos.length; $i++) {

            if(this.certCursos[$i].Id == Id) {
 
              this.certCursos.splice($i, 1);
              this.certCursos = this.certCursos;
             
 
         }
 
      }
    }




}