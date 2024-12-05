using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly ApplicationDbContext _context;

        public RemoveProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Handle (RemoveProductCommand command) 
        {
            var values = _context.Products.Find(command.Id);
            _context.Products.Remove(values);
            _context.SaveChanges();
        }
    }
}
