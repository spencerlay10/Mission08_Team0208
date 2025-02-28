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
        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Category> Categories => _context.Categories.ToList();
    }
}