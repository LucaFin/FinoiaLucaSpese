using Academy.Week1.FinoiaLucaSpese.Core.Interfaces;
using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Mock.Repository
{
    public class MockCategoriesRepository : ICategoriesRepository
    {
        public bool Add(Category item)
        {
            throw new NotImplementedException();
        }

        public bool CheckCategoryId(int categoryId)
        {
            return InMemoryStorages.categories.Contains(InMemoryStorages.categories.Find(c=>c.Id==categoryId));
        }

        public bool Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> FetchAll(Func<Category, bool> filter = null)
        {
            return InMemoryStorages.categories.Where(filter);
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
