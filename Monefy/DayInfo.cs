using System;
using System.Collections.Generic;

namespace Monefy
{
    [Serializable]
    public class DayInfo
    {
        public DayInfo()
        {
            Expenses = new Expenses();
            Income = new Income();
        }
        public Expenses Expenses { get; set; }
        public Income Income { get; set; }
        public decimal DayIncome()
        {
            decimal result = Income.AllBalansIncome();

            return result;
        }
        public decimal DayExpenses()
        {
            decimal result =Expenses.AllBalansExpenses();

            return result;
        }
    }
}