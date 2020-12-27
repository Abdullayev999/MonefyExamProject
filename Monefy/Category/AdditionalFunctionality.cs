using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Monefy
{
    [Serializable]
    public static class AdditionalFunctionality
    {
        public static void PrintDataMenu(int num)
        {
            switch (num)
            {

                case 0:
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ---------------- \n|    Print all   |\n|________________|\n"); Console.ResetColor();
                        Console.Write("|                |\n|     Select     |\n|________________|\n" +
                                      "|                |\n|     Delete     |\n|________________|\n");
                        Console.Write("|                |\n|     Create     |\n|________________|\n"); break;
                case 1:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|    Print all   |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|     Select     |\n|________________|\n"); Console.ResetColor();
                    Console.Write("|                |\n|     Delete     |\n|________________|\n");
                    Console.Write("|                |\n|     Create     |\n|________________|\n"); break;
                case 2:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|    Print all   |\n|________________|\n" +
                                  "|                |\n|     Select     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|     Delete     |\n|________________|\n"); Console.ResetColor();
                    Console.Write("|                |\n|     Create     |\n|________________|\n"); break;
                case 3:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|    Print all   |\n|________________|\n" +
                                  "|                |\n|     Select     |\n|________________|\n"); 
                    Console.Write("|                |\n|     Delete     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|     Create     |\n|________________|\n"); Console.ResetColor(); break;
            }
        }
        public static void PrintIncomeMenu(int num)
        {
            switch (num)
            {
                case 0:
                        Console.WriteLine(); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ---------------- \n|    Deposits    |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|     Savings    |\n|________________|\n" +
                                      "|                |\n|     Salary     |\n|________________|\n" +
                                      "|                |\n| Other category |\n|________________|\n"); break;
                case 1:
                    Console.WriteLine(); 
                        Console.Write(" ---------------- \n|    Deposits    |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                        Console.Write("|                |\n|     Savings    |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|     Salary     |\n|________________|\n" +
                                      "|                |\n| Other category |\n|________________|\n"); break;
                case 2:
                    Console.WriteLine();
                    Console.Write(" ---------------- \n|    Deposits    |\n|________________|\n" +
                                  "|                |\n|     Savings    |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|     Salary     |\n|________________|\n"); Console.ResetColor();
               Console.WriteLine ("|                |\n| Other category |\n|________________|\n"); break;
                case 3:
                    Console.WriteLine();
                    Console.Write(" ---------------- \n|    Deposits    |\n|________________|\n" +
                                  "|                |\n|     Savings    |\n|________________|\n");
                    Console.Write("|                |\n|     Salary     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                Console.WriteLine("|                |\n| Other category |\n|________________|\n"); Console.ResetColor(); break;
            }
        }

        public static void PrintOperationMenu(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine(); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ---------------- \n|      Edit      |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|     Remove     |\n|________________|\n" +
                                      "|                |\n|      Clear     |\n|________________|\n"); break;
                case 1:
                    Console.WriteLine();
                        Console.Write(" ---------------- \n|      Edit      |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|                |\n|     Remove     |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|      Clear     |\n|________________|\n"); break;
                case 2:
                    Console.WriteLine();
                    Console.Write(" ---------------- \n|      Edit      |\n|________________|\n" +
                                  "|                |\n|     Remove     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|      Clear     |\n|________________|\n"); Console.ResetColor(); break;
            }
        }

        public static void PrintCategoryMenu(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine(); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ---------------- \n|     Select     |\n|________________|\n"); Console.ResetColor();
                    Console.Write("|                |\n|     Create     |\n|________________|\n" +
                                      "|                |\n|     Print      |\n|________________|\n");
                        Console.Write("|                |\n|    Delete      |\n|________________|\n"); break;
                case 1:
                    Console.WriteLine();
                    Console.Write(" ---------------- \n|     Select     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|     Create     |\n|________________|\n"); Console.ResetColor();
                Console.Write("|                |\n|     Print      |\n|________________|\n");
                    Console.Write("|                |\n|    Delete      |\n|________________|\n"); break;
                case 2:
                    Console.WriteLine();
                    Console.Write(" ---------------- \n|     Select     |\n|________________|\n" +
                                  "|                |\n|     Create     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|     Print      |\n|________________|\n"); Console.ResetColor();
                    Console.Write("|                |\n|    Delete      |\n|________________|\n"); break;
                case 3:
                    Console.WriteLine();
                    Console.Write(" ---------------- \n|     Select     |\n|________________|\n" +
                                  "|                |\n|     Create     |\n|________________|\n");
                    Console.Write("|                |\n|     Print      |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|    Delete      |\n|________________|\n"); Console.ResetColor(); break;
            }
        }
        public static void PrintMainMenu(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" --------------------------- \n|           Data            |\n|___________________________|\n");  
                    Console.ResetColor();
                    Console.WriteLine("|                           |\n|          Expense          |\n|___________________________|\n" +
                                      "|                           |\n|          Income           |\n|___________________________|\n" +
                                      "|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                      "|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                      "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                      "|                           |\n|  Another data statistics  |\n|___________________________|\n"+
                                      "|                           |\n|         All Balances      |\n|___________________________|\n"+
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 1:
                      Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n");
                    Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|                           |\n|          Expense          |\n|___________________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                           |\n|          Income           |\n|___________________________|\n" +
                                      "|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                      "|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                      "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                      "|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                      "|                           |\n|         All Balances      |\n|___________________________|\n" +
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 2:
                      Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                      "|                           |\n|          Expense          |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|                           |\n|          Income           |\n|___________________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                      "|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                      "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                      "|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                      "|                           |\n|         All Balances      |\n|___________________________|\n" +
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 3:
                       Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                      "|                           |\n|          Expense          |\n|___________________________|\n" +
                                      "|                           |\n|          Income           |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                        Console.Write("|                           |\n|      Daily statistics     |\n|___________________________|\n");  Console.ResetColor();
                    Console.WriteLine("|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                      "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                      "|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                      "|                           |\n|         All Balances      |\n|___________________________|\n" +
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 4:
                      Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                      "|                           |\n|          Expense          |\n|___________________________|\n" +
                                      "|                           |\n|          Income           |\n|___________________________|\n"+
                                      "|                           |\n|      Daily statistics     |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|                           |\n|      Weekly statistics    |\n|___________________________|\n"); Console.ResetColor(); 
                    Console.WriteLine("|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                      "|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                      "|                           |\n|         All Balances      |\n|___________________________|\n" +
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 5:
                      Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                      "|                           |\n|          Expense          |\n|___________________________|\n" +
                                      "|                           |\n|          Income           |\n|___________________________|\n" +
                                      "|                           |\n|      Daily statistics     |\n|___________________________|\n"+
                                      "|                           |\n|      Weekly statistics    |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                        Console.Write("|                           |\n|     Yearly statistics     |\n|___________________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                      "|                           |\n|         All Balances      |\n|___________________________|\n" +
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 6: 
                      Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                      "|                           |\n|          Expense          |\n|___________________________|\n" +
                                      "|                           |\n|          Income           |\n|___________________________|\n" +
                                      "|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                      "|                           |\n|      Weekly statistics    |\n|___________________________|\n"+
                                      "|                           |\n|     Yearly statistics     |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|                           |\n|  Another data statistics  |\n|___________________________|\n"); Console.ResetColor();
                        Console.Write("|                           |\n|         All Balances      |\n|___________________________|\n" +
                                      "|                           |\n|         Daily print       |\n|___________________________|\n"+
                                      "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 7:
                    Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                  "|                           |\n|          Expense          |\n|___________________________|\n" +
                                  "|                           |\n|          Income           |\n|___________________________|\n" +
                                  "|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                  "|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                  "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                  "|                           |\n|  Another data statistics  |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                           |\n|         All Balances      |\n|___________________________|\n"); Console.ResetColor();
                    Console.Write("|                           |\n|         Daily print       |\n|___________________________|\n"+
                                  "|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 8:
                    Console.Write("\n --------------------------- \n|           Exit            |\n|___________________________|\n" +
                                  "|                           |\n|          Expense          |\n|___________________________|\n" +
                                  "|                           |\n|          Income           |\n|___________________________|\n" +
                                  "|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                  "|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                  "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                  "|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                  "|                           |\n|         All Balances      |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                           |\n|         Daily print       |\n|___________________________|\n"); Console.ResetColor();
                    Console.Write("|                           |\n|     Another data print    |\n|___________________________|\n"); break;
                case 9:
                    Console.Write("\n --------------------------- \n|           Data            |\n|___________________________|\n" +
                                  "|                           |\n|          Expense          |\n|___________________________|\n" +
                                  "|                           |\n|          Income           |\n|___________________________|\n" +
                                  "|                           |\n|      Daily statistics     |\n|___________________________|\n" +
                                  "|                           |\n|      Weekly statistics    |\n|___________________________|\n" +
                                  "|                           |\n|     Yearly statistics     |\n|___________________________|\n" +
                                  "|                           |\n|  Another data statistics  |\n|___________________________|\n" +
                                  "|                           |\n|         All Balances      |\n|___________________________|\n"); 
                    Console.Write("|                           |\n|         Daily print       |\n|___________________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                           |\n|     Another data print    |\n|___________________________|\n"); Console.ResetColor(); break;
            }
        }
        public static void PrintValutaMenu(int num)
        {
            switch (num)
            {
                
                case 0:
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ---------------- \n|       AZN      |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|       EUR      |\n|________________|\n" +
                                  "|                |\n|       RUB      |\n|________________|\n" +
                                  "|                |\n|       TRY      |\n|________________|\n"); break;
                case 1:
                    Console.WriteLine();
                    
                        Console.Write(" ---------------- \n|       AZN      |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|                |\n|       EUR      |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|       RUB      |\n|________________|\n" +
                                      "|                |\n|       TRY      |\n|________________|\n"); break;
                case 2:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       AZN      |\n|________________|\n|                |\n" +
                                  "|       EUR      |\n|________________|\n");Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|       RUB      |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|       TRY      |\n|________________|\n"); break;
                case 3:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       AZN      |\n|________________|\n" +
                                  "|                |\n|       EUR      |\n|________________|\n" +
                                  "|                |\n|       RUB      |\n|________________|\n");Console.BackgroundColor = ConsoleColor.Blue; 
                Console.WriteLine("|                |\n|       TRY      |\n|________________|\n"); Console.ResetColor(); break;


            }
        }
        public static void PrintExpensesMenu(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ---------------- \n|       Car      |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|     Clothes    |\n|________________|\n|                |\n|   Communicati  |\n|________________|\n" +
                                      "|                |\n|   Eating Out   |\n|________________|\n|                |\n|  Entertainment |\n|________________|\n" +
                                      "|                |\n|      Food      |\n|________________|\n|                |\n|      Gifts     |\n|________________|\n" +
                                      "|                |\n|     Health     |\n|________________|\n|                |\n|     House      |\n|________________|\n" +
                                      "|                |\n|      Pets      |\n|________________|\n|                |\n|     Sports     |\n|________________|\n" +
                                      "|                |\n|      Taxi      |\n|________________|\n|                |\n|     Toilety    |\n|________________|\n" +
                                      "|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 1:
                    Console.WriteLine();
                    
                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|     Clothes    |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n" +
                                  "|                |\n|     Toilety    |\n|________________|\n|                |\n|    Transport   |\n|________________|\n" +
                                  "|                |\n|Another category|\n|________________|\n"); break;
                case 2:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n" +
                                  "|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|   Communicati  |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|   Eating Out   |\n|________________|\n|                |\n|  Entertainment |\n|________________|\n" +
                                  "|                |\n|      Food      |\n|________________|\n|                |\n|      Gifts     |\n|________________|\n" +
                                  "|                |\n|     Health     |\n|________________|\n|                |\n|     House      |\n|________________|\n" +
                                  "|                |\n|      Pets      |\n|________________|\n|                |\n|     Sports     |\n|________________|\n" +
                                  "|                |\n|      Taxi      |\n|________________|\n|                |\n|     Toilety    |\n|________________|\n" +
                                  "|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 3:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|   Eating Out   |\n|________________|\n"); Console.ResetColor(); 
               Console.WriteLine( "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n" +
                                  "|                |\n|     Toilety    |\n|________________|\n|                |\n|    Transport   |\n|________________|\n" +
                                  "|                |\n|Another category|\n|________________|\n"); break;
                case 4:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n"); 
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|  Entertainment |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|      Food      |\n|________________|\n|                |\n|      Gifts     |\n|________________|\n" +
                                  "|                |\n|     Health     |\n|________________|\n|                |\n|     House      |\n|________________|\n" +
                                  "|                |\n|      Pets      |\n|________________|\n|                |\n|     Sports     |\n|________________|\n" +
                                  "|                |\n|      Taxi      |\n|________________|\n|                |\n|     Toilety    |\n|________________|\n" +
                                  "|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 5:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|      Food      |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n" +
                                  "|                |\n|     Toilety    |\n|________________|\n|                |\n|    Transport   |\n|________________|\n" +
                                  "|                |\n|Another category|\n|________________|\n"); break;
                case 6:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n");
                    Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|      Gifts     |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|     Health     |\n|________________|\n|                |\n|     House      |\n|________________|\n" +
                                  "|                |\n|      Pets      |\n|________________|\n|                |\n|     Sports     |\n|________________|\n" +
                                  "|                |\n|      Taxi      |\n|________________|\n|                |\n|     Toilety    |\n|________________|\n" +
                                  "|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 7:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|     Health     |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n" +
                                  "|                |\n|     Toilety    |\n|________________|\n|                |\n|    Transport   |\n|________________|\n" +
                                  "|                |\n|Another category|\n|________________|\n"); break;
                case 8:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n");
                    Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|     House      |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|      Pets      |\n|________________|\n|                |\n|     Sports     |\n|________________|\n" +
                                  "|                |\n|      Taxi      |\n|________________|\n|                |\n|     Toilety    |\n|________________|\n" +
                                  "|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 9:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n" +"|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|      Pets      |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n" +
                                  "|                |\n|     Toilety    |\n|________________|\n|                |\n|    Transport   |\n|________________|\n"+
                                  "|                |\n|Another category|\n|________________|\n"); break;
                case 10:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n");
                    Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|     Sports     |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|      Taxi      |\n|________________|\n|                |\n|     Toilety    |\n|________________|\n" +
                                  "|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 11:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n"+
                                  "|                |\n|     Sports     |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                    Console.Write("|                |\n|      Taxi      |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|     Toilety    |\n|________________|\n|                |\n|    Transport   |\n|________________|\n" +
                                  "|                |\n|Another category|\n|________________|\n"); break;
                case 12:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|     Toilety    |\n|________________|\n"); Console.ResetColor();
                Console.WriteLine("|                |\n|    Transport   |\n|________________|\n|                |\n|Another category|\n|________________|\n"); break;
                case 13:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n"+
                                  "|                |\n|     Toilety    |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("|                |\n|    Transport   |\n|________________|\n"); Console.ResetColor();
                    Console.WriteLine("|                |\n|Another category|\n|________________|\n"); break;
                case 14:
                    Console.WriteLine();

                    Console.Write(" ---------------- \n|       Car      |\n|________________|\n|                |\n|     Clothes    |\n|________________|\n" +
                                  "|                |\n|   Communicati  |\n|________________|\n|                |\n|   Eating Out   |\n|________________|\n" +
                                  "|                |\n|  Entertainment |\n|________________|\n|                |\n|      Food      |\n|________________|\n" +
                                  "|                |\n|      Gifts     |\n|________________|\n|                |\n|     Health     |\n|________________|\n" +
                                  "|                |\n|     House      |\n|________________|\n|                |\n|      Pets      |\n|________________|\n" +
                                  "|                |\n|     Sports     |\n|________________|\n|                |\n|      Taxi      |\n|________________|\n" +
                                  "|                |\n|     Toilety    |\n|________________|\n");
                    Console.Write("|                |\n|    Transport   |\n|________________|\n"); Console.BackgroundColor = ConsoleColor.Blue; 
                Console.WriteLine("|                |\n|Another category|\n|________________|\n"); Console.ResetColor(); break;
            }
        }
        public static decimal ExchangeOut(decimal money,int num,Rootobject valuta)
        {
            
            decimal result = 0;
            switch (num)
            {
                case 0:
                    result += valuta.rates.AZN * money;
                    break;
                case 1:
                    result += valuta.rates.EUR * money;
                    break;
                case 2:
                    result += valuta.rates.RUB * money;
                    break;
                case 3:
                    result += valuta.rates.TRY * money;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }
        public static decimal ExchangeIn(decimal money, int num, Rootobject valuta)
        {

            decimal result = 0;
            switch (num)
            {
                case 0:
                    result += money/valuta.rates.AZN ;
                    break;
                case 1:
                    result += money / valuta.rates.EUR;
                    break;
                case 2:
                    result += money / valuta.rates.RUB;
                    break;
                case 3:
                    result += money/valuta.rates.TRY;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }
        public static void PrintPercent(string category, int loadingSize)
        {
            Random rand = new Random();
            int number = rand.Next(9);

            if (number == 0) Console.ForegroundColor = ConsoleColor.Blue;
            else if (number == 1) Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (number == 2) Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (number == 3) Console.ForegroundColor = ConsoleColor.Red;
            else if (number == 4) Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (number == 5) Console.ForegroundColor = ConsoleColor.Magenta;
            else if (number == 7) Console.ForegroundColor = ConsoleColor.DarkBlue;
            else if (number == 8) Console.ForegroundColor = ConsoleColor.Green;

            StringBuilder stringBuilder = new StringBuilder();
            Console.Write($" | {category.ToString().PadRight(15)}   |  ");
            for (int i = 0, b = 0; i < loadingSize; i += 4)
                stringBuilder.Append((char)1421);
            Console.Write(stringBuilder.ToString().PadRight(25));
            Console.WriteLine($" {loadingSize.ToString().PadLeft(3)} % |");
            Console.ResetColor();

        }
        public static decimal AllBalanceIncome(SortedList<string, DayInfo> list)
        {
            decimal result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string index = list.Keys[i];
                result += list[index].DayIncome();
            }
            return result;
        }
        public static decimal AllBalanceExpense(SortedList<string, DayInfo> list)
        {
            decimal result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string index = list.Keys[i];
                result += list[index].DayExpenses();


            }
            return result;
        }
        public static void StatisticsDayPrint(DayInfo dayInfo)
        {
            decimal car, clothes, communicati, eatingOut, entertainment, food,
                  gifts, health, house , otherCategory=0, pets, sports, transport, taxi, toilety;

            int carPercent = 0,otherPercent=0, clothesPercent = 0, communicatiPercent = 0, eatingOutPercent = 0, entertainmentPercent = 0,
              foodPercent = 0, giftsPercent = 0, healthPercent = 0, housePercent = 0, petsPercent = 0, sportsPercent = 0,
              transportPercent = 0, taxiPercent = 0, toiletyPercent = 0;

            car = dayInfo.Expenses.Car.Sum(); clothes = dayInfo.Expenses.Clothes.Sum();
            gifts = dayInfo.Expenses.Gifts.Sum(); sports = dayInfo.Expenses.Sports.Sum();
            food = dayInfo.Expenses.Food.Sum(); toilety = dayInfo.Expenses.Toilety.Sum();
            health = dayInfo.Expenses.Health.Sum(); eatingOut = dayInfo.Expenses.EatingOut.Sum();
            house = dayInfo.Expenses.House.Sum(); transport = dayInfo.Expenses.Transport.Sum();
            taxi = dayInfo.Expenses.Taxi.Sum(); communicati = dayInfo.Expenses.Communicati.Sum();
            pets = dayInfo.Expenses.Pets.Sum(); entertainment = dayInfo.Expenses.Entertainment.Sum();

            for (int i = 0; i < dayInfo.Expenses.OtherCategories.Count; i++)
            {
                for (int j = 0; j < dayInfo.Expenses.OtherCategories[i].List.Count; j++)
                {
                    otherCategory += dayInfo.Expenses.OtherCategories[i].List[j];
                }
            }

            decimal sum = car + communicati + taxi + toilety + transport + pets + sports
                + food + clothes + eatingOut + entertainment + gifts + house + health+otherCategory;
            int result = Convert.ToInt32(sum);
            if (car > 0) carPercent = 100 / (result / Convert.ToInt32(car)); if (entertainment > 0) entertainmentPercent = 100 / (result / Convert.ToInt32(entertainment));
            if (pets > 0) petsPercent = 100 / (result / Convert.ToInt32(pets)); if (eatingOut > 0) eatingOutPercent = 100 / (result / Convert.ToInt32(eatingOut));
            if (gifts > 0) giftsPercent = 100 / (result / Convert.ToInt32(gifts)); if (clothes > 0) clothesPercent = 100 / (result / Convert.ToInt32(clothes));
            if (health > 0) healthPercent = 100 / (result / Convert.ToInt32(health)); if (sports > 0) sportsPercent = 100 / (result / Convert.ToInt32(sports));
            if (house > 0) housePercent = 100 / (result / Convert.ToInt32(house)); if (toilety > 0) toiletyPercent = 100 / (result / Convert.ToInt32(toilety));
            if (food > 0) foodPercent = 100 / (result / Convert.ToInt32(food)); if (transport > 0) transportPercent = 100 / (result / Convert.ToInt32(transport));
            if (taxi > 0) taxiPercent = 100 / (result / Convert.ToInt32(taxi)); if (communicati > 0) communicatiPercent = 100 / (result / Convert.ToInt32(communicati));
            if (otherCategory > 0) otherPercent = 100 / (result / Convert.ToInt32(otherCategory));

            string dash = "------------------------------------------------------";
            Console.WriteLine("  " + dash); PrintPercent("Car", carPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Transport", transportPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Pets", petsPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Clothes", clothesPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Gifts", giftsPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Health", healthPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Taxi", taxiPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Eating Out", eatingOutPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("House", housePercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Toilety", toiletyPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Food", foodPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Communicati", communicatiPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Sports", sportsPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Entertainment", entertainmentPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Other categores", otherPercent);
            Console.WriteLine("  " + dash);
        }
        public static void PrintExpensesIncomeAnotherData(SortedList<string, DayInfo> list, string withData,string toData)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int KeyTime = Int32.Parse(list.Keys[i].Replace(".", ""));
                int withTime = Int32.Parse(withData.Replace(".", ""));
                int toTime = Int32.Parse(toData.Replace(".", ""));
                if (withTime <= KeyTime && KeyTime <= toTime)
                {
                    string index = list.Keys[i];

                    PrintListMoney(list[index].Income.Salary);
                    PrintListMoney(list[index].Income.Savings);
                    PrintListMoney(list[index].Income.Deposits);

                    PrintListMoney(list[index].Expenses.Clothes);
                    PrintListMoney(list[index].Expenses.Car);
                    PrintListMoney(list[index].Expenses.EatingOut);
                    PrintListMoney(list[index].Expenses.Pets);
                    PrintListMoney(list[index].Expenses.House);
                    PrintListMoney(list[index].Expenses.Entertainment);
                    PrintListMoney(list[index].Expenses.Communicati);
                    PrintListMoney(list[index].Expenses.Food);
                    PrintListMoney(list[index].Expenses.Gifts);
                    PrintListMoney(list[index].Expenses.Sports);
                    PrintListMoney(list[index].Expenses.Transport);
                    PrintListMoney(list[index].Expenses.Toilety);
                    PrintListMoney(list[index].Expenses.Health);
                    PrintListMoney(list[index].Expenses.Taxi);

                    for (int u = 0; u < list[index].Expenses.OtherCategories.Count; u++)
                    {
                        for (int j = 0; j < list[index].Expenses.OtherCategories[u].List.Count; j++)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("                       \n" +
                                              $"     {list[index].Expenses.OtherCategories[u].Name.ToString().PadRight(15)}     \n" +
                                              "                       ");
                            Console.ResetColor();
                            Console.WriteLine(list[index].Expenses.OtherCategories[u].ToString());
                        }
                    }
                }
            }
        }
        public static void PrintExpensesIncomeDaily(DayInfo dayInfo)
        {
                    PrintListMoney(dayInfo.Income.Salary);
                    PrintListMoney(dayInfo.Income.Savings);
                    PrintListMoney(dayInfo.Income.Deposits);
                    PrintListMoney(dayInfo.Expenses.Clothes);
                    PrintListMoney(dayInfo.Expenses.Car);
                    PrintListMoney(dayInfo.Expenses.EatingOut);
                    PrintListMoney(dayInfo.Expenses.Pets);
                    PrintListMoney(dayInfo.Expenses.House);
                    PrintListMoney(dayInfo.Expenses.Entertainment);
                    PrintListMoney(dayInfo.Expenses.Communicati);
                    PrintListMoney(dayInfo.Expenses.Food);
                    PrintListMoney(dayInfo.Expenses.Gifts);
                    PrintListMoney(dayInfo.Expenses.Sports);
                    PrintListMoney(dayInfo.Expenses.Transport);
                    PrintListMoney(dayInfo.Expenses.Toilety);
                    PrintListMoney(dayInfo.Expenses.Health);
                    PrintListMoney(dayInfo.Expenses.Taxi);

                     for (int i = 0; i < dayInfo.Expenses.OtherCategories.Count; i++)
                     {
                         for (int j = 0; j < dayInfo.Expenses.OtherCategories[i].List.Count; j++)
                         {
                             Console.BackgroundColor = ConsoleColor.Red;
                             Console.WriteLine("                       \n" +
                                               $"     {dayInfo.Expenses.OtherCategories[i].Name.ToString().PadRight(15)}     \n" +
                                               "                       ");
                             Console.ResetColor();
                             Console.WriteLine(dayInfo.Expenses.OtherCategories[i].ToString());
                         }
                     }
            
        }
        public static void PrintListMoney(Category cat)
        {
            if (cat.Size() > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("                       \n" +
                                  $"     {cat.Name.ToString().PadRight(15)}     \n" +
                                  "                       ");
                Console.ResetColor();
                Console.WriteLine(cat.ToString());

            }
        }
        public static void StatisticsWithDataToDataPrint(SortedList<string, DayInfo> list, string withData, string toData)
        {
            decimal car = 0, clothes = 0, communicati = 0, eatingOut = 0, entertainment = 0, food = 0, gifts = 0, health = 0,
                house = 0, pets = 0, sports = 0, transport = 0, taxi = 0, toilety = 0, anotherCategory = 0;

            int carPercent = 0, clothesPercent = 0, communicatiPercent = 0, eatingOutPercent = 0,
                entertainmentPercent = 0, foodPercent = 0, giftsPercent = 0, healthPercent = 0, housePercent = 0,
                petsPercent = 0, sportsPercent = 0, transportPercent = 0, taxiPercent = 0, anotherPercent  = 0, toiletyPercent = 0;

            for (int i = 0; i < list.Count; i++)
            {
                int KeyTime = Int32.Parse(list.Keys[i].Replace(".", ""));
                int withTime = Int32.Parse(withData.Replace(".", ""));
                int toTime = Int32.Parse(toData.Replace(".", ""));
                if (withTime <= KeyTime && KeyTime <= toTime)
                {
                    string index = list.Keys[i];
                    
                    car += list[index].Expenses.Car.Sum();
                    taxi += list[index].Expenses.Taxi.Sum();
                    food += list[index].Expenses.Food.Sum();
                    gifts += list[index].Expenses.Gifts.Sum();
                    house += list[index].Expenses.House.Sum();
                    sports += list[index].Expenses.Sports.Sum();
                    health += list[index].Expenses.Health.Sum();
                    clothes += list[index].Expenses.Clothes.Sum();
                    toilety += list[index].Expenses.Toilety.Sum();
                    eatingOut += list[index].Expenses.EatingOut.Sum();
                    transport += list[index].Expenses.Transport.Sum();
                    communicati += list[index].Expenses.Communicati.Sum();

                    for (int j = 0; j < list[index].Expenses.OtherCategories.Count; j++)
                    {
                        for (int k = 0; k < list[index].Expenses.OtherCategories[j].List.Count; k++)
                        {
                            anotherCategory += list[index].Expenses.OtherCategories[j].List[k];
                        }
                    }
                   
                }
            }

            decimal sum = car + communicati + taxi + toilety + transport + pets + sports
                + food + clothes + eatingOut + entertainment + gifts + house + health+anotherCategory;

            int result = Convert.ToInt32(sum);

            if (car > 0) carPercent = 100 / (result / Convert.ToInt32(car));
            if (entertainment > 0) entertainmentPercent = 100 / (result / Convert.ToInt32(entertainment));
            if (pets > 0) petsPercent = 100 / (result / Convert.ToInt32(pets));
            if (eatingOut > 0) eatingOutPercent = 100 / (result / Convert.ToInt32(eatingOut));
            if (gifts > 0) giftsPercent = 100 / (result / Convert.ToInt32(gifts));
            if (clothes > 0) clothesPercent = 100 / (result / Convert.ToInt32(clothes));
            if (health > 0) healthPercent = 100 / (result / Convert.ToInt32(health));
            if (sports > 0) sportsPercent = 100 / (result / Convert.ToInt32(sports));
            if (house > 0) housePercent = 100 / (result / Convert.ToInt32(house));
            if (toilety > 0) toiletyPercent = 100 / (result / Convert.ToInt32(toilety));
            if (food > 0) foodPercent = 100 / (result / Convert.ToInt32(food));
            if (transport > 0) transportPercent = 100 / (result / Convert.ToInt32(transport));
            if (taxi > 0) taxiPercent = 100 / (result / Convert.ToInt32(taxi));
            if (communicati > 0) communicatiPercent = 100 / (result / Convert.ToInt32(communicati));
            if (anotherCategory > 0) anotherPercent = 100 / (result / Convert.ToInt32(anotherCategory));

            string dash = "------------------------------------------------------";
            Console.WriteLine("  " + dash); PrintPercent("Car", carPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Transport", transportPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Pets", petsPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Clothes", clothesPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Gifts", giftsPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Health", healthPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Taxi", taxiPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Eating Out", eatingOutPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("House", housePercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Toilety", toiletyPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Food", foodPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Communicati", communicatiPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Sports", sportsPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("Entertainment", entertainmentPercent);
            Console.WriteLine(" |" + dash + '|'); PrintPercent("other categories", anotherPercent);
            Console.WriteLine("  " + dash);
        }

        public static Tuple<decimal, decimal> StatisticsWeeklyExpenseIncome(SortedList<string, DayInfo> list, string withData,string toData)
        {
            decimal expense = 0;
            decimal income = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int KeyTime = Int32.Parse(list.Keys[i].Replace(".", ""));
                int withTime = Int32.Parse(withData.Replace(".", ""));
                int toTime = Int32.Parse(toData.Replace(".", ""));
                if (withTime <= KeyTime && KeyTime <= toTime)
                {
                    string index = list.Keys[i];

                    expense += list[index].DayExpenses();
                    income += list[index].DayIncome();
                }
            }
            return new Tuple<decimal, decimal>(expense,income);
        }
    }
}