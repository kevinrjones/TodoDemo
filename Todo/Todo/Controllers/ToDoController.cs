using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoRepository.Repositories;

namespace Todo.Controllers
{
    public class ToDoController : Controller
    {
        TodosRepository _repository = new TodosRepository(ConfigurationManager.ConnectionStrings["todo"].ConnectionString);

        public ActionResult Index()
        {
            return View();
        }

    }
}
