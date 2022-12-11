
using SacriArt.Models.ShopModels;

namespace SacriArt.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Painting> Paintings { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; }

        public IndexViewModel(IEnumerable<Painting> paintings, PageViewModel pageViewModel, FilterViewModel filterViewModel, SortViewModel sortViewModel)
        {
            Paintings = paintings;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}
