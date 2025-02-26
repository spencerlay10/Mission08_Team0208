using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0208.Models
{
    public class Task
    {
        [Key] // Sets the primary key
        [Required] // Sets the field as required
        public int TaskId { get; set; }

        [Required]
        public string TaskTitle { get; set; }

        [Required]
        public DateOnly DueDate { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Quadrant can only be a number 1-4.")]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")] // Sets the foreign key
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } // Creates a Category object
        
        [Required]
        public bool Completed { get; set; }
    }
}
