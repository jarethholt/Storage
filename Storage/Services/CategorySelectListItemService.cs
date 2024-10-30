using Microsoft.AspNetCore.Mvc.Rendering;
using Storage.Data;

namespace Storage.Services
{
    public class CategorySelectListItemService(StorageContext context) : ICategorySelectListItemService
    {
        private readonly string[] _categories = [.. context.Categories.Select(category => category.Name)];

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categories.Select(
                category => new SelectListItem { Text = category, Value = category }
                ).ToList();
        }
    }
}
