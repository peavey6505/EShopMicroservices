
namespace Catalog.API.Products.GetProducts
{
    //best practice - always define query command and result class in a handler class // arguable

    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler 
        (IDocumentSession session)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
