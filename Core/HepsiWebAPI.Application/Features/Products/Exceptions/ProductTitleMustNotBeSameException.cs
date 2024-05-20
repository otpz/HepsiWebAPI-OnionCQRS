using HepsiWebAPI.Application.Bases;

namespace HepsiWebAPI.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var"){}
    }
}
