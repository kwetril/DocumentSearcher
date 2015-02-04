using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSearcher.Models;
using DocumentSearcher.Models.DatabaseAccess;

namespace DocumentSearcher.Controllers
{
    public class TestDatabaseController : Controller
    {
        private readonly IUserRepository userRepository;

        public TestDatabaseController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //
        // GET: /TestDatabase/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert(string user)
        {
            userRepository.InsertUser(new User() {Name = user});
            return RedirectToAction("Index");
        }

        public ActionResult Users()
        {
            User[] users = userRepository.GetUsers();
            return View(users);
        }
	}
}