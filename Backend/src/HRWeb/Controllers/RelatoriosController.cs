using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HRWeb.Filters;
using Core.Data.Models;
using Core.Data.Repositories;

namespace HRWeb.Controllers
{

    [Authorize(Roles = "Administrador")]
    public class RelatoriosController : Controller
    {
        private UsuarioRepository usuarioRepo;
        private ExpProfissionalRepository expProfissionalRepo;
        private FormAcademicaRepository formAcademicaRepo;
        private CertCursoRepository CertCursoRepo;
        private ConhecimentoRepository conhecimentoRepo;
        private UsuarioConhecimentoRepository hasConhecimentoRepo;
        private StatusRepository statusRepo;
        private int rowStart;
        private ContatoRepository contatosRepo;

        public RelatoriosController() {
            
           
            this.rowStart = 2;
            this.expProfissionalRepo = new ExpProfissionalRepository();
            this.formAcademicaRepo = new FormAcademicaRepository();
            this.CertCursoRepo = new CertCursoRepository();
            this.conhecimentoRepo = new ConhecimentoRepository();
            this.hasConhecimentoRepo = new UsuarioConhecimentoRepository();
            this.statusRepo = new StatusRepository();
            this.contatosRepo = new ContatoRepository();
            usuarioRepo = new UsuarioRepository();
        }

        public ActionResult Index()
        {

            return View();
        }




        public void Get(string SearchStr = null, IList<int> ConhecimentoIds = null)
        {

    

            IList<Usuario> Usuarios = this.usuarioRepo.Get();
            IList<Conhecimento> Conhecimentos = this.conhecimentoRepo.GetConhecimentos();
            IList<UsuarioConhecimento> HasConhecimentos = this.hasConhecimentoRepo.GetUsuarioConhecimentos();
            IList<Usuario> UsuariosSearch = new List<Usuario>();
            IList<ExpProfissional> ExpProfissionais = expProfissionalRepo.GetExpProfissionais();
            IList<Status> Status = statusRepo.GetStatus();
        
            if (ConhecimentoIds != null)   // Se lista não for nula
            {

                foreach (var conhecimentoId in ConhecimentoIds)
                {

                    foreach (var conhecimentoUsuario in HasConhecimentos)
                    {

                        if (conhecimentoUsuario.ConhecimentoId == conhecimentoId)
                        {
                            if (UsuariosSearch.Where(u => u.Id == conhecimentoUsuario.UsuarioId).FirstOrDefault() == null)
                            {

                                UsuariosSearch.Add(conhecimentoUsuario.Usuario);

                            }
                        }


                    } // Fim - Para cada usuario conhecimento - Many to Many       


                } // Fim - Para cada conhecimento Id

            } // Fim - condição, se Lista de conhecimentos não for nula


            if (SearchStr != null && SearchStr != "" )
            {

                Usuarios = Usuarios.Where(u => u.Cargo.Nome.Contains(SearchStr)).ToList();



                foreach (var expProfissional in ExpProfissionais)
                {
                    if (Usuarios.Where(u => u.Id == expProfissional.UsuarioId).FirstOrDefault() == null)
                    {

                        Usuarios.Add(expProfissional.Usuario);

                    }
                }

                foreach (var usuario in Usuarios)
                {

                    if (UsuariosSearch.Where(u => u.Id == usuario.Id).FirstOrDefault() == null)
                    {

                        UsuariosSearch.Add(usuario);

                    }

                }

            }

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Currículos");

            ws.Cells["A1"].Value = "Nome Usuário";
            ws.Cells["B1"].Value = "Email";
            ws.Cells["C1"].Value = "Cargo";
            ws.Cells["D1"].Value = "Status";
            ws.Cells["E1"].Value = "Conhecimentos";
            ws.Cells["F1"].Value = "Experiências profissionais";
            foreach (var usuario in UsuariosSearch)
            {

                ws.Cells[string.Format("A{0}", this.rowStart)].Value = usuario.Nome;
                ws.Cells[string.Format("B{0}", this.rowStart)].Value = usuario.Email;
                ws.Cells[string.Format("C{0}", this.rowStart)].Value = usuario.Cargo.Nome;
                ws.Cells[string.Format("D{0}", this.rowStart)].Value = usuario.Status.Nome;

                if(usuario.UsuarioConhecimentos != null) {

                foreach (var usuarioConhecimento in usuario.UsuarioConhecimentos)
                {
                    ws.Cells[string.Format("E{0}", this.rowStart)].Value += " " + usuarioConhecimento.Conhecimento.Nome+";";

                }
                }

                if (usuario.ExpProfissionais != null)
                {
                    foreach (var expProfissional in usuario.ExpProfissionais)
                    {
                        ws.Cells[string.Format("F{0}", this.rowStart)].Value += " " + expProfissional.Cargo+";";

                    }
                }

                this.rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename = relatório.xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Charset = "";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }
}
