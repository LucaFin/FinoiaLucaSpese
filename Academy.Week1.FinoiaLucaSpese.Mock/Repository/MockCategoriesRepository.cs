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
        public bool Add(Category category)
        {
            if(category == null)
            {
                return false;
            }
            InMemoryStorages.categories.Add(category);
            return true;
        }

        public bool CheckCategoryId(int categoryId)
        {
            return InMemoryStorages.categories.Contains(InMemoryStorages.categories.Find(c=>c.Id==categoryId));
        }

        public bool Delete(Category category)
        {
            return InMemoryStorages.categories.Remove(category);
        }

        public IEnumerable<Category> FetchAll(Func<Category, bool> filter = null)
        {
            if(filter == null)
            {
                return InMemoryStorages.categories;
            }
            return InMemoryStorages.categories.Where(filter);
        }

        public Category GetById(int id)
        {
            return InMemoryStorages.categories.Where(e=>e.Id==id).First();
        }

        public bool Update(Category category)
        {
            if (category == null)
            {
                return false;
            }
            Category removed = InMemoryStorages.categories.Where(c=>c.Id==category.Id).First();  
            return Delete(removed) && Add(category);
            
        }
    }
}
