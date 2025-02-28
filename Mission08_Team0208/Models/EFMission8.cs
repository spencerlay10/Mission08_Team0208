using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Mission08_Team0208.Models
{
    public class EFMission8 : IMission8
    {
        private QuadrantContext _context;
        public EFMission8(QuadrantContext temp)
        {
            _context = temp;
        }

        public IQueryable<Task> Tasks => _context.Tasks.Include(t => t.Category); // Now supports Include
        public IQueryable<Category> Categories => _context.Categories;

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void MarkComplete(int taskId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Completed = true;
                _context.SaveChanges();
            }
        }

        public void UpdateInfo(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }
    }


}