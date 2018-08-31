using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using CityLibrary.MVC.RepositoryPattern;
using System.Collections.Generic;

namespace CityLibrary.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        //private readonly CityLibraryDbContext _context;
         
        public BookController(IBookRepository bookRepository, CityLibraryDbContext context)
        {
            _bookRepository = bookRepository;
        }

        // GET: Book
        public ActionResult Index()
        {
            var model = _bookRepository.GetAllDetails();
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookRepository.GetEntity(id.Value).FirstOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        
        // GET: Book/Create
        public ActionResult Create()
        {
            //var authors = _bookRepository.GetAuthorNameAndId();
            //ViewBag.AuthorId = new SelectList(authors, "Id", "AuthorName");
            ViewBag.AuthorId = _bookRepository.GetAuthorNameAndId();
            ViewBag.GenreId = _bookRepository.GetGenreIdAndType();
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,AuthorId,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Create(book);
                return RedirectToAction("Index");
            }

            //ViewBag.AuthorId = _bookRepository.GetAuthorNameAndId(book.AuthorId);
            //ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Type", book.GenreId);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookRepository.GetEntity(id.Value).FirstOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = _bookRepository.GetAuthorNameAndId(book.AuthorId);
            ViewBag.GenreId = _bookRepository.GetGenreIdAndType(book.GenreId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,AuthorId,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                //_context.Entry(book).State = EntityState.Modified;
                _bookRepository.Update(book);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = _bookRepository.GetAuthorNameAndId(book.AuthorId);
            ViewBag.GenreId = _bookRepository.GetGenreIdAndType(book.GenreId);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookRepository.GetEntity(id.Value).FirstOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = _bookRepository.GetEntity(id).FirstOrDefault();
            _bookRepository.Delete(book);
            return RedirectToAction("Index");
        }

    }
}
