using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Task.Data.Models;
using Task.Interfaces.Data;

namespace Task.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbContext _dbContext;

        public ClientRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client GetById(int id)
        {
            return _dbContext.Set<Client>().Find(id);
        }

        public Client GetBySocialNumber(string socialNumber)
        {
            return ListAll().Where(c => c.SocialNumber == socialNumber).FirstOrDefault();
        }

        public IEnumerable<Client> ListAll()
        {
            return _dbContext.Set<Client>().ToList();
        }
    }
}
