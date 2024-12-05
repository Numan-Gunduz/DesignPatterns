using RepositoryDesignPattern.DataAccessLayer.Abstract;
using RepositoryDesignPattern.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Delete(T t)
        {
           _applicationDbContext.Remove(t);
            _applicationDbContext.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _applicationDbContext.Add(t);
            _applicationDbContext.SaveChanges();

        }

        public void Update(T t)
        {
           _applicationDbContext.Update(t);
            _applicationDbContext.SaveChanges();

        }
    }
}
