using SphinxTask.Models;

namespace SphinxTask.DataAccess.Repository
{
    public interface IClientProductRepo
    {
        public List<ClientProducts> GetAll();
        public void insert(ClientProducts cltproduct);
        public ClientProducts GetOne(int id);
        public bool GetRelatedProdcut(int productId);
        public void delete(int ID);
        public void Edit(ClientProducts cp);
    }
}