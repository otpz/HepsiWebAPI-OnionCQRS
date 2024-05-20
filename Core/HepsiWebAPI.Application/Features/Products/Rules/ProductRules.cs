using HepsiWebAPI.Application.Bases;
using HepsiWebAPI.Application.Features.Products.Exceptions;
using HepsiWebAPI.Domain.Entities;

namespace HepsiWebAPI.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
