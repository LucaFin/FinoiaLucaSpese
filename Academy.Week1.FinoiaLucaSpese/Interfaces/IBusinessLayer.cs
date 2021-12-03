using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Core.Interfaces
{
    public interface IBusinessLayer
    {
        bool ApproveExpense(int id);
        bool CheckCategoryId(int categoryId);
        bool CheckUserId(int userId);
        int GetNextExpenseId();
        bool Add(Expense expense);
        IEnumerable<Expense> GetExpensesLastMonth();
        IEnumerable<Expense> GetUserExpense(int userId);
        IEnumerable<Expense> GetExpensesSorted();
    }
}
