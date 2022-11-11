
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class TodoContext
    {
        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}