using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacriArt.Models.ShopModels
{
    public class Style
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Style Name")]
        [Required(ErrorMessage = "Style Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Style Name must be between 3 and 50 chars")]
        public string Name { get; set; }


        //Relationships
      
        public List<Painting> Paintings  { get; set; }

    }
}
