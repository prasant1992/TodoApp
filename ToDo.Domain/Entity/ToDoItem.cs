namespace ToDo.Domain.Entity
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; } = 0; // 0 - Low, 1 - Medium, 2 - High
        public DateTime? CompletedDate { get; set; }
    }
}
