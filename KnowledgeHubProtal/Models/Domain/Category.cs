using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubProtal.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(500)]
        public string CategoryDescription { get; set; }
    }
}
