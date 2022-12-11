using SacriArt.Domain;
using SacriArt.Models.ViewModels;
using SacriArt.Models.ShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacriArt.Domain
{
    public interface IPaintingService:IEntityBaseRepository<Painting>
    {
        Task<Painting> GetPaintingByIdAsync(int id);
        //Task<NewPaintingDropdownsVM> GetNewPaintingDropdownsValues();
        //Task AddNewPaintingAsync(NewPaintingVM data);
        //Task UpdatePaintingAsync(NewPaintingVM data);
    }
}
