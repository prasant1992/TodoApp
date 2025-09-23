using Microsoft.Extensions.Logging;
using ToDo.Domain.Dtos;
using ToDo.Domain.Interfaces.Mapper;

namespace ToDo.Application
{
    public class ToDoServices
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IToItemDoMapperRepository _toItemDoMapperRepository;
        private readonly ILogger<ToDoServices> _logger;

        public ToDoServices(IToDoItemRepository toDoItemRepository, ILogger<ToDoServices> logger, IToItemDoMapperRepository toItemDoMapperRepository)
        {
            _toDoItemRepository = toDoItemRepository;
            _logger = logger;
            _toItemDoMapperRepository = toItemDoMapperRepository;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllToDoItems()
        {
            try
            {
                return await _toDoItemRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all ToDo items");
            }
           return Enumerable.Empty<ToDoItem>();
        }

      
        public async Task<ToDoItem?> AddToDoItem(ToDoItemDto item)
        {           
            try
            {
                return await _toDoItemRepository.Add(_toItemDoMapperRepository.ToDoItemDtoToToDoItem(item));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding item to list");
            }
            return null;
        }

        public async Task<bool> DeleteToDoItem(int id)
        {
            try
            {
                return await _toDoItemRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting item:{id}");
            }
            return false;
        }
    }
}
