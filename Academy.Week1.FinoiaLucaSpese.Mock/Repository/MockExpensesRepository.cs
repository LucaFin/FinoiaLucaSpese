using Academy.Week1.FinoiaLucaSpese.Core.Interfaces;
using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Mock.Repository
{
    public class MockExpensesRepository : IExpensesRepository
    {
        public bool Add(Expense expense)
        {
            if(expense == null)
            {
                return false;
            }
            InMemoryStorages.expenses.Add(expense);
            return true;
        }

        public bool ApproveExpense(int Id)
        {
            foreach (Expense expense in InMemoryStorages.expenses)
            {
                if (expense.Id == Id && expense.Date<=DateTime.Today)
                {
                    expense.Aproved = true;
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Expense item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> FetchAll(Func<Expense, bool> filter = null)
        {
            return InMemoryStorages.expenses.Where(filter);
        }

        public Expense GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetExpensesSorted()
        {
            return InMemoryStorages.expenses.OrderByDescending(e => e.Date);
        }

        public int GetMaxId()
        {
            return InMemoryStorages.expenses.Select(u=>u.Id).Max();
        }

        public bool Update(Expense item)
        {
            throw new NotImplementedException();
        }
    }
}
