import { Component, Input } from "@angular/core";
import { FormAcademicaModel } from "../../../../models/FormAcademica.model";

@Component({
    
    selector: '[formacademica-block]',

    template: `
<div content-box iconClass="fa-university" Title="Formação acadêmica: " (btnAddAction)="formAcademicaPanel.show()">

<div class="col-xl-4 col-12 no-padding" (deleteEmitter)="formAcademicaForm.Delete(formacademica.Id)" (editEmitter)="atualizarFormAcademicaPanel.show()"
    *ngFor="let formacademica of formAcademicas" info-box>
        <div info-box-key-value key="Instituição" [value]="formacademica?.Instituicao">   </div>
        <div info-box-key-value key="Curso" [value]="formacademica?.Curso">   </div>
        <div info-box-key-value key="Tipo Curso" [value]="formacademica?.TipoCurso">   </div>
        <div info-box-key-value key="Situação" [value]="formacademica?.Situacao">   </div>

        <div side-panel #atualizarFormAcademicaPanel panelTitle="Atualizar Formação Acadêmica">
                <formacademica-form (Emitter)="Update($event)" (IdEmitter)="Delete($event)"  #formAcademicaForm [FormAcademicaObject]="formacademica" buttonText="Salvar"></formacademica-form>
        </div>
        
</div> 

    <div side-panel #formAcademicaPanel panelTitle="Adicionar Formação Acadêmica">
        <formacademica-form (Emitter)="Push($event)" buttonText="Salvar"></formacademica-form>        
</div> </div>`,


})
export class FormAcademicaBlockComponent {

    @Input() public formAcademicas: FormAcademicaModel[] = [];


    Push(value) {
        this.formAcademicas.push(value);
  }

  Update(value: FormAcademicaModel) {
      for(let $i = 0; $i < this.formAcademicas.length; $i++) {

          if(this.formAcademicas[$i].Id == value.Id) {

              this.formAcademicas[$i].Instituicao = value.Instituicao;
              this.formAcademicas[$i].Curso = value.Curso;
              this.formAcademicas[$i].Situacao = value.Situacao;
              this.formAcademicas[$i].TipoCurso = value.TipoCurso;
              this.formAcademicas[$i].Curso = value.Curso;

       }

    }
  }

  Delete(Id) {
      for(let $i = 0; $i <= this.formAcademicas.length; $i++) {

          if(this.formAcademicas[$i].Id == Id) {

            this.formAcademicas.splice($i, 1);
            this.formAcademicas = this.formAcademicas;
           

       }

    }
  }




}