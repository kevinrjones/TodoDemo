using System.Collections.Generic;
using System.Linq;
using Repository;
using TodoModel;
using TodoRepository.Contexts;
using TodoRepository.Interfaces;

namespace TodoRepository.Repositories
{
    public class TodosRepository : BaseEfRepository<Todo>, ITodoRepository
    {
        public TodosRepository(string connectionString)
            : base(new TodoDbContext(connectionString)) { }

        public Todo GetTodo(int id)
        {
            var b = (from p in Entities
                     where p.Id == id
                     select p).FirstOrDefault();
            return b;
        }

        public IList<Todo> GetTodos()
        {
            return (from e in Entities
                    select e).ToList();
        }

        public IList<Todo> GetOrderedTodos()
        {
            return (from e in Entities
                    select e)
                    .OrderByDescending(e => e.Posted)
                    .ToList();
        }
    }
}