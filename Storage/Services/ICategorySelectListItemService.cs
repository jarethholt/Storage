using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Services
{
    public interface ICategorySelectListItemService
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}