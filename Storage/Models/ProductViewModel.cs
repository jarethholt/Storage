namespace Storage.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }
        public int InventoryValue { get; set; }

        public static ProductViewModel FromProduct(Product product)
            => new()
            {
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                InventoryValue = product.Price * product.Count
            };
    }
}
