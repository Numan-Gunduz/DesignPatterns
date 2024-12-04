using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetProductQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<GetProductQueryResult> Handle() 
        {
            var values = _applicationDbContext.Products.Select(x=>new GetProductQueryResult
            {
                ProductID = x.ProductID,
                ProductName=x.Name,
                ProductPrice=x.Price,
                ProductStock=x.Stock,   
            }).ToList();
            return values;
        }
    }
}
