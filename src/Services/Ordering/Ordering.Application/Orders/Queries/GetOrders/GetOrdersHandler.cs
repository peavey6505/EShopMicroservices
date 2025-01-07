
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext context)
        : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var pageSize = query.PaginationRequest.PageSize;
            var pageIndex = query.PaginationRequest.PageIndex;

            var totalCount = await context.Orders.LongCountAsync(cancellationToken);


            var result = await context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);


            return new GetOrdersResult(
                new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                totalCount,
                result.ToOrderDtoList()));
        }
    }
}
