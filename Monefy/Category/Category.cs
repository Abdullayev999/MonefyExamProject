using System;
using System.Collections.Generic;
using System.Text;

namespace Monefy
{
    [Serializable]
    public class Category
    {
        // readonly public string Name;
        public string Name { get; set; }

         public Category(string name)
         {
             Name = name;
             List=new List<decimal>();
         }

         public bool RemoveAt(int index)
         {
             if (List.Count > index)
             {
                 List.RemoveAt(index);
                 return true;
             }

             return false;
         }
         public void Clear()
         {
             List.Clear();
         }

         public bool Edit(int index,decimal money)
         {
             if (index<List.Count)
             {
                 List[index] = money;
                 return true;
             }
             return false;
         }
        public List<decimal> List { get; set; }
        public void Сontribution(decimal spent)
        {
            List.Add(Math.Round(spent, 2));
        }
        public int Size()
        {
            return List.Count;
        }
        public decimal Sum()
        {
            decimal result = 0;
            foreach (var item in List) result += item;
            return result;
        }
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            int tmpSize = List.Count;
            for (int i = 0; i < tmpSize; i++)
                tmp.Append($"{i}) " + List[i] + " $ \n");

            return $"{tmp.ToString()}";
        }
    }
}