using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager
{
    internal class Transaction
    {
        public DateTime Date {  get; set; }
        public string Category {  get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateTime date, string category, string type, decimal amount)
        {
            Date = date;
            Category = category;
            Type = type; // "Income" or "Expense"
            Amount = amount;
        }

        public override string ToString() {
            return $"{Date.ToShortDateString()} - {Category} : {Amount:C} ({Type})";
        }
    }
}
