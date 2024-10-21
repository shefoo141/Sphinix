using SphinxTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphinxTask.DataAccess.Repository
{
    public interface IClientRepo
    {
        public List<Client> GetAll();
        public Client Getone(int id , string? Props = null);
        public void Insert(Client clt);
        public void delete(int ID);
        public void Edit(Client clt);
    }
}
