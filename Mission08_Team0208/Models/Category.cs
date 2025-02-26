using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0208.Models
{
    public class Category // Category class for Categories table
    {
        [Key] // Sets the primary key
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
