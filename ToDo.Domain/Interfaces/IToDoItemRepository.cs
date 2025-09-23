using ToDo.Domain.Entity;

namespace ToDo.Domain.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetAll();
        Task<ToDoItem?> Add(ToDoItem item);
        Task<int> Delete(int id);
    }
}
