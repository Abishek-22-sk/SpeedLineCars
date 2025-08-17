using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedLinecars.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [Required]
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }

        [Display(Name = "Established Year")]
        public int EstablishedYear { get; set; }

        [Display(Name = "Brand Logo")]
        public string BrandLogo { get; set; }

        }
    }
