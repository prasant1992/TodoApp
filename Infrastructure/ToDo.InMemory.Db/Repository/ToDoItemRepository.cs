using ToDo.Domain.Entity;
using ToDo.Domain.Interfaces;

namespace ToDo.InMemory.Db.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _items = new();
        public async Task<ToDoItem> Add(ToDoItem item)
        {
            item.Id = GetNextId();
            _items.Add(item);
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            _items.RemoveAll(i => i.Id == id);
            return true;
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            return _items;
        }

        private int GetNextId()
        {
            if (_items.Count == 0) return 1;
            return _items.Max(i => i.Id) + 1;
        }
    }
}
