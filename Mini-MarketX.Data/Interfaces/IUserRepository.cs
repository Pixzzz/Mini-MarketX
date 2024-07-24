using Mini_MarketX.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_MarketX.Data.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Remove(User user);
        List<User> GetAll();
        User GetById(int userId);
        User GetByEmail(string email);
    }
}
