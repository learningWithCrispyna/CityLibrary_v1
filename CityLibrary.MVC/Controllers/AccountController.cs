using System.Linq;
using System.Web.Mvc;
using CityLibrary.MVC.Models;
using CityLibrary.MVC.RepositoryPattern;
using CityLibrary.MVC.Utils;

namespace CityLibrary.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var encryptedPassword = PasswordEncryptor.Encrypt(model.Password);
                var user = new User { Name = model.Name, Password = encryptedPassword };
                _userRepository.Create(user);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.GetAll().Where(x => x.Name == model.Name).SingleOrDefault();
            if (user != null)
            {
                var decryptedPassword = PasswordEncryptor.Decrypt(user.Password);
                if (model.Password == decryptedPassword)
                {
                    Session["LogedIn"] = true;
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["LogedIn"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}
