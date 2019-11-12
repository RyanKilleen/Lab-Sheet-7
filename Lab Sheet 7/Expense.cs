using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Sheet_7
{
    public class Expense
    {
        //public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }

        private Decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                TotalExpenses += _amount;
                _amount = value;
            }
        }

        //Constructors - will return later
        public Expense() : this(0, DateTime.Now, "Unknown")
        {

        }

        public Expense(decimal amount, DateTime date, string category)
        {
            Amount = amount;
            ExpenseDate = date;
            Category = category;


        }

        public static decimal TotalExpenses;
        //Methods
        public override string ToString()
        {
            return $"{Category} {Amount:C} on {ExpenseDate.ToShortDateString()}";
        }
    }
}
