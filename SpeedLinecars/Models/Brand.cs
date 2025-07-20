using System.ComponentModel.DataAnnotations;

namespace SpeedLinecars.Models
{
    public class Brand
    {
        [Key]
        public Guid BrandId { get; set; }

        [Required]
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }

        [Display(Name = "Established Year")]
        public int EstablishedYear { get; set; }

        [Display(Name = "Brand Logo")]
        public string BrandLogo { get; set; }

        }
    }
