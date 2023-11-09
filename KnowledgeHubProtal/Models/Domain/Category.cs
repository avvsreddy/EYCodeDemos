using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubProtal.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Please Enter Category Name")]
        [MaxLength(100)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        [MaxLength(500)]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
    }
}
