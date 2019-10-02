using System.Collections.Generic;
using Task.Data.Models;

namespace Task.Interfaces.Data
{
    public interface IClientRepository
    {
        Client GetById(int id);
        Client GetBySocialNumber(string socialNumber);
        IEnumerable<Client> ListAll();
    }
}
