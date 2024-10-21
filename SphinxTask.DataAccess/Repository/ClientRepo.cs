
using Microsoft.EntityFrameworkCore;
using SphinxTask.DataAccess.DataBase;
using SphinxTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphinxTask.DataAccess.Repository
{
    public class ClientRepo : IClientRepo
    {
        private readonly AppDB context;

        public ClientRepo(AppDB _context)
        {
            context = _context;
        }
        public List<Client> GetAll()
        {
            return context.clients.OrderBy(C => C.Code).ToList();
        }
        public Client Getone(int id , string? props = null)
        {
            IQueryable<Client> clients = context.clients;
            if (props != null)
            {
               clients = clients.Include(x => x.ClientProducts).ThenInclude(y => y.product);
            }
            return clients.FirstOrDefault(x => x.CId == id);
        }
        public void Insert(Client clt)
        {
            context.clients.Add(clt);
            context.SaveChanges();

        }
        public void delete(int ID)
        {
            Client clt = Getone(ID);
            context.clients.Remove(clt);
            context.SaveChanges();
        }
        public void Edit(Client clt)
        {
            context.clients.Update(clt);
            context.SaveChanges();
        }

    }
}
