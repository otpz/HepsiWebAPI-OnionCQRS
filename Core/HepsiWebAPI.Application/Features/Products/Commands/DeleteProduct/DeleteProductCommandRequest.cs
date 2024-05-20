using MediatR;

namespace HepsiWebAPI.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
