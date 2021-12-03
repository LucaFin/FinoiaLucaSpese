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
        public bool Add(User user)
        {
            if (user == null)
            {
                return false;
            }
            InMemoryStorages.users.Add(user);
            return true;
        }

        public bool CheckUserId(int userId)
        {
            return InMemoryStorages.users.Contains(InMemoryStorages.users.Find(u=>u.Id==userId));
        }

        public bool Delete(User user)
        {
            return InMemoryStorages.users.Remove(user);
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
            return InMemoryStorages.users.Where(u => u.Id==id).First();
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                return false;
            }
            User removed = InMemoryStorages.users.Where(c => c.Id == user.Id).First();
            return Delete(removed) && Add(user);
        }
    }
}
