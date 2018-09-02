using System.Linq;
using System.Net;
using System.Web.Mvc;
using CityLibrary.MVC.Models;
using CityLibrary.MVC.RepositoryPattern;
using CityLibrary.MVC.Attributes;

namespace CityLibrary.MVC.Controllers
{
    [CityLibraryAuthorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
         
        public BookController(IBookRepository bookRepository)
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
            var authors = _bookRepository.GetBookAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "AuthorName");

            var genres = _bookRepository.GetBookGenres();
            ViewBag.GenreId = new SelectList(genres, "Id", "Type");

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

            var authors = _bookRepository.GetBookAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "AuthorName", book.AuthorId);

            var genres = _bookRepository.GetBookGenres();
            ViewBag.GenreId = new SelectList(genres, "Id", "Type", book.GenreId);

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

            var authors = _bookRepository.GetBookAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "AuthorName", book.AuthorId);

            var genres = _bookRepository.GetBookGenres();
            ViewBag.GenreId = new SelectList(genres, "Id", "Type", book.GenreId);

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
                _bookRepository.Update(book);
                return RedirectToAction("Index");
            }

            var authors = _bookRepository.GetBookAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "AuthorName", book.AuthorId);

            var genres = _bookRepository.GetBookGenres();
            ViewBag.GenreId = new SelectList(genres, "Id", "Type", book.GenreId);

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
