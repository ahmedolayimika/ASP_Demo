using System.ComponentModel.DataAnnotations;

namespace ASP_Demo.Models
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
            
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
