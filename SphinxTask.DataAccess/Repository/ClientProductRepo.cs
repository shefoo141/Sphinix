using SphinxTask.DataAccess.DataBase;
using SphinxTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphinxTask.DataAccess.Repository
{
    public class ClientProductRepo : IClientProductRepo
    {
        private readonly AppDB context;

        public ClientProductRepo(AppDB _context)
        {
            context = _context;
        }
        public List<ClientProducts> GetAll()
        {
            return context.clientProducts.ToList();
        }
        public ClientProducts GetOne(int id)
        {
            return context.clientProducts.FirstOrDefault(x => x.ClientproductsId == id);
        }
        public void insert(ClientProducts cltproduct)
        {
            context.clientProducts.Add(cltproduct);
            context.SaveChanges();
        }
        public void delete(int ID)
        {
            ClientProducts cp = GetOne(ID);
            context.clientProducts.Remove(cp);
            context.SaveChanges();
        }
        public void Edit(ClientProducts cp)
        {
            context.clientProducts.Update(cp);
            context.SaveChanges();
        }

        public bool GetRelatedProdcut(int productId)
        {
            return context.clientProducts.Any(x => x.ProductId == productId);   
        }
    }
}
