
using SacriArt.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacriArt.Models.ShopModels
{
    public class Painting //: IEntityBase
    { 

        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        public int? Year { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageUrl { get; set; }


        [Display(Name = "Size")]
        [Required(ErrorMessage = "Size is required")]
        public string Size { get; set; }

              
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }


        //Relationships

        //Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        //ExhibitionTitle
        public int ExhibitionTitleId { get; set; }
        [ForeignKey("ExhibitionTitleId")]
        public ExhibitionTitle ExhibitionTitle { get; set; }

        //Style
        public int StyleId { get; set; }
        [ForeignKey("StyleId")]
        public Style Style { get; set; }
    }


}
