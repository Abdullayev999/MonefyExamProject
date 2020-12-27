using System;
using System.Collections.Generic;

namespace Monefy
{
    [Serializable]
    public class Expenses
    {
        public decimal AllBalansExpenses()
        {
             decimal result=0;
             for (int i = 0; i < OtherCategories.Count; i++)
             {
                 for (int j = 0; j < OtherCategories[i].List.Count; j++)
                 {
                     result += OtherCategories[i].List[j];
                 }
             }

            result  += Communicati.Sum();
             result += Transport.Sum();
             result += Pets.Sum();
             result += House.Sum();
             result += Health.Sum();
             result += Gifts.Sum();
             result += Food.Sum();
             result += Entertainment.Sum();
             result += EatingOut.Sum();
             result += Car.Sum();
             result += Clothes.Sum();
             result += Toilety.Sum();
             result += Taxi.Sum();
            
             return result;
        }

        public Expenses()
        {
            Clothes = new Clothes();
            Communicati = new Communicati();
            Gifts = new Gifts();
            Pets = new Pets();
            Taxi = new Taxi();
            Sports = new Sports();
            Toilety = new Toilety();
            Transport = new Transport();
            Car = new Car();
            House = new House();
            EatingOut = new EatingOut();
            Entertainment = new Entertainment();
            Food = new Food();
            Health = new Health();
            OtherCategories=new List<Category>();
        }

        public List<Category> OtherCategories { get; set; }
        public Communicati Communicati { get; set; }
        public Clothes Clothes { get; set; }
        public Gifts Gifts { get; set; }
        public Pets Pets { get; set; }
        public Taxi Taxi { get; set; }
        public Sports Sports { get; set; }
        public Toilety Toilety { get; set; }
        public Transport Transport { get; set; }
        public Car Car { get; set; }
        public House House { get; set; }
        public EatingOut EatingOut { get; set; }
        public Entertainment Entertainment { get; set; }
        public Food Food { get; set; }
        public Health Health { get; set; }
    }
}