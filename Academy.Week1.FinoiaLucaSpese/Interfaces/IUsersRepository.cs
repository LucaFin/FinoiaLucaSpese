using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Core.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        bool CheckUserId(int userId);
    }
}
