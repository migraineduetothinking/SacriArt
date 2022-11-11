using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacriArt.Models.ShopModels
{
    public class ExhibitionTitle
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Exhibition Title")]
        [Required(ErrorMessage = "Exhibition Title is required")]
        [StringLength(75, MinimumLength = 1, ErrorMessage = "Exhibition Title must be between 1 and 75 chars")]
        public string Name { get; set; }


        //Relationships
        
        public List<Painting> Paintings { get; set; }

    }
}
