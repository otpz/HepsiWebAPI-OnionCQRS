using HepsiWebAPI.Domain.Common;

namespace HepsiWebAPI.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(){}

        public Product(string title, string description, int brandId, decimal price, decimal discount)
        {
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId { get; set; }
        public Brand Brand { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
        public ICollection<Category> ProductCategories { get; set; }

    }
}
