using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoServices _toDoServices;

        public ToDoItemsController(ToDoServices toDoServices)
        {
            _toDoServices = toDoServices;
        }

        
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _toDoServices.GetAllToDoItems());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ToDoItemDto item)
        {
            var addedItem = await _toDoServices.AddToDoItem(item);
            if (addedItem is null) return BadRequest();
            return Ok(addedItem);
        }


        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _toDoServices.DeleteToDoItem(id);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
