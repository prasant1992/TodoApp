using ToDo.Domain.Entity;
using ToDo.Domain.Interfaces;

namespace ToDo.InMemory.Db.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _items = new();
        public async Task<ToDoItem?> Add(ToDoItem item)
        {
            if(_items.FirstOrDefault(x => x.Id == item.Id) is not null)
                return null;

            item.Id = GetNextId();
            _items.Add(item);
            return item;
        }

        public async Task<int> Delete(int id)
        {
           return _items.RemoveAll(i => i.Id == id); 
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
