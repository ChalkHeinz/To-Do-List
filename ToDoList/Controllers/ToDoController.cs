using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ToDoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ToDo
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ToDoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            var todo = new ToDo
            {
                UserId = User.Identity.GetUserId(),
                DeadLine = viewModel.GetDateTime(),
                TimeCreated = DateTime.Now,
                ToDoComment = viewModel.ToDoComment
            };

            _context.ToDos.Add(todo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult UserToDo()
        {
            return View();
        }
    }
}