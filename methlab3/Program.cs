using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methlab3
{
    class Program
    {
        public static bool wrinp = false;

        static void Main(string[] args)
        {

            string buf; char[] buf2;
            int[] counts = new int[2];

            Console.WriteLine("Введите строку : ");
            buf = Console.ReadLine();

            buf2 = buf.ToCharArray();

            check(buf2, ref counts);


            if (counts[0] == counts[1]&&!wrinp) Console.WriteLine("-ДА ");
                else
                {
                    Console.WriteLine("-НЕТ ");

                    if (lnum(buf2)!=0)
                    {
                        Console.Write("Количество лишних левых скобок:"); Console.WriteLine(lnum(buf2));
                    }
                    if(rfirst(buf2)!=0)
                    {
                        Console.Write("Индекс первой лишней правой скобки:"); Console.WriteLine(rfirst(buf2)+1);
                    }
                }

        }

        public static void check(char[] symbols, ref int[] counts)
        {

            bool open = false;

            foreach (char elem in symbols) 
            { 
                if (elem == '(') 
                { 
                    counts[0]++; 

                    if (open) wrinp = true;
                    open = true;
                   
                }
                else if(elem==')')
                { 
                    counts[1]++;

                    if (open) open = false;
                    else wrinp = true;
                }
            }


            return;

        }

        public static int lnum(char[] symbols)
        {
            bool open = false;
            int num = 0;

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '(') { if (open||i==symbols.Length-1) num++;  open = true; }
                else if (symbols[i] == ')') { open = false; }
            }

            return num;
        }

        public static int rfirst(char[] symbols)
        {
            bool open=false;
            for (int i=0;i< symbols.Length;i++)
            {
                if (symbols[i] == '(') { open = true; }
                else if (symbols[i] == ')') { if (open == false)return i ;   else open = false; }
            }

            return 0;
        }
    }
}
