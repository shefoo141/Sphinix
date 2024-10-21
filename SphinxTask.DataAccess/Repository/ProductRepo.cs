using SphinxTask.DataAccess.DataBase;
using SphinxTask.Models;
using System.Linq.Expressions;

namespace SphinxTask.DataAccess.Repository
{
    public class ProductRepo: IProductRepo
    {
        private readonly AppDB context;

        public ProductRepo(AppDB _context)
        {
            context = _context;
        }
        public List<Product> GetAll(Expression<Func<Product, bool>>? Filter = null)
        {
           var Prd = context.products.AsQueryable();
            if (Filter != null)
            { 
                Prd = Prd.Where(Filter);
            }
            return Prd.OrderBy(P=>P.PName).ToList();    
           
        }
        public Product GetOne(int id)
        {
            return context.products.FirstOrDefault(x => x.PId == id);
        }
        public void Insert(Product prd)
        {
            context.products.Add(prd);
            context.SaveChanges();

        }
        public void Edit(Product prd)
        {
            context.products.Update(prd);
            context.SaveChanges();
        }
        public void delete(int ID)
        {
            Product prd = GetOne(ID);
            context.products.Remove(prd);
            context.SaveChanges();
        }
    }
}
