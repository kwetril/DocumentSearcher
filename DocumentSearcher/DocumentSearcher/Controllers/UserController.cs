using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DocumentSearcher.Models;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
using DocumentSearcher.Models.Helpers;

namespace DocumentSearcher.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Login, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Login, false);
                    return RedirectToAction("Index", "Search");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed. User with such login and password doesn't exist.");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var cryptoService = new SimpleCrypto.PBKDF2();
                var userToSave = new User();
                userToSave.Login = user.Login;
                userToSave.PasswordSalt = cryptoService.GenerateSalt();
                userToSave.Password = cryptoService.Compute(user.Password, userToSave.PasswordSalt);
                userToSave.Role = RoleHelper.UserRole;
                userRepository.Create(userToSave);
                return RedirectToAction("Index", "Search");
            }
            else
            {
                ModelState.AddModelError("", "Registration data are incorrect.");
            }

            return View();
        }

        public ActionResult LogOut(User user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Search");
        }

        private bool IsValid(string login, string password)
        {
            var user = userRepository.FindByLogin(login);
            if (user == null)
            {
                return false;
            }

            var cryptoService = new SimpleCrypto.PBKDF2();
            string hashedPassword = cryptoService.Compute(password, user.PasswordSalt);
            return user.Password.Equals(hashedPassword);
        }
	}
}