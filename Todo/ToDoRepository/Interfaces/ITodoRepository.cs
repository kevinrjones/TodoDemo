using System.Collections.Generic;
using Repository;
using TodoModel;

namespace TodoRepository.Interfaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
        Todo GetTodo(int id);
        IList<Todo> GetTodos();
    }
}