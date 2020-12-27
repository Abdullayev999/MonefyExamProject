using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Monefy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Regex regex = new Regex("^[0-9]{2}.[0-9]{2}.[0-9]{4}$");
            string url = "https://api.exchangeratesapi.io/latest?base=USD";
            WebClient web = new WebClient();
            string str = web.DownloadString(url);
            var valuta = JsonSerializer.Deserialize<Rootobject>(str);
            SortedList<string, DayInfo> sList = new SortedList<string, DayInfo>();


            DateTime Tdate;
            int select, frequency = 1000,duration = 150;
            bool check , dataActive = true , sound = true , time = true;
            decimal edit, money = 0, money2, sum;
            string withTime , toTime , moneyValuta = "USD",data=null, dataTmp;


            ConsoleKey keyForMainMenu , keyForExpenseMenu , keyForCategoryIncomeMenu, keyForDataMenu,
                       keyForIncomeMenu, keyForCategoryExpenseMenu, keyForValutaMenu;

            int actionForMainMenu = 0 , actionForExpenseMenu , actionForCategoryIncomeMenu , actionForDataeMenu
                , actionForIncomeMenu , actionForCategoryExpenseMenu , actionForValutaMenu;
           

            try
            {
                using (FileStream fs = new FileStream(@"monefy.bin", FileMode.Open))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    sList= binary.Deserialize(fs) as SortedList<string, DayInfo>;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            do
            {
                Console.Clear();
                if (dataActive)
                {
                    dataTmp = DateTime.Now.ToShortDateString();
                    if (sList.Count>0)
                    {
                        check = true;
                        for (int i = 0; i < sList.Count; i++)
                            if (string.Equals(sList.Keys[i], dataTmp)) check = false;

                        if (check) 
                        {
                            data = dataTmp;
                            sList[data] = new DayInfo();
                            Console.WriteLine($"     New day - {data}");
                        }
                        else
                        {
                            data = dataTmp;
                        }
                    }
                    else
                    {
                        data = dataTmp;
                        sList[data] = new DayInfo();
                        Console.WriteLine($"   New day - {data}");
                    }
                }
                
                Console.Write($"  Data  active : {dataActive.ToString().PadLeft(5)} ( TAB / on-off )\n");
                Console.Write($"  Time  active : {time.ToString().PadLeft(5)} ( F1 / on-off )\n");
                Console.WriteLine($"  Sound active : {sound.ToString().PadLeft(5)} ( F2 / on-off )\n");


                Console.WriteLine("\t " +data);
                if (time) { Console.Write("\t  "+DateTime.Now.ToLongTimeString().ToString().PadRight(10)); }
                AdditionalFunctionality.PrintMainMenu(actionForMainMenu);
                keyForMainMenu = Console.ReadKey().Key;
                if (sound)
                {
                    Console.Beep(frequency, duration);
                }
                if (keyForMainMenu == ConsoleKey.UpArrow)
                {
                    actionForMainMenu--;
                    if (actionForMainMenu == -1) actionForMainMenu = 9;
                }
                else if (keyForMainMenu == ConsoleKey.DownArrow)
                {
                    actionForMainMenu++;
                    if (actionForMainMenu == 10) actionForMainMenu = 0;
                }else if (keyForMainMenu == ConsoleKey.Tab)
                {
                    dataActive = !dataActive;
                }
                else if (keyForMainMenu == ConsoleKey.F1)
                {
                    time = !time;
                }
                else if (keyForMainMenu == ConsoleKey.F2)
                {
                    sound = !sound;
                }
                else if (keyForMainMenu == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ---------------------------- \n" +
                                  "|    You left the program    |\n" +
                                  "|____________________________|\n"); Console.ResetColor();
                    break;
                }
                else if (keyForMainMenu == ConsoleKey.Enter)
                {
                    if (actionForMainMenu == 0)
                    {
                        Console.Clear();
                        actionForDataeMenu = 0;
                        do
                        {
                            Console.Clear();
                            AdditionalFunctionality.PrintDataMenu(actionForDataeMenu);
                            keyForDataMenu = Console.ReadKey().Key;
                            if (sound)
                            {
                                Console.Beep(frequency, duration);
                            }
                            if (keyForDataMenu==ConsoleKey.UpArrow)
                            {
                                actionForDataeMenu--;
                                if (actionForDataeMenu == -1) actionForDataeMenu = 3;
                            }else if (keyForDataMenu == ConsoleKey.DownArrow)
                            {
                                actionForDataeMenu++;
                                if (actionForDataeMenu == 4) actionForDataeMenu = 0;
                            }else if (keyForDataMenu == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else if (keyForDataMenu == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                if (actionForDataeMenu==0)
                                {
                                    for (int i = 0; i < sList.Count; i++)
                                    {
                                        Console.WriteLine($"{i} - {sList.Keys[i]}");
                                    }
                                    Console.ReadKey();
                                }else if (actionForDataeMenu == 1)
                                {
                                    for (int i = 0; i < sList.Count; i++)
                                    {
                                        Console.WriteLine($"{i} - {sList.Keys[i]}");
                                    }

                                    Console.Write("\nChoose a date to go :  ");
                                    int num = Convert.ToInt32(Console.ReadLine());

                                    if (sList.Count>num)
                                    {
                                        data = sList.Keys[num];
                                        Console.WriteLine("Selected data done\n");
                                        dataActive = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect data\n");
                                    }
                                    Console.ReadKey();

                                }
                                else if (actionForDataeMenu == 2)
                                {
                                    for (int i = 0; i < sList.Count; i++)
                                    {
                                        Console.WriteLine($"{i} - {sList.Keys[i]}");
                                    }
                                    Console.Write("\nChoose a date for delete :  ");
                                    int num = Convert.ToInt32(Console.ReadLine());

                                    if (sList.Count > num)
                                    {
                                        sList.RemoveAt(num);
                                        Console.WriteLine("Selected data deleted\n");
                                        data = null;
                                        dataActive = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect data\n");
                                    }
                                    Console.ReadKey();
                                }else if (actionForDataeMenu == 3)
                                {
                                    Console.WriteLine(" Please enter to data   ? ( format 00.00.0000 )");
                                    dataTmp = Console.ReadLine();
                                    Match matchToTime = regex.Match(dataTmp);

                                    if (matchToTime.Success)
                                    {
                                        check = true;
                                        for (int i = 0; i < sList.Count; i++)
                                        {
                                            if (string.Equals(dataTmp, sList.Keys[i]))
                                            {
                                                check = false;
                                                break;
                                            }
                                        }

                                        if (check)
                                        {
                                            Console.WriteLine("You create new day\n");
                                            data = dataTmp;
                                            sList[data] =new DayInfo();
                                            dataActive = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("This date exists\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect data!");
                                    }
                                    Console.ReadKey();
                                }
                            }
                            
                        } while (true);

                        Console.Clear();
                    }
                    else if (actionForMainMenu == 1)
                    {
                        Console.Clear();
                        actionForExpenseMenu = 0;
                        do
                        {
                            AdditionalFunctionality.PrintExpensesMenu(actionForExpenseMenu);
                            keyForExpenseMenu = Console.ReadKey().Key;
                            if (sound)
                            {
                                Console.Beep(frequency, duration);
                            }
                            if (keyForExpenseMenu == ConsoleKey.UpArrow)
                            {
                                actionForExpenseMenu--;
                                if (actionForExpenseMenu == -1) actionForExpenseMenu = 14;
                            }
                            else if (keyForExpenseMenu == ConsoleKey.DownArrow)
                            {
                                actionForExpenseMenu++;
                                if (actionForExpenseMenu == 15) actionForExpenseMenu = 0;
                            }else if (keyForExpenseMenu== ConsoleKey.Escape)
                            {
                                break;
                            }
                            else if (keyForExpenseMenu == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                if (actionForExpenseMenu != 14)
                                {
                                    Console.WriteLine("Press SPACE for select valuta or any button to continue");
                                    keyForValutaMenu = Console.ReadKey().Key;
                                    if (keyForValutaMenu == ConsoleKey.Spacebar)
                                    {
                                        actionForValutaMenu = 0;
                                        do
                                        {
                                            Console.Clear();
                                            AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                            keyForValutaMenu = Console.ReadKey().Key;
                                            if (sound)
                                            {
                                                Console.Beep(frequency, duration);
                                            }
                                            if (keyForValutaMenu == ConsoleKey.UpArrow)
                                            {
                                                actionForValutaMenu--;
                                                if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                            }
                                            else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                            {
                                                actionForValutaMenu++;
                                                if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                            }else if (keyForValutaMenu == ConsoleKey.Escape)
                                            {
                                                break;
                                            }
                                            else if (keyForValutaMenu == ConsoleKey.Enter)
                                            {
                                                Console.Clear();
                                                switch (actionForValutaMenu)
                                                {
                                                    case 0: moneyValuta = "AZN"; break;
                                                    case 1: moneyValuta = "EUR"; break;
                                                    case 2: moneyValuta = "RUB"; break;
                                                    case 3: moneyValuta = "TRY"; break;
                                                }

                                                break;
                                            }
                                        } while (true);
                                        Console.WriteLine($"How much money did you spend ? {moneyValuta}\n");
                                        money = decimal.Parse(Console.ReadLine());
                                        money = AdditionalFunctionality.ExchangeIn(money, actionForValutaMenu, valuta);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"How much money did you spend ? {moneyValuta}\n");
                                        money = decimal.Parse(Console.ReadLine());
                                    }

                                    switch (actionForExpenseMenu)
                                    {
                                        case 0:
                                            sList[data].Expenses.Car.Сontribution(money);
                                            break;
                                        case 1:
                                            sList[data].Expenses.Clothes.Сontribution(money);
                                            break;
                                        case 2:
                                            sList[data].Expenses.Communicati.Сontribution(money);
                                            break;
                                        case 3:
                                            sList[data].Expenses.EatingOut.Сontribution(money);
                                            break;
                                        case 4:
                                            sList[data].Expenses.Entertainment.Сontribution(money);
                                            break;
                                        case 5:
                                            sList[data].Expenses.Food.Сontribution(money);
                                            break;
                                        case 6:
                                            sList[data].Expenses.Gifts.Сontribution(money);
                                            break;
                                        case 7:
                                            sList[data].Expenses.Health.Сontribution(money);
                                            break;
                                        case 8:
                                            sList[data].Expenses.House.Сontribution(money);
                                            break;
                                        case 9:
                                            sList[data].Expenses.Pets.Сontribution(money);
                                            break;
                                        case 10:
                                            sList[data].Expenses.Sports.Сontribution(money);
                                            break;
                                        case 11:
                                            sList[data].Expenses.Taxi.Сontribution(money);
                                            break;
                                        case 12:
                                            sList[data].Expenses.Toilety.Сontribution(money);
                                            break;
                                        case 13:
                                            sList[data].Expenses.Transport.Сontribution(money);
                                            break;
                                    }

                                    Console.WriteLine("Action completed");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    actionForCategoryExpenseMenu = 0;
                                    do
                                    {
                                        Console.Clear();
                                        AdditionalFunctionality.PrintCategoryMenu(actionForCategoryExpenseMenu);
                                        keyForCategoryExpenseMenu = Console.ReadKey().Key;
                                        if (sound)
                                        {
                                            Console.Beep(frequency, duration);
                                        }
                                        if (keyForCategoryExpenseMenu==ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                        if (keyForCategoryExpenseMenu == ConsoleKey.UpArrow)
                                        {
                                            actionForCategoryExpenseMenu--;
                                            if (actionForCategoryExpenseMenu == -1) actionForCategoryExpenseMenu = 3;
                                        }
                                        else if (keyForCategoryExpenseMenu == ConsoleKey.DownArrow)
                                        {
                                            actionForCategoryExpenseMenu++;
                                            if (actionForCategoryExpenseMenu == 4) actionForCategoryExpenseMenu = 0;
                                        }
                                        else if(keyForCategoryExpenseMenu == ConsoleKey.Enter)
                                        {
                                            
                                            Console.Clear();

                                            switch (actionForCategoryExpenseMenu)
                                            {
                                                case 0:
                                                    if (sList[data].Expenses.OtherCategories.Count > 0)
                                                    {
                                                        for (int i = 0; i < sList[data].Expenses.OtherCategories.Count; i++)
                                                        {
                                                            Console.WriteLine($"{i}. {sList[data].Expenses.OtherCategories[i].Name}");
                                                        }

                                                        Console.Write("\nSelecet category : ");
                                                        select = Convert.ToInt32(Console.ReadLine());
                                                        if (sList[data].Expenses.OtherCategories.Count > select)
                                                        {
                                                            Console.WriteLine("How much money did you spend ? $");
                                                            money = Convert.ToDecimal(Console.ReadLine());
                                                            sList[data].Expenses.OtherCategories[select].List.Add(money);
                                                        }else
                                                        {
                                                            Console.WriteLine("Incorrect select");
                                                            Console.ReadKey();
                                                        }
                                                    }else
                                                    {
                                                        Console.WriteLine("Other categories do not exist");
                                                        Console.ReadKey();
                                                    }
                                                    break;
                                                case 1:
                                                    Console.Write("Enter name for new Category : ");
                                                    string categoryname = Console.ReadLine();
                                                    sList[data].Expenses.OtherCategories.Add(new Category(categoryname));
                                                    Console.WriteLine("You create new category");
                                                    Console.ReadKey();
                                                    break;
                                              case 2:
                                                    if (sList[data].Expenses.OtherCategories.Count>0)
                                                    {
                                                        for (int i = 0; i < sList[data].Expenses.OtherCategories.Count; i++)
                                                        {
                                                            Console.WriteLine($"{i}. {sList[data].Expenses.OtherCategories[i].Name}\n");
                                                            Console.WriteLine($"{sList[data].Expenses.OtherCategories[i].ToString()}");
                                                        }
                                                        Console.ReadKey();
                                                    }
                                                    break;
                                                case 3:
                                                    if (sList[data].Expenses.OtherCategories.Count>0)
                                                    {
                                                        for (int i = 0; i < sList[data].Expenses.OtherCategories.Count; i++)
                                                        {
                                                            Console.WriteLine($"{i}. {sList[data].Expenses.OtherCategories[i].Name}\n");
                                                        }
                                                        Console.Write("Select number for delete category : ");
                                                        select = Convert.ToInt32(Console.ReadLine());

                                                        if (sList[data].Expenses.OtherCategories.Count>select)
                                                        {
                                                            Console.WriteLine($"You delete : {sList[data].Expenses.OtherCategories[select].Name}");
                                                            sList[data].Expenses.OtherCategories.RemoveAt(select);
                                                            Console.ReadKey();
                                                        }
                                                        else {
                                                            Console.WriteLine("Incorrect numbaer");
                                                            Console.ReadKey();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not category");
                                                        Console.ReadKey();
                                                    }
                                                    break;
                                            }
                                        }

                                    } while (true);
                                    Console.ReadKey();
                                }
                            }
                            Console.Clear();
                        } while (true);

                    }
                    else if (actionForMainMenu == 2)
                    {
                        Console.Clear();
                        actionForIncomeMenu = 0;

                        do
                        {
                            Console.Clear();
                            AdditionalFunctionality.PrintIncomeMenu(actionForIncomeMenu);
                            keyForIncomeMenu = Console.ReadKey().Key;
                            if (sound)
                            {
                                Console.Beep(frequency, duration);
                            }
                            if (keyForIncomeMenu == ConsoleKey.UpArrow)
                            {
                                actionForIncomeMenu--;
                                if (actionForIncomeMenu == -1) actionForIncomeMenu = 3;
                            }
                            else if (keyForIncomeMenu == ConsoleKey.DownArrow)
                            {
                                actionForIncomeMenu++;
                                if (actionForIncomeMenu == 4) actionForIncomeMenu = 0;
                            }
                            else if (keyForIncomeMenu == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else if (keyForIncomeMenu == ConsoleKey.Enter)
                            {
                                if (actionForIncomeMenu!=3)
                                {
                                    actionForValutaMenu = 0;
                                    Console.Clear();
                                    Console.WriteLine("Press SPACE for select valuta or any button to continue");
                                    keyForValutaMenu = Console.ReadKey(true).Key;
                                    Console.Clear();
                                    if (keyForValutaMenu == ConsoleKey.Spacebar)
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                            keyForValutaMenu = Console.ReadKey().Key;
                                            if (keyForValutaMenu == ConsoleKey.UpArrow)
                                            {
                                                actionForValutaMenu--;
                                                if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                            }
                                            else if (keyForValutaMenu == ConsoleKey.Escape)
                                            {
                                                break;
                                            }
                                            else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                            {
                                                actionForValutaMenu++;
                                                if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                            }
                                            else if (keyForValutaMenu == ConsoleKey.Enter)
                                            {
                                                moneyValuta = "$";
                                                switch (actionForValutaMenu)
                                                {
                                                    case 0: moneyValuta = "AZN"; break;
                                                    case 1: moneyValuta = "EUR"; break;
                                                    case 2: moneyValuta = "RUB"; break;
                                                    case 3: moneyValuta = "TRY"; break;
                                                }
                                                Console.Clear();
                                                Console.WriteLine($"How much money do you want to deposit ? {moneyValuta}\n");
                                                money = decimal.Parse(Console.ReadLine());

                                                money = AdditionalFunctionality.ExchangeIn(money, actionForValutaMenu, valuta);
                                                break;
                                            }
                                        } while (true);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("How much money do you want to deposit ? $\n");
                                        money = decimal.Parse(Console.ReadLine());
                                    }
                                    switch (actionForIncomeMenu)
                                    {
                                        case 0:
                                            sList[data].Income.Deposits.Сontribution(money);
                                            break;
                                        case 1:
                                            sList[data].Income.Savings.Сontribution(money);
                                            break;
                                        case 2:
                                            sList[data].Income.Salary.Сontribution(money);
                                            break;

                                    }
                                    Console.WriteLine("Action completed");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    actionForCategoryIncomeMenu = 0;
                                    do
                                    {
                                        Console.Clear();
                                        AdditionalFunctionality.PrintCategoryMenu(actionForCategoryIncomeMenu);
                                        keyForCategoryIncomeMenu = Console.ReadKey().Key;
                                        if (sound)
                                        {
                                            Console.Beep(frequency, duration);
                                        }
                                        if (keyForCategoryIncomeMenu == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                        if (keyForCategoryIncomeMenu == ConsoleKey.UpArrow)
                                        {
                                            actionForCategoryIncomeMenu--;
                                            if (actionForCategoryIncomeMenu == -1) actionForCategoryIncomeMenu = 3;
                                        }
                                        else if (keyForCategoryIncomeMenu == ConsoleKey.DownArrow)
                                        {
                                            actionForCategoryIncomeMenu++;
                                            if (actionForCategoryIncomeMenu == 4) actionForCategoryIncomeMenu = 0;
                                        }
                                        else if (keyForCategoryIncomeMenu == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                        else if (keyForCategoryIncomeMenu == ConsoleKey.Enter)
                                        {

                                            Console.Clear();

                                            switch (actionForCategoryIncomeMenu)
                                            {
                                                case 0:
                                                    if (sList[data].Income.OtherCategories.Count > 0)
                                                    {
                                                        for (int i = 0; i < sList[data].Income.OtherCategories.Count; i++)
                                                        {
                                                            Console.WriteLine($"{i}. {sList[data].Income.OtherCategories[i].Name}");
                                                        }

                                                        Console.Write("\nSelecet category : ");
                                                        select = Convert.ToInt32(Console.ReadLine());
                                                        if (sList[data].Income.OtherCategories.Count > select)
                                                        {
                                                            Console.WriteLine("How much money did you spend ? $");
                                                            money = Convert.ToDecimal(Console.ReadLine());
                                                            sList[data].Income.OtherCategories[select].List.Add(money);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Incorrect select");
                                                            Console.ReadKey();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Other categories do not exist");
                                                        Console.ReadKey();
                                                    }

                                                    break;
                                                case 1:
                                                    Console.Write("Enter name for new Category : ");
                                                    string categoryname = Console.ReadLine();
                                                    sList[data].Income.OtherCategories.Add(new Category(categoryname));
                                                    Console.WriteLine("You create new category");
                                                    Console.ReadKey();
                                                    break;

                                                case 2:
                                                    if (sList[data].Income.OtherCategories.Count > 0)
                                                    {
                                                        for (int i = 0; i < sList[data].Income.OtherCategories.Count; i++)
                                                        {
                                                            Console.WriteLine($"{i}. {sList[data].Income.OtherCategories[i].Name}\n");
                                                            Console.WriteLine($"{sList[data].Income.OtherCategories[i].ToString()}");
                                                        }

                                                        Console.ReadKey();
                                                    }
                                                    break;
                                                case 3:
                                                    if (sList[data].Income.OtherCategories.Count > 0)
                                                    {
                                                        for (int i = 0; i < sList[data].Income.OtherCategories.Count; i++)
                                                        {
                                                            Console.WriteLine($"{i}. {sList[data].Income.OtherCategories[i].Name}\n");
                                                        }

                                                        Console.Write("Select number for delete category : ");
                                                        select = Convert.ToInt32(Console.ReadLine());

                                                        if (sList[data].Income.OtherCategories.Count > select)
                                                        {

                                                            Console.WriteLine($"You delete : {sList[data].Income.OtherCategories[select].Name}");
                                                            sList[data].Income.OtherCategories.RemoveAt(select);
                                                            Console.ReadKey();
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Incorrect numbaer");
                                                            Console.ReadKey();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not category");
                                                        Console.ReadKey();

                                                    }
                                                    break;
                                            }
                                        }

                                    } while (true);
                                }
                                
                            }
                            Console.Clear();

                        } while (true);
                    }
                    else if (actionForMainMenu == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Press SPACE for select valuta or any button to continue");
                        keyForValutaMenu = Console.ReadKey(true).Key;
                        if (keyForValutaMenu == ConsoleKey.Spacebar)
                        {
                            actionForValutaMenu = 0;
                            do
                            {
                                Console.Clear();
                                AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                keyForValutaMenu = Console.ReadKey().Key;
                                if (sound)
                                {
                                    Console.Beep(frequency, duration);
                                }
                                if (keyForValutaMenu == ConsoleKey.UpArrow)
                                {
                                    actionForValutaMenu--;
                                    if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                }else if (keyForValutaMenu == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                {
                                    actionForValutaMenu++;
                                    if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                }
                                else if (keyForValutaMenu == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    moneyValuta = "USD";
                                    switch (actionForValutaMenu)
                                    {
                                        case 0: moneyValuta = "AZN"; break;
                                        case 1: moneyValuta = "EUR"; break;
                                        case 2: moneyValuta = "RUB"; break;
                                        case 3: moneyValuta = "TRY"; break;
                                    }
                                    money = AdditionalFunctionality.ExchangeOut(sList[data].DayExpenses(), actionForValutaMenu, valuta);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($" Your Exeption balance : -{Math.Round(money, 2)} {moneyValuta}");
                                    money = AdditionalFunctionality.ExchangeOut(sList[data].DayIncome(), actionForValutaMenu, valuta);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($" Your Income balance   :  {Math.Round(money, 2)} {moneyValuta}");
                                    Console.ResetColor();
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" Your Exeption balance : -{Math.Round(sList[data].DayExpenses(), 2)} $");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" Your Income balance   :  {Math.Round(sList[data].DayIncome(), 2)} $");
                            Console.ResetColor();
                        }

                        Console.WriteLine($"\n                Statistic of {data}");
                        AdditionalFunctionality.StatisticsDayPrint(sList[data]);
                        Console.ReadKey();

                    }
                    else if (actionForMainMenu == 4)
                    {
                        Console.Clear();
                        Tdate = DateTime.Now;
                        Tdate=Tdate.AddDays(-7);
                        withTime = Tdate.ToShortDateString();
                        Tuple<decimal, decimal> tmp = AdditionalFunctionality.StatisticsWeeklyExpenseIncome(sList, withTime, data);
                        Console.WriteLine("Press SPACE for select valuta or any button to continue");
                        keyForValutaMenu = Console.ReadKey().Key;
                        if (sound)
                        {
                            Console.Beep(frequency, duration);
                        }
                        if (keyForValutaMenu == ConsoleKey.Spacebar)
                        {
                            actionForValutaMenu = 0;
                            do
                            {
                                Console.Clear();
                                AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                keyForValutaMenu = Console.ReadKey().Key;
                                if (sound)
                                {
                                    Console.Beep(frequency, duration);
                                }
                                if (sound)
                                {
                                    Console.Beep(frequency, duration);
                                }
                                if (keyForValutaMenu == ConsoleKey.UpArrow)
                                {
                                    actionForValutaMenu--;
                                    if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                }else if (keyForValutaMenu == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                {
                                    actionForValutaMenu++;
                                    if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                }
                                else if (keyForValutaMenu == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    moneyValuta = "USD";
                                    switch (actionForValutaMenu)
                                    {
                                        case 0: moneyValuta = "AZN"; break;
                                        case 1: moneyValuta = "EUR"; break;
                                        case 2: moneyValuta = "RUB"; break;
                                        case 3: moneyValuta = "TRY"; break;
                                    }
                                   

                                    money = AdditionalFunctionality.ExchangeOut(tmp.Item1, actionForValutaMenu, valuta);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($" Your Exeption balance : -{Math.Round(money, 2)} {moneyValuta}");
                                    money = AdditionalFunctionality.ExchangeOut(tmp.Item2, actionForValutaMenu, valuta);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($" Your Income balance   :  {Math.Round(money, 2)} {moneyValuta}");
                                    Console.ResetColor();
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" Your Exeption balance : -{Math.Round(tmp.Item1, 2)} $");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" Your Income balance   :  {Math.Round(tmp.Item2, 2)} $");
                            Console.ResetColor();
                        }

                        Console.WriteLine($"\n         Statistic of {withTime} - {data}");
                        AdditionalFunctionality.StatisticsWithDataToDataPrint(sList,withTime,data);
                        Console.ReadKey();
                    }
                    else if (actionForMainMenu == 5)
                    {
                        Console.Clear();
                        Tdate = DateTime.Now;
                        Tdate = Tdate.AddYears(-1);
                        withTime = Tdate.ToShortDateString();
                        Tuple<decimal, decimal> tmp = AdditionalFunctionality.StatisticsWeeklyExpenseIncome(sList, withTime, data);
                        Console.WriteLine("Press SPACE for select valuta or any button to continue");
                        keyForValutaMenu = Console.ReadKey(true).Key;
                        if (keyForValutaMenu == ConsoleKey.Spacebar)
                        {
                            actionForValutaMenu = 0;
                            do
                            {
                                Console.Clear();
                                AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                keyForValutaMenu = Console.ReadKey().Key;
                                if (keyForValutaMenu == ConsoleKey.UpArrow)
                                {
                                    actionForValutaMenu--;
                                    if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                }
                                else if(keyForValutaMenu == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                {
                                    actionForValutaMenu++;
                                    if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                }
                                else if (keyForValutaMenu == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    moneyValuta = "USD";
                                    switch (actionForValutaMenu)
                                    {
                                        case 0: moneyValuta = "AZN"; break;
                                        case 1: moneyValuta = "EUR"; break;
                                        case 2: moneyValuta = "RUB"; break;
                                        case 3: moneyValuta = "TRY"; break;
                                    }


                                    money = AdditionalFunctionality.ExchangeOut(tmp.Item1, actionForValutaMenu, valuta);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($" Your Exeption balance : -{Math.Round(money, 2)} {moneyValuta}");
                                    money = AdditionalFunctionality.ExchangeOut(tmp.Item2, actionForValutaMenu, valuta);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($" Your Income balance   :  {Math.Round(money, 2)} {moneyValuta}");
                                    Console.ResetColor();
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" Your Exeption balance : -{Math.Round(tmp.Item1, 2)} $");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" Your Income balance   :  {Math.Round(tmp.Item2, 2)} $");
                            Console.ResetColor();
                        }

                        Console.WriteLine($"\n         Statistic of {withTime} - {data}");
                        AdditionalFunctionality.StatisticsWithDataToDataPrint(sList, withTime, data);
                        Console.ReadKey();
                    }
                    else if (actionForMainMenu == 6)
                    {
                        Console.Clear();
                        Console.WriteLine(" Please enter with data ? ( format 00.00.0000 )");
                        withTime = Console.ReadLine();

                        Match matchWithTim = regex.Match(withTime);

                       
                        Console.WriteLine(" Please enter to data   ? ( format 00.00.0000 )");
                        toTime = Console.ReadLine();
                        Match matchToTime = regex.Match(toTime);

                        if (matchWithTim.Success&& matchToTime.Success)
                        {
                            Tuple<decimal, decimal> tmp = AdditionalFunctionality.StatisticsWeeklyExpenseIncome(sList, withTime, toTime);
                            Console.WriteLine("Press SPACE for select valuta or any button to continue");
                            keyForValutaMenu = Console.ReadKey().Key;
                            if (keyForValutaMenu == ConsoleKey.Spacebar)
                            {
                                actionForValutaMenu = 0;
                                do
                                {
                                    Console.Clear();
                                    AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                    keyForValutaMenu = Console.ReadKey().Key;
                                    if (sound)
                                    {
                                        Console.Beep(frequency, duration);
                                    }
                                    if (keyForValutaMenu == ConsoleKey.UpArrow)
                                    {
                                        actionForValutaMenu--;
                                        if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                    }else if (keyForValutaMenu == ConsoleKey.Escape)
                                    {
                                        break;
                                    }
                                    else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                    {
                                        actionForValutaMenu++;
                                        if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                    }
                                    else if (keyForValutaMenu == ConsoleKey.Enter)
                                    {
                                        Console.Clear();
                                        moneyValuta = "USD";
                                        switch (actionForValutaMenu)
                                        {
                                            case 0: moneyValuta = "AZN"; break;
                                            case 1: moneyValuta = "EUR"; break;
                                            case 2: moneyValuta = "RUB"; break;
                                            case 3: moneyValuta = "TRY"; break;
                                        }

                                        money = AdditionalFunctionality.ExchangeOut(tmp.Item1, actionForValutaMenu, valuta);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($" Your Exeption balance : -{Math.Round(money, 2)} {moneyValuta}");
                                        money = AdditionalFunctionality.ExchangeOut(tmp.Item2, actionForValutaMenu, valuta);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($" Your Income balance   :  {Math.Round(money, 2)} {moneyValuta}");
                                        Console.ResetColor();
                                        break;
                                    }
                                } while (true);
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($" Your Exeption balance : -{Math.Round(tmp.Item1, 2)} $");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($" Your Income balance   :  {Math.Round(tmp.Item2, 2)} $");
                                Console.ResetColor();
                            }
                            Console.WriteLine($"\n         Statistic of {withTime} - {toTime}");
                            AdditionalFunctionality.StatisticsWithDataToDataPrint(sList, withTime, toTime);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Data enter incorrect\n");
                            Console.ReadKey();
                        }
                    }
                    else if (actionForMainMenu == 7)
                    {
                        Console.Clear();
                        Console.WriteLine("Press SPACE for select valuta or any button to continue");
                        keyForValutaMenu = Console.ReadKey().Key;
                        if (keyForValutaMenu == ConsoleKey.Spacebar)
                        {
                            actionForValutaMenu = 0;
                            do
                            {
                                Console.Clear();
                                AdditionalFunctionality.PrintValutaMenu(actionForValutaMenu);
                                keyForValutaMenu = Console.ReadKey().Key;
                                if (sound)
                                {
                                    Console.Beep(frequency, duration);
                                }
                                if (keyForValutaMenu == ConsoleKey.UpArrow)
                                {
                                    actionForValutaMenu--;
                                    if (actionForValutaMenu == -1) actionForValutaMenu = 3;
                                }
                                else if (keyForValutaMenu == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else if (keyForValutaMenu == ConsoleKey.DownArrow)
                                {
                                    actionForValutaMenu++;
                                    if (actionForValutaMenu == 4) actionForValutaMenu = 0;
                                }
                                else if (keyForValutaMenu == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    moneyValuta = "USD";
                                    switch (actionForValutaMenu)
                                    {
                                        case 0: moneyValuta = "AZN"; break;
                                        case 1: moneyValuta = "EUR"; break;
                                        case 2: moneyValuta = "RUB"; break;
                                        case 3: moneyValuta = "TRY"; break;
                                    }

                                    money = AdditionalFunctionality.ExchangeOut(AdditionalFunctionality.AllBalanceIncome(sList), actionForValutaMenu, valuta);
                                    money2 = AdditionalFunctionality.ExchangeOut(AdditionalFunctionality.AllBalanceExpense(sList), actionForValutaMenu, valuta);
                               sum = money - money2;
                               Console.Clear();
                               Console.BackgroundColor = ConsoleColor.DarkMagenta;
                               Console.WriteLine("                                                           \n" +
                                                 $"       All balance for the whole period :  {sum.ToString().PadRight(10)} {moneyValuta}  \n" +
                                                 "                                                           \n");

                               Console.BackgroundColor = ConsoleColor.Red;
                               Console.WriteLine("                                                           \n" +
                                                 $"   Expence balance for the whole period : -{money2.ToString().PadRight(10)} {moneyValuta}  \n" +
                                                 "                                                           ");

                               Console.BackgroundColor = ConsoleColor.Green;
                               Console.WriteLine("                                                           \n" +
                                                 $"    Income balance for the whole period :  {money.ToString().PadRight(10)} {moneyValuta}  \n" +
                                                 "                                                           ");
                               Console.ResetColor();
                               Console.ReadKey();
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            Console.Clear();
                            sum = AdditionalFunctionality.AllBalanceIncome(sList) -
                                  AdditionalFunctionality.AllBalanceExpense(sList);

                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("                                                         \n" +
                                              $"       All balance for the whole period :  {sum.ToString().PadRight(10)} $  \n" +
                                              "                                                         \n");

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("                                                         \n" +
                                              $"   Expence balance for the whole period : -{AdditionalFunctionality.AllBalanceExpense(sList).ToString().PadRight(10)} $  \n" +
                                              "                                                         ");

                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine("                                                         \n" +
                                              $"    Income balance for the whole period :  {AdditionalFunctionality.AllBalanceIncome(sList).ToString().PadRight(10)} $  \n" +
                                              "                                                         ");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                    else if (actionForMainMenu == 8)
                    {
                        Console.Clear();
                     AdditionalFunctionality.PrintExpensesIncomeDaily(sList[data]);

                        Console.WriteLine("Press SPACE for edit valuta or any button to continue");
                        keyForValutaMenu = Console.ReadKey().Key;
                        if (sound)
                        {
                            Console.Beep(frequency, duration);
                        }
                        if (keyForValutaMenu == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                            actionForExpenseMenu = 0;
                            do
                            {
                                AdditionalFunctionality.PrintExpensesMenu(actionForExpenseMenu);
                                keyForExpenseMenu = Console.ReadKey().Key;
                                if (sound)
                                {
                                    Console.Beep(frequency, duration);
                                }
                                if (keyForExpenseMenu == ConsoleKey.UpArrow)
                                {
                                    actionForExpenseMenu--;
                                    if (actionForExpenseMenu == -1) actionForExpenseMenu = 14;
                                }else if (keyForExpenseMenu == ConsoleKey.Escape) { break; }
                                else if (keyForExpenseMenu == ConsoleKey.DownArrow)
                                {
                                    actionForExpenseMenu++;
                                    if (actionForExpenseMenu == 15) actionForExpenseMenu = 0;
                                }
                                else if (keyForExpenseMenu == ConsoleKey.Enter)
                                {
                                    if (actionForExpenseMenu == 14) break;
                                    Console.Clear();
                                    switch (actionForExpenseMenu)
                                    {
                                        case 0:
                                            if (sList[data].Expenses.Car.Size()>0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Car);
                                                Console.WriteLine("\n0 - Edit\n1 - Remove\n2 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Car.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Car.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Car.Clear();
                                                        break;
                                                }
                                               
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 1:
                                            if (sList[data].Expenses.Clothes.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Clothes);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select) {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Clothes.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Clothes.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Car.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 2:
                                            if (sList[data].Expenses.Communicati.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Communicati);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Communicati.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Communicati.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Communicati.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 3:
                                            if (sList[data].Expenses.EatingOut.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.EatingOut);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.EatingOut.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.EatingOut.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.EatingOut.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 4:
                                            if (sList[data].Expenses.Entertainment.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Entertainment);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Entertainment.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Entertainment.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Entertainment.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 5:
                                             if (sList[data].Expenses.Food.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Food);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Food.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Food.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Food.Clear();
                                                        break;
                                                }
                                            }
                                             else
                                             {
                                                 Console.WriteLine("There is no money ");
                                             }
                                            break;
                                        case 6:
                                            if (sList[data].Expenses.Gifts.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Gifts);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Gifts.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Gifts.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Gifts.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 7:
                                            if (sList[data].Expenses.Health.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Health);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Health.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Health.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Health.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 8:
                                            if (sList[data].Expenses.House.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.House);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.House.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.House.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.House.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 9:
                                            if (sList[data].Expenses.Pets.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Pets);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Pets.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Pets.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Pets.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 10:
                                            if (sList[data].Expenses.Sports.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Sports);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Sports.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Sports.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Sports.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 11:
                                            if (sList[data].Expenses.Taxi.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Taxi);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Taxi.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Taxi.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Taxi.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 12:
                                            if (sList[data].Expenses.Toilety.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Toilety);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Toilety.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Toilety.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Toilety.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                        case 13:
                                            if (sList[data].Expenses.Transport.Size() > 0)
                                            {
                                                Console.WriteLine(sList[data].Expenses.Transport);
                                                Console.WriteLine("\n1 - Edit\n2 - Remove\n3 - Clear\n");
                                                select = int.Parse(Console.ReadLine());
                                                switch (select)
                                                {
                                                    case 0:
                                                        Console.Write("\nSelect number : ");
                                                        select = int.Parse(Console.ReadLine());
                                                        Console.Write("\nEnter number  : ");
                                                        edit = decimal.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Transport.Edit(select, edit)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 1:
                                                        Console.Write("\nSelect number ?");
                                                        select = int.Parse(Console.ReadLine());
                                                        if (sList[data].Expenses.Transport.RemoveAt(select)) Console.WriteLine("Change applied");
                                                        else Console.WriteLine("Change not applied");
                                                        break;
                                                    case 2:
                                                        sList[data].Expenses.Transport.Clear();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no money ");
                                            }
                                            break;
                                    }

                                    Console.WriteLine("Action completed");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.Clear();
                            } while (true);
                        }
                    }
                    else if (actionForMainMenu == 9)
                    {
                        Console.Clear();
                        Console.WriteLine(" Please enter with data ? ( format 00.00.0000 )");
                        withTime = Console.ReadLine();
                        Match matchWithTim = regex.Match(withTime);

                        Console.WriteLine(" Please enter to data   ? ( format 00.00.0000 )");
                        toTime = Console.ReadLine();
                        Match matchToTime = regex.Match(toTime);
                        Console.Clear();
                        if (matchWithTim.Success && matchToTime.Success) AdditionalFunctionality.PrintExpensesIncomeAnotherData(sList, withTime, toTime);
                        else Console.WriteLine("Incorrect data");
                        Console.ReadKey();
                    }
                }
            } while (true);


            using (FileStream fs = new FileStream(@"monefy.bin", FileMode.Create))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, sList);
            }

        }
    }
}
