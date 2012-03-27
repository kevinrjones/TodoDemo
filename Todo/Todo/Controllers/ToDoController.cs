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
            List<TodoIndexVM> items = _repository.Entities.Select(
                entity => new TodoIndexVM {Entry = entity.Item, Title = entity.Title})
                .ToList();
            return View(items);
        }

    }
}
