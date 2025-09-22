using ToDo.Domain.Entity;

namespace ToDo.Domain.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetAll();
        Task<ToDoItem?> GetById(int id);
        Task<ToDoItem> Add(ToDoItem item);
        Task<ToDoItem?> Update(ToDoItem item);
        Task<bool> Delete(int id);
    }
}
