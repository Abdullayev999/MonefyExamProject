using System;
using System.Collections.Generic;
using System.Text;

namespace Monefy
{
    [Serializable]
    public class Income
    {
        public Income()
        {
            Deposits = new Deposits();
            Salary = new Salary();
            Savings = new Savings();
            OtherCategories = new List<Category>();
        }
        public List<Category> OtherCategories { get; set; }
        public Deposits Deposits { get; set; }
        public Salary Salary { get; set; }
        public Savings Savings { get; set; }

        public decimal AllBalansIncome()
        {
            decimal result=0;

            for (int i = 0; i < OtherCategories.Count; i++)
            {
                for (int j = 0; j < OtherCategories[i].List.Count; j++)
                {
                    result += OtherCategories[i].List[j];
                }
            }

            result += Deposits.Sum();
            result += Salary.Sum();
            result += Savings.Sum();

            return result;
        }
    }
}