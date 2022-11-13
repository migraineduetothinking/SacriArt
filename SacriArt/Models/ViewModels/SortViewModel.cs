using SacriArt.Models.ShopModels;


namespace SacriArt.Models.ViewModels
{
    public class SortViewModel
    {
        public SortOption NameSort { get; }        // value to sort by name
        public SortOption PriceSort { get; }       // value to sort by price
        public SortOption Current { get; }         // текущее значение сортировки

        public SortViewModel(SortOption sortOrder)
        {
            NameSort = sortOrder == SortOption.NameAsc ? SortOption.NameDesc : SortOption.NameAsc;
            PriceSort = sortOrder == SortOption.PriceAsc ? SortOption.PriceDesc : SortOption.PriceAsc;
           
            Current = sortOrder;
        }
    }
}
