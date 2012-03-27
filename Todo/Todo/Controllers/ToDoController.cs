using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Models;
using TodoRepository.Interfaces;
using TodoRepository.Repositories;

namespace Todo.Controllers
{
    public class ToDoController : Controller
    {
        readonly ITodoRepository _repository;

        public ToDoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            List<TodoIndexVM> items = _repository.GetTodos().Select(
                entity => new TodoIndexVM {Entry = entity.Item, Title = entity.Title})
                .ToList();
            return View(items);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(NewTodoVM model)
        {
            if(!ModelState.IsValid)
            {
                return View("New", model);
            }
            return RedirectToAction("Index");
        }
    }
}
