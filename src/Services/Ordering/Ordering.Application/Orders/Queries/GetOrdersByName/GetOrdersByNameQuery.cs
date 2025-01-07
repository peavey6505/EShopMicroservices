﻿using FluentValidation;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public record GetOrderByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);

}
