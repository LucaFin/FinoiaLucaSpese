using Academy.Week1.FinoiaLucaSpese.Core.BusinessLayers;
using Academy.Week1.FinoiaLucaSpese.Core.Interfaces;
using Academy.Week1.FinoiaLucaSpese.Core.Models;
using Academy.Week1.FinoiaLucaSpese.Mock.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Client
{
    public class Menu
    {
        private static readonly IBusinessLayer mainBL = new BusinessLayer(new MockCategoriesRepository(), new MockExpensesRepository(), new MockUsersRepository());
        internal static void Start()
        {
            Console.WriteLine("Benvenuto!");

            char choice;

            do
            {
                Console.WriteLine("[1] Inserire nuove spese" +
                    "\n[2] Approvare una spesa" +
                    "\n[3] Visualizzare l'elenco delle spese approvate nel mese precedente" +
                    "\n[4] Visualizzare l'elenco delle spese di un utente" +
                    "\n[5] Visualizzare il totale delle spese filtrate per categoria nel mese precedente" +
                    "\n[6] Visualizzare le spese registrate ordinate dalla più recente alla meno recente" +
                    "\n[q] Chiudere l'applicazione");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        InsertExpense();
                        break;
                    case '2':
                        ApproveExpense();
                        break;
                    case '3':
                        GetExpensesLastMonth();
                        break;
                    case '4':
                        GetUserExpenses();
                        break;
                    case '5':
                        TotalExpensesLastMonth();
                        break;
                    case '6':
                        SortedExpenses();
                        break;
                    case 'q':
                        Console.WriteLine("\nCiao!");
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile. Riprova!");
                        break;
                }

            } while (!(choice == 'q'));
        }

        private static void SortedExpenses()
        {
            foreach (Expense expense in mainBL.GetExpensesSorted())
            {
                Console.WriteLine(expense.ToString());
            }
        }

        private static void TotalExpensesLastMonth()
        {
            decimal sum = 0;
            Console.WriteLine("Inserire ID categoria da controllare");
            int categoryId;
            while (!int.TryParse(Console.ReadLine(), out categoryId) || !mainBL.CheckCategoryId(categoryId))
            {
                Console.WriteLine("id digitato inesistente o non un numero");
            }
            foreach (Expense expense in mainBL.GetExpensesLastMonth().Where(e=>e.CategoryId==categoryId))
            {
                sum += expense.Amount;
            }
            Console.WriteLine($"il totale speso nella categoria {categoryId} è {sum}");
        }

        private static void GetUserExpenses()
        {
            int userId;
            Console.WriteLine("inserire Id utente");
            while (!int.TryParse(Console.ReadLine(), out userId) || !mainBL.CheckUserId(userId))
            {
                Console.WriteLine("id digitato inesistente o non un numero");
            }
            foreach (Expense expense in mainBL.GetUserExpense(userId))
            {
                Console.WriteLine(expense.ToString());
            }
        }

        private static void GetExpensesLastMonth()
        {
            foreach(Expense expense in mainBL.GetExpensesLastMonth())
            {
                if(expense.Aproved)
                Console.WriteLine(expense.ToString());
            }
        }

        private static void InsertExpense()
        {

            DateTime date;

            Console.WriteLine("Inserire la data in cui è stata effettuata la spesa");
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Inserisci un formato corretto di data!");
            }

            string description;
            Console.WriteLine("Inserire descrizione spesa");
            description = Console.ReadLine();
            decimal price;
            Console.WriteLine("Inserire il prezzo della spesa");
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("il vaolre inserito non è valido");
            }
            Console.WriteLine("inserire Id di una delle seguenti categorie");
            int categoryId;
            foreach (Category category in mainBL.GetCategory())
            {
                Console.WriteLine(category.ToString());
            }
            while (!int.TryParse(Console.ReadLine(),out categoryId) || !mainBL.CheckCategoryId(categoryId))
            {
                Console.WriteLine("id digitato inesistente o non un numero");
            }
            int userId;
            Console.WriteLine("inserire Id di uno dei seguenti utenti");
            foreach(User user in mainBL.GetUser())
            {
                Console.WriteLine(user.ToString());
            }
            while (!int.TryParse(Console.ReadLine(), out userId) || !mainBL.CheckUserId(userId))
            {
                Console.WriteLine("id digitato inesistente o non un numero");
            }
            int nextId = mainBL.GetNextExpenseId();
            Expense expense = new Expense()
            {
                Id = nextId,
                Date = date,
                Description = description,
                Amount = price,
                Aproved = false,
                CategoryId = categoryId,
                UserId = userId
            };
            if (mainBL.Add(expense))
            {
                Console.WriteLine($"spesa con id {nextId} aggiunta con successo");
            }
            else
            {
                Console.WriteLine("errore: spesa non aggiunta");
            }

        }

        private static void ApproveExpense()
        {
            int id;
            do
            {
                Console.WriteLine("Inserire id della spesa da approvare");
            } while (!int.TryParse(Console.ReadLine(), out id));
            if (mainBL.ApproveExpense(id))
            {
                Console.WriteLine($"spesa {id} approvata");
            }
            else
            {
                Console.WriteLine($"spesa {id} non approvata");
            }
        }
    }
}
