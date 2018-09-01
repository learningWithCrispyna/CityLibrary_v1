using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using CityLibrary.MVC.RepositoryPattern;

namespace CityLibrary.MVC.Controllers
{
    public class HomelessController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomelessController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Homeless
        public ActionResult Index()
        {
            var model = _userRepository.GetAll().ToList();
            return View(model);
        }

        // GET: Homeless/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.GetEntity(id.Value).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Homeless/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homeless/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                //db.Users.Add(user);
                //db.SaveChanges();
                _userRepository.Create(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Homeless/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = _userRepository.GetEntity(id.Value).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Homeless/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Homeless/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.GetEntity(id.Value).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Homeless/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _userRepository.GetEntity(id).FirstOrDefault();
            _userRepository.Delete(user);
            return RedirectToAction("Index");
        }
    }
}
