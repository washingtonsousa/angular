using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Mvc;

namespace RiscServicesHRSharepointAddIn.Controllers
{
  public class ChamadoController : Controller
    {
        // GET: Chamado
        public ActionResult Index()
        {
            return View();
        }

        // GET: Chamado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chamado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chamado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chamado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chamado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chamado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
