using System.Data.Entity;
using TodoModel;

namespace TodoRepository.Contexts
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(string connectionString) : base(connectionString) { }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todos");
        }
    }
}