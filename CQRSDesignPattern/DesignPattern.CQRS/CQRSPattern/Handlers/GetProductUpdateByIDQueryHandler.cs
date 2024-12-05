using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateByIDQueryHandler
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetProductUpdateByIDQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public GetProductUpdateQueryResult Handle(GetProductUpdateByIDQuery query)
        {
            var values = _applicationDbContext.Products.Find(query.ID);
            return new GetProductUpdateQueryResult
            {
                Description = values.Description,
                Name = values.Name,
                ProductID = values.ProductID,//yazmasak da olur 
                Price = values.Price,
                Stock = values.Stock,
            };

        }
    }
}
