namespace ToDo.Domain.Entity
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
