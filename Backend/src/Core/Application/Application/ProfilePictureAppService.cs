using Core.Application.Abstractions;
using Core.Application.Facades;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Application
{
    public class ProfilePictureAppService : AppService, IProfilePictureAppService
    {

        public IUsuarioRepository _usuarioRepo;
        public IUsuarioAppService _usuarioAppService;

        public ProfilePictureAppService(IUnityOfWork unitOfWork, IUsuarioAppService usuarioAppService, IUsuarioRepository usuarioRepo) : base(unitOfWork)
        {
            _usuarioRepo = usuarioRepo;
            _usuarioAppService = usuarioAppService;
        }

        public async Task<string> GetSingle()
        {

            Usuario usuarioFromDb = await _usuarioRepo.FindAsync(_usuarioAppService.GetUsuarioLoggedInId());

            if (usuarioFromDb.NotExists())
                return null;

            return usuarioFromDb.profileImage64string;
        }


        public async Task<string> Get(int id)
        {


            Usuario usuarioFromDb = await _usuarioRepo.FindAsync(id);

            if (usuarioFromDb.NotExists())
                return null;

            return usuarioFromDb.profileImage64string;

        }

        public async Task<string> Insert()
        {
            Usuario usuarioFromDb = await _usuarioRepo.FindAsync(_usuarioAppService.GetUsuarioLoggedInId());


            var provider = await RequestFormDataProviderFacade.BuildFormDataProvider();

            MultipartFileData Documento = null;

            Documento = provider.FileData[0];

            string filetype = Documento.Headers.Where(u => u.Key == "Content-Type").FirstOrDefault().Value.FirstOrDefault();


            if (filetype != "image/jpeg" && filetype != "image/png")
                return null;

            if (usuarioFromDb.NotExists())
                return null;


            byte[] b = System.IO.File.ReadAllBytes(provider.FileData[0].LocalFileName);

            usuarioFromDb.profileImage64string = Convert.ToBase64String(b);
            _unityOfWork.Commit();

            return usuarioFromDb.profileImage64string;


        }


        public async Task<string> Update()
        {
            Usuario usuarioFromDb = await _usuarioRepo.FindAsync(_usuarioAppService.GetUsuarioLoggedInId());

            var provider = await RequestFormDataProviderFacade.BuildFormDataProvider();

            MultipartFileData Documento = null;


            Documento = provider.FileData[0];

            string filetype = Documento.Headers.Where(u => u.Key == "Content-Type").FirstOrDefault().Value.FirstOrDefault();


            if (filetype != "image/jpeg" && filetype != "image/png")
                return null;

            if (usuarioFromDb.NotExists())
                return null;


            byte[] b = System.IO.File.ReadAllBytes(provider.FileData[0].LocalFileName);

            usuarioFromDb.profileImage64string = Convert.ToBase64String(b);
            _unityOfWork.Commit();


            return usuarioFromDb.profileImage64string;

        }



        public async Task Delete()
        {

            Usuario usuarioFromDb = await _usuarioRepo.FindAsync(_usuarioAppService.GetUsuarioLoggedInId());
            usuarioFromDb.profileImage64string = null;
            _unityOfWork.Commit();

        }


    }
}
