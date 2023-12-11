using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CachorroController : Controller
    {
        // GET: Cachorro
        private readonly Repositories.ADO.SQL_SERVER.Cachorro repository;

        public CachorroController()
        {
            repository = new Repositories.ADO.SQL_SERVER.Cachorro();
        }
        public ActionResult Index()
        {
            return View(repository.get());
        }
        public ActionResult IndexAdm()
        {
            return View(repository.get());
        }
        // GET: Cachorro/Details/5
        public ActionResult Details(int id)
        {   
            return View(repository.getDetails(id));
        }

        // GET: Cachorro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cachorro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Cachorros cachorro)
        {
            try
            {
                repository.add(cachorro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cachorro/Edit/5
        public ActionResult Edit(int id)
        {
            return View(this.repository.getEdit(id));
        }

        // POST: Cachorro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Cachorros cachorro)
        {
            try
            {
                repository.edit(id, cachorro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cachorro/Delete/5
        public ActionResult Delete(int id)
        {
            repository.delete(id);
            return View();
        }

        // POST: Cachorro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Models.Cachorros cachorro)
        {
            try
            {
                repository.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
