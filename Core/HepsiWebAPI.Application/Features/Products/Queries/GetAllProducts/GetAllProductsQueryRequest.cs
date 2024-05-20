﻿using MediatR;

namespace HepsiWebAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {

    }
}
