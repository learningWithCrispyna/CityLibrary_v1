using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using CityLibrary.MVC.RepositoryPattern;

namespace CityLibrary.MVC.Controllers
{
    public class BookController : Controller
    {
        private CityLibraryDbContext db = new CityLibraryDbContext();

        private readonly IBookRepository _bookRepository;
        private readonly CityLibraryDbContext _context;

        public BookController(IBookRepository bookRepository,CityLibraryDbContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        // GET: Book
        public ActionResult Index()
        {
            var model = _context.Books.Include(a=>a.Author).Include(b=>b.Genre).ToList();
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
            ViewBag.AuthorId = new SelectList(_context.Authors, "Id", "AuthorName");
            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Type");
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
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_context.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Type", book.GenreId);
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
            ViewBag.AuthorId = new SelectList(_context.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Type", book.GenreId);
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
                _context.Entry(book).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_context.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Type", book.GenreId);
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
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
