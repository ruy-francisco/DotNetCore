using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController: Controller {
        private readonly TodoContext _context;

        public TodoController(TodoContext context) {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1"});
                _context.SaveChanges();
            }
        }

        [HttpGet("items")]
        public IEnumerable<TodoItem> GetAll() => _context.TodoItems.ToList();

        [HttpGet("items/{id}", Name = "GetTodo")]
        public IActionResult GetById(long id) {
            var item = _context.TodoItems.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item){
            if (item == null)
                return BadRequest();

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item) {
            if (item == null || id != item.Id)
                return BadRequest();

            var todoToUpdate = _context.TodoItems.FirstOrDefault(i => i.Id == id);
            if (todoToUpdate == null)
                return NotFound();

            todoToUpdate.IsComplete = item.IsComplete;
            todoToUpdate.Name = item.Name;

            _context.TodoItems.Update(todoToUpdate);
            _context.SaveChanges();
            
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            var itemToDelete = _context.TodoItems.FirstOrDefault(i => i.Id == id);
            if (itemToDelete == null)
                return NotFound();

            _context.TodoItems.Remove(itemToDelete);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}