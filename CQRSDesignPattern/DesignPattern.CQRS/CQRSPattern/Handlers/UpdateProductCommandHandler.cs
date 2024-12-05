using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly ApplicationDbContext _context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
            var product = _context.Products.Find(command.ProductID);
            if (product != null)
            {
                product.Name = command.Name;
                product.Stock = command.Stock;
                product.Price = command.Price;
                product.Description = command.Description;
               

                _context.SaveChanges();
            }
        }
    }
}
