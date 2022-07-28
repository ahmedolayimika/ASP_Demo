using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo.Models
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
            
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,10)]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
