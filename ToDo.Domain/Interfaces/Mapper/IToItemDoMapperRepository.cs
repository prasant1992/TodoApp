using ToDo.Domain.Dtos;
using ToDo.Domain.Entity;

namespace ToDo.Domain.Interfaces.Mapper
{
    public interface IToItemDoMapperRepository
    {
        ToDoItem ToDoItemDtoToToDoItem(ToDoItemDto dto);
        ToDoItemDto ToDoItemToToDoItemDto(ToDoItem item);
    }
}
