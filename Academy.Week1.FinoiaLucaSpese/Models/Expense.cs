using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Core.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool Aproved { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} Data: {Date} Descrizione: {Description} Importo: {Amount} Approvata: " + (Aproved ? "sì" : "no") + $" Id Categoria: {CategoryId} Id Utente: {UserId}";
        }
    }
}
