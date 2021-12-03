using Academy.Week1.FinoiaLucaSpese.Core.Interfaces;
using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Mock.Repository
{
    public class MockUsersRepository : IUsersRepository
    {
        public bool Add(User item)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserId(int userId)
        {
            return InMemoryStorages.users.Contains(InMemoryStorages.users.Find(u=>u.Id==userId));
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FetchAll(Func<User, bool> filter = null)
        {
            if(filter == null)
            {
                return InMemoryStorages.users;
            }
            return InMemoryStorages.users.Where(filter);
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
