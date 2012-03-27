using System;

namespace TodoModel
{
    public class Todo
    {
        public int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Item { get; set; }
        public DateTime Posted { get; set; }
        public int State { get; set; }
    }
}