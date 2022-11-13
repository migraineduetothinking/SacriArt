using Microsoft.AspNetCore.Mvc.Rendering;
using SacriArt.Models.ShopModels;


namespace SacriArt.Models.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Author> authors, List<ExhibitionTitle> exhibitionTitles, List<Style> styles, int optionId)
        {
            Authors = new SelectList(authors, "id", "name", optionId);
            ExhibitionTitles =  new SelectList(exhibitionTitles, "id", "name", optionId);
            Styles = new SelectList(styles, "id", "name", optionId);
            SelectedCategory = optionId;
           
        }
        public SelectList Authors { get; }  

        public SelectList ExhibitionTitles { get; } 

        public SelectList Styles { get; }   

        public int SelectedCategory { get; } 
      
    }
}
