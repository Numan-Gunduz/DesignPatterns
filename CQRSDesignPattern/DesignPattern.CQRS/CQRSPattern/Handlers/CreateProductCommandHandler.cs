using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;
using System.Reflection.Metadata;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Handle (CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                Description = command.Description,
                Price = command.Price,
                Name = command.Name,
                Status = command.Status,
                Stock = command.Stock,
            });
            _context.SaveChanges();
        }
    }
}
