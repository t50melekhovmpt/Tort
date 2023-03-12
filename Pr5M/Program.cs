using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pr5M
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                menu1();
                Console.WriteLine("Хотите сделать заказ?");
                ConsoleKeyInfo key = Console.ReadKey();
                menu();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    menu1();
                }
                Console.CursorVisible = false;
            }
        }
        static void menu()
        {
            Console.WriteLine("Заказ тортов");
            Console.WriteLine("Выберите параметры торта");
            Console.WriteLine("  Форма");
            Console.WriteLine("  Размер");
            Console.WriteLine("  Вкус");
            Console.WriteLine("  Посыпка");
            Console.WriteLine("  Количество");
            Console.WriteLine("  Выход");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Цена: ");
            Console.WriteLine("Торт/ы: ");
        }
        static void menu1()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            int position = 2;
            int cena = 0;
            List<string> names = new List<string>();
            while (true)
            {
                Console.Clear();
                menu();
                position = Pos(key, position);
                if (position < 3)
                {
                    position = 2;
                }
                if (position > 7)
                {
                    position = 7;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                if (key.Key == ConsoleKey.Enter && position == 7)
                {
                    Console.Clear();

                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    var a = Menu2(key, position);
                    Console.Clear();
                    menu();
                    cena = cena + a.Item1;
                    names.Add(a.Item2);
                }
                Console.SetCursorPosition(7, 11);
                Console.WriteLine(cena);
                Console.SetCursorPosition(11, 12);
                foreach (string i in names)
                {
                    Console.Write(i);
                    Console.Write(", ");
                }
                ConsoleKeyInfo keyA = Console.ReadKey();
                key = keyA;
                Console.Clear();
            }
            Console.Clear();
        }
        static int Pos(ConsoleKeyInfo key2, int pos2)
        {
            if (key2.Key == ConsoleKey.DownArrow)
            {
                pos2++;
            }
            if (key2.Key == ConsoleKey.UpArrow)
            {
                pos2--;
            }
            return pos2;
        }
        static zakaz Menu(int posin)
        {
            zakaz one = new zakaz();
            one.name[0] = "Круглый";
            one.name[1] = "квадратный";
            one.name[2] = "Треугольный";
            one.name[3] = "Кастомный";

            one.cost[0] = 200;
            one.cost[1] = 200;
            one.cost[2] = 200;
            one.cost[3] = 500;


            zakaz two = new zakaz();
            two.name[0] = "Маленький";
            two.name[1] = "Cредний";
            two.name[2] = "Большой";
            two.name[3] = "На заказ";

            two.cost[0] = 700;
            two.cost[1] = 1050;
            two.cost[2] = 1400;
            two.cost[3] = 2000;


            zakaz three = new zakaz();
            three.name[0] = "Ваниль";
            three.name[1] = "Шоколад";
            three.name[2] = "Карамель";
            three.name[3] = "Ягода";

            three.cost[0] = 100;
            three.cost[1] = 100;
            three.cost[2] = 200;
            three.cost[3] = 150;

            zakaz four = new zakaz();
            four.name[0] = "Драже";
            four.name[1] = "Ягоды";
            four.name[2] = "Шоколад";
            four.name[3] = "Крем";

            four.cost[0] = 200;
            four.cost[1] = 400;
            four.cost[2] = 200;
            four.cost[3] = 150;

            zakaz five = new zakaz();
            five.name[0] = "Один";
            five.name[1] = "Два";
            five.name[2] = "Три";
            five.name[3] = "Четыре";

            five.cost[0] = 1000;
            five.cost[1] = 1900;
            five.cost[2] = 2700;
            five.cost[3] = 3400;

            zakaz[] zakaz = new zakaz[] { one, two, three, four, five };
            zakaz part_of_menu = zakaz[posin];
            return part_of_menu;
        }
        static Tuple<int, string> Menu2(ConsoleKeyInfo key1, int pos1)
        {
            string elements = "";
            int summ = 0;
            int posA = 0;
            string str = "";
            int integer = 0;
            while (true)
            {
                int posout = pos1 - 2;
                zakaz menushka = Menu(posout);
                for (int i = 0; i < 5; i++)
                {
                    str = menushka.name[i];
                    integer = menushka.cost[i];
                    Console.Write("  ");
                    Console.Write(str);
                    Console.Write(" - ");
                    Console.WriteLine(integer);
                }

                posA = Pos(key1, posA);
                if (posA < 0)
                {
                    posA = 0;
                }
                if (posA > 4)
                {
                    posA = 4;
                }
                Console.SetCursorPosition(0, posA);
                Console.WriteLine("->");
                ConsoleKeyInfo keyA = Console.ReadKey();
                key1 = keyA;
                Console.Clear();
                if (keyA.Key == ConsoleKey.Enter)
                {
                    summ = menushka.cost[posA];
                    elements = menushka.name[posA];
                    break;
                }
            }
            return Tuple.Create(summ, elements);
        }
        public static void full(int sumin, List<string> cake)
        {
            string a = string.Join(", ", cake);
            string path = "C:\\Users\\chelo\\Desktop\\Тортики.txt";
            File.WriteAllText(path, "Заказ от: " + DateTime.Today + "\n");
            File.WriteAllText(path, "Ваш торт: " + a + "\n");
            File.WriteAllText(path, "Сумма заказа: " + sumin + "\n" + "\n");
        }
    }
}
