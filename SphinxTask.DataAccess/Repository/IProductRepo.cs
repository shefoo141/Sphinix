using SphinxTask.Models;
using System.Linq.Expressions;


namespace SphinxTask.DataAccess.Repository
{
    public interface IProductRepo
    {
        public List<Product> GetAll(Expression<Func<Product, bool>>? Filter = null);
        public Product GetOne(int id);
        public void Insert(Product prd);
        public void Edit(Product prd);
        public void delete(int ID);
    }
}
