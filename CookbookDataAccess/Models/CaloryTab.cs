using System.ComponentModel.DataAnnotations;

namespace CookbookDataAccess.Models
{
    public class CaloryTab
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public int TabId { get; set; }

        [Required]
        [MaxLength(50)]
        public int Kcal { get; set; }

        [Required]
        [MaxLength(50)]
        public float Protein { get; set; }
    }
}
