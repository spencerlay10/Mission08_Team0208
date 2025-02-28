namespace Mission08_Team0208.Models
{
    public interface IMission8
    {
        IQueryable<Task> Tasks { get; }  // Change from List to IQueryable
        IQueryable<Category> Categories { get; }

        void AddTask(Task task);
        void UpdateInfo(Task task);
        void DeleteTask(Task task);
    }
}
