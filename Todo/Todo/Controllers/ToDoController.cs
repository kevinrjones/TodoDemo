using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Todo.Models;
using TodoRepository.Interfaces;

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
            NewTodoVM model = new NewTodoVM();
            return View(model);
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
