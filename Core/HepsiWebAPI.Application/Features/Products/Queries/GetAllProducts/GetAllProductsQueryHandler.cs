using HepsiWebAPI.Application.DTOs;
using HepsiWebAPI.Application.Interfaces.AutoMapper;
using HepsiWebAPI.Application.Interfaces.UnitOfWorks;
using HepsiWebAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HepsiWebAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(x=>!x.IsDeleted, include: x => x.Include(b => b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            var ex = new Exception("inner hata");

            throw new Exception("hata mesajı", ex);
        }
    }
}
