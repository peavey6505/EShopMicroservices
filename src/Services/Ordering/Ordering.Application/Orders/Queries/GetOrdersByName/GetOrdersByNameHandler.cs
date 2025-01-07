using Microsoft.EntityFrameworkCore;
using Ordering.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext context) : IQueryHandler<GetOrderByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrderByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await context
                .Orders
                .Include(x=> x.OrderItems)
                .AsNoTracking()
                .Where(x => x.OrderName.Value.Contains(request.Name))
                .OrderBy(x => x.OrderName.Value)
                .ToListAsync(cancellationToken);

            return new GetOrdersByNameResult(result.ToOrderDtoList());
        }

    }
}
