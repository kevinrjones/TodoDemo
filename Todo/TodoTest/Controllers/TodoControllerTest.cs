using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Todo.Controllers;
using Todo.Models;
using TodoRepository.Interfaces;
using Todo = TodoModel.Todo;

namespace TodoTest.Controllers
{
    [TestFixture]
    public class TodoControllerTest
    {
        Mock<ITodoRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ITodoRepository>();
        }

        [Test]
        public void WhenTheIndexActionIsExecuted_ThenItShouldReturnAViewResult()
        {
            _repository.Setup(r => r.GetTodos()).Returns(new List<TodoModel.Todo>());
            var controller = new ToDoController(_repository.Object);
            var result = controller.Index();

            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        [Test]
        public void GivenAListOfTodos_WhenTheIndexActionIsExecuted_ThenTheFullListIsReturned()
        {
            _repository.Setup(r => r.GetTodos()).Returns(new List<TodoModel.Todo>{new TodoModel.Todo()});
            var controller = new ToDoController(_repository.Object);
            var result = controller.Index() as ViewResult;
            var model = result.Model as IList<TodoIndexVM>;
            
            Assert.That(model.Count, Is.EqualTo(1));
        }

        [Test]
        public void WhenTheNewModelIsInvalid_ThenTheNewViewIsReturned()
        {
            ToDoController controller = new ToDoController(null);
            controller.ModelState.AddModelError("key", "value");
            var result = controller.Create(new NewTodoVM());
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        [Test]
        public void WhenTheNewModelIsValid_ThenTheIndexViewIsRedirectedTo()
        {
            ToDoController controller = new ToDoController(null);
            var result = controller.Create(new NewTodoVM());
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }
    }
}
