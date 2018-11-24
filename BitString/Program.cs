/* 17
 Реализовать классы как классы-наследники с перегрузкой операций и конструкторами; используя открытое наследование. 
 В качестве базового класса реализовать подходящий класс-структуру: пару (Pair) или тройку (Triad) чисел с конструкторами, с полным набором операций сравнения и счетчиком объектов. 
 Реализовать для структуры функции ввода\вывода в виде дружественных. Не определять функции ввода\вывода объектов для основных классов.

Создать класс BitString для работы с 64-битовыми строками. 
Битовая строка должна быть представлена двумя полями типа unsigned long. 
Должны быть реализованы все традиционные операции для работы с битами: and,  xor, or, not. 
Реализовать сдвиг влево ShiftLeft и сдвиг вправо ShiftRight на заданное количество битов.
 */
using System;

namespace BitString
{
    public class BitString
    {
        ulong frst, scnd;

        public ulong Frst { get => frst; set => frst = value; }
        public ulong Scnd { get => scnd; set => scnd = value; }

        public static int count = 0;
        public int Count { get => count; }

        protected string EnterPair()
        {
            Console.WriteLine("Введите 1 строку:");
            string frstString = Console.ReadLine();

            Console.WriteLine("Введите 2 строку:");
            string scndString = Console.ReadLine();

            return frstString + " " + scndString;
        }

        protected void ShowPair()
        {
            Console.WriteLine("1 строка: " + Frst.ToString() + "\n2 строка" + Scnd.ToString());
        }
    }

    public class BitStringWithOperation : BitString
    {
        public BitStringWithOperation()
        {
            string text = EnterPair();
            string[] pair = text.Split(' ');
            Frst = Convert.ToUInt64(pair[0]);
            Scnd = Convert.ToUInt64(pair[1]);
            count++;
        }

        public ulong And()
        {
            return Frst & Scnd;
        }

        public ulong Xor()
        {
            return Frst ^ Scnd;
        }

        public ulong Or()
        {
            return Frst | Scnd;
        }

        public ulong Not()
        {
            return ~Frst;
        }

        public ulong ShiftLeft(int count)
        {
            return Frst << count;
        }

        public ulong ShiftRight(int count)
        {
            return Frst >> count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isEnd = false;

            while (!isEnd)
            {
                BitStringWithOperation pair = new BitStringWithOperation();

                Console.WriteLine("Введите номер команды: \n1: Выполнить операцию\n2: Вывод элементов пары и подсчет количества объектов\n3: Завершение программы\nДругой символ: Ввод новой пары");
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        {
                            bool isOperateEnd = false;

                            while (!isOperateEnd)
                            {
                                Console.WriteLine("Введите знак операции ( & , ^ , ~ , > , < , x):");
                                char operation = Convert.ToChar(Console.ReadLine());

                                switch (operation)
                                {
                                    case '&': Console.WriteLine(pair.Frst.ToString() + " and " + pair.Scnd.ToString() + " = " + pair.And().ToString()); break;
                                    case '^': Console.WriteLine(pair.Frst.ToString() + " xor " + pair.Scnd.ToString() + " = " + pair.Xor().ToString()); break;
                                    case '~': Console.WriteLine(pair.Frst.ToString() + " not = " + pair.Not().ToString()); break;
                                    case '>':
                                        {
                                            Console.WriteLine("Введите количество битов для смещения:");
                                            Console.WriteLine(pair.Frst.ToString() + " shiftright = " + pair.ShiftRight(int.Parse(Console.ReadLine())));
                                            break;
                                        }

                                    case '<':
                                        {
                                            Console.WriteLine("Введите количество битов для смещения:");
                                            Console.WriteLine(pair.Frst.ToString() + " shiftleft = " + pair.ShiftRight(int.Parse(Console.ReadLine())));
                                            break;
                                        }
                                    case 'x': Console.WriteLine("Ввод операций завершен"); isOperateEnd = true; break;
                                    default: Console.WriteLine("Данная операция не существует"); break;
                                }
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Данная пара: " + pair.Frst.ToString() + " , " + pair.Scnd.ToString() + "\nВсего элементов создано: " + int.Parse(pair.Count.ToString()));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Программа будет завершена");
                            isEnd = true;
                            break;
                        }

                    default: Console.WriteLine("Данная команда не существует!\nПрограмма будет завершена"); isEnd = true; break;
                }
            }
        }
    }
}
