using System.ComponentModel.DataAnnotations;

namespace AmberAndGrain.Models
{
    public class RecipeDto
    {

        public int Id { get; set; }

        [Display(Name="Name")]
        [MaxLength(200,ErrorMessage ="Name cannot be more than 200 characters")]
        [Required]
        public string Name { get; set; }

        [Display(Name="Percentage Wheat")]
        [Range(0,100)]
        [Required]
        public decimal PercentWheat { get; set; }

        [Display(Name = "Percentage Corn")]
        [Range(0, 100)]
        [Required]
        public decimal PercentCorn{ get; set; }

        [Display(Name = "Barrel Age (in Months)")]
        [Required]
        public int BarrelAge { get; set; }

        [Display(Name = "Barrel Material")]
        [Required]
        public string BarrelMaterial { get; set; }

        [Display(Name = "Recipe Creator")]
        [Required]
        public string Creator { get; set; }
    }
}