using TaskMaster.Models.Enums;

namespace TaskMaster.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }

        public User Owner { get; set; } = null!;
    }
}
