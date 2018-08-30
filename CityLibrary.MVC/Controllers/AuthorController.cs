using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using CityLibrary.MVC.RepositoryPattern;

namespace CityLibrary.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
       

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: Authors
        public ActionResult Index()
        {
            var model = _authorRepository.GetAll().ToList();
            return View(model);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorRepository.GetEntity(id.Value).FirstOrDefault();
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AuthorName")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.Create(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorRepository.GetEntity(id.Value).FirstOrDefault();
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorName")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorRepository.GetEntity(id.Value).FirstOrDefault();
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = _authorRepository.GetEntity(id).FirstOrDefault();
            _authorRepository.Delete(author);
            return RedirectToAction("Index");
        }

    }
}
