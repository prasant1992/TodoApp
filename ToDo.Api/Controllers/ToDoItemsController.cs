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

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _toDoServices.GetToDoItemById(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

       
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ToDoItemDto item)
        {
            var addedItem = await _toDoServices.AddToDoItem(item);
            if (addedItem is null) return BadRequest();
            return Ok(addedItem);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ToDoItemDto item)
        {
            var updatedItem = await _toDoServices.UpdateToDoItem(item);
            if (updatedItem is null) return BadRequest();
            return Ok(updatedItem);
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
