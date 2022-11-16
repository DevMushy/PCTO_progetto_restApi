using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Controllers
{
    [Route("api/TodoItemDTO/")]
    [ApiController]
    [Authorize]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        /// <summary>
        /// Get all TodoItemDTO.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public  ActionResult<IEnumerable<TodoItemDTO>> GetTodoItems()
        {
            return  _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToList();
        }

        // GET: api/TodoItems/5
        /// <summary>
        /// Get a specific TodoItemDTO.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<TodoItemDTO> GetTodoItem(long id)
        {
            var todoItem =  _context.TodoItems.FirstOrDefault(x => x.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(todoItem);
        }
        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Override a specific TodoItemDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItemDTO"></param>
        /// <response code="200">Returns an overridden TodoItemDTO</response>
        /// <response code="304">If the item is not overridden</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        [HttpPut("{id}")]
        public IActionResult UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;
            todoItem.Email = todoItemDTO.Email;
            todoItem.Password = todoItemDTO.Password;
            todoItem.child = todoItemDTO.child;


            return NoContent();
        }
        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Post a TodoItemDTO.
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("PostItem")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public ActionResult<TodoItemDTO> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name,
                Email = todoItemDTO.Email,
                Password = todoItemDTO.Password,
                child = todoItemDTO.child,
                
            };

            _context.TodoItems.Add(todoItem);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id},
                ItemToDTO(todoItem));
        }

        // DELETE: api/TodoItems/5
        /// <summary>
        /// Delete a specific TodoItemDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns the deleted item</response>
        /// <response code="204">If the item is null</response>
        /// <response code="404">object was not deleted, not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTodoItem(long id)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                Email = todoItem.Email,
                Password = todoItem.Password,
                IsComplete = todoItem.IsComplete,
                child = todoItem.child
            };
    }
}
