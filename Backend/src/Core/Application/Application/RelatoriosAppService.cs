using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class RelatoriosAppService: AppService, IRelatoriosAppService
    {

        private IUsuarioRepository _usuarioRepo;
        private IExpProfissionalRepository _expProfissionalRepo;
        private IFormAcademicaRepository _formAcademicaRepo;
        private ICertCursoRepository _CertCursoRepo;
        private IConhecimentoRepository _conhecimentoRepo;
        private IUsuarioConhecimentoRepository _hasConhecimentoRepo;
        private IStatusRepository _statusRepo;
        private int rowStart;
        private IContatoRepository _contatosRepo;


        public RelatoriosAppService(IUnityOfWork unitOfWork, IExpProfissionalRepository expProfissionalRepository, IFormAcademicaRepository formAcademicaRepository, ICertCursoRepository certCursoRepository, IConhecimentoRepository conhecimentoRepository, IUsuarioConhecimentoRepository usuarioConhecimentoRepository, IStatusRepository statusRepository, IContatoRepository contatoRepository, IUsuarioRepository usuarioRepository) : base(unitOfWork)
        {
            rowStart = 2;
           _expProfissionalRepo =  expProfissionalRepository;
           _formAcademicaRepo =  formAcademicaRepository;
           _CertCursoRepo =  certCursoRepository;
           _conhecimentoRepo =  conhecimentoRepository;
           _hasConhecimentoRepo =  usuarioConhecimentoRepository;
           _statusRepo =  statusRepository;
           _contatosRepo =  contatoRepository;
           _usuarioRepo =  usuarioRepository;
        }



        public ExcelPackage Get(string SearchStr = null, IList<int> ConhecimentoIds = null)
        {



            IList<Usuario> Usuarios = _usuarioRepo.Get();
            IList<Conhecimento> Conhecimentos = _conhecimentoRepo.Get();
            IList<UsuarioConhecimento> HasConhecimentos = _hasConhecimentoRepo.Get();
            IList<Usuario> UsuariosSearch = new List<Usuario>();
            IList<ExpProfissional> ExpProfissionais = _expProfissionalRepo.Get();
            IList<Status> Status = _statusRepo.Get();

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


            if (SearchStr != null && SearchStr != "")
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

                ws.Cells[string.Format("A{0}", rowStart)].Value = usuario.Nome;
                ws.Cells[string.Format("B{0}", rowStart)].Value = usuario.Email;
                ws.Cells[string.Format("C{0}", rowStart)].Value = usuario.Cargo.Nome;
                ws.Cells[string.Format("D{0}", rowStart)].Value = usuario.Status.Nome;

                if (usuario.UsuarioConhecimentos != null)
                {

                    foreach (var usuarioConhecimento in usuario.UsuarioConhecimentos)
                    {
                        ws.Cells[string.Format("E{0}", rowStart)].Value += " " + usuarioConhecimento.Conhecimento.Nome + ";";

                    }
                }

                if (usuario.ExpProfissionais != null)
                {
                    foreach (var expProfissional in usuario.ExpProfissionais)
                    {
                        ws.Cells[string.Format("F{0}", rowStart)].Value += " " + expProfissional.Cargo + ";";

                    }
                }

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();

            return pck;

        }
    }
}
