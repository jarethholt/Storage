using Storage.Models;

namespace Storage.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }
        public int InventoryValue { get; set; }

        public ProductViewModel() { }

        public ProductViewModel(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Count = product.Count;
            InventoryValue = product.Price * product.Count;
        }
    }
}
