
namespace Catalog.API.Products.GetProductByCategory
{

    // public record GetProductByIdRequest(); added by best practices, but all getting from the request object

    public record GetProductByCategoryResponse(IEnumerable<Product> Product);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products/category/{Category}", async (string Category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(Category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product by Category")
            .WithDescription("Get Product by Category");
        }
    }
}
