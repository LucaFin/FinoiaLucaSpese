using Academy.Week1.FinoiaLucaSpese.Core.Interfaces;
using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Core.BusinessLayers
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IUsersRepository _usersRepository;

        public BusinessLayer(ICategoriesRepository categoriesRepository, IExpensesRepository expensesRepository, IUsersRepository usersRepository)
        {
            _categoriesRepository = categoriesRepository;
            _expensesRepository = expensesRepository;
            _usersRepository = usersRepository;
        }

        public bool Add(Expense expense)
        {
            return _expensesRepository.Add(expense);
        }

        public bool ApproveExpense(int id)
        {
            return _expensesRepository.ApproveExpense(id);
        }

        public bool CheckCategoryId(int categoryId)
        {
            return _categoriesRepository.CheckCategoryId(categoryId);
        }

        public bool CheckUserId(int userId)
        {
            return _usersRepository.CheckUserId(userId);
        }

        public IEnumerable<Expense> GetExpensesLastMonth()
        {
            int LastMont = DateTime.Today.Month == 1 ? 12 : DateTime.Today.Month - 1;
            int LastYear = LastMont == 12 ? DateTime.Today.Year - 1 : DateTime.Today.Year;
            return _expensesRepository.FetchAll(e => e.Date.Month == LastMont && e.Date.Year== LastYear);
        }


        public IEnumerable<Expense> GetUserExpense(int userId)
        {
            return _expensesRepository.FetchAll(e=> e.UserId == userId);
        }

        public int GetNextExpenseId()
        {
            return _expensesRepository.GetMaxId()+1;
        }

        public IEnumerable<Expense> GetExpensesSorted()
        {
            return _expensesRepository.GetExpensesSorted();
        }
    }
}
