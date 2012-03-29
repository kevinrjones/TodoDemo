using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Todo.Filters;
using Todo.Models;
using TodoRepository;
using TodoRepository.Interfaces;
using Todo = TodoModel.Todo;

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
                entity => new TodoIndexVM { Entry = entity.Item, Title = entity.Title, Id = entity.Id })
                .ToList();
            return View(items);
        }

        [AcitiveDirectoryAuthorizationFilter]
        public ActionResult New()
        {
            NewTodoVM model = new NewTodoVM();
            return View(model);
        }

        public ActionResult Create(NewTodoVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var entity = _repository.GetTodo(id);
            var model = new EditViewModel { Id = 1, Title = entity.Title, Entry = entity.Item };
            return View(model);
        }

        public ActionResult Update(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }
            var entity = _repository.GetTodo(model.Id);
            entity.Title = model.Title;
            entity.Item = model.Entry;
            _repository.Update(entity);
            return RedirectToAction("Index");
        }
    }
}
