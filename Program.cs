using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_1
{
    class MyStack : Stack<int>
    {
        public long N_op = 0; // Счетчик колличества операций


        public int Get(int pos)
        {
            MyStack tmp = new MyStack(); N_op++;
            for (int i = Count - 1; i > pos; i--)
            {
                tmp.Push(Pop()); N_op += 2;
            }
            int result = Peek(); N_op++;
            for (int i = tmp.Count() - 1; i >= 0; i--)
            {
                Push(tmp.Pop()); N_op += 2;
            }
            return result;
        }

        public void Set(int pos, int value)
        {
            MyStack tmp = new MyStack(); N_op++;
            for (int i = Count; i > pos; i--)
            {
                tmp.Push(Pop()); N_op += 2;
            }
            Push(value); N_op++;
            for (int i = tmp.Count(); i > 0; i--)
            {
                Push(tmp.Pop());
                N_op += 2;
            }
        }
        public void Del(int pos)
        {
            MyStack tmp = new MyStack(); N_op++;
            for (int i = Count - 1; i > pos; i--)
            {
                tmp.Push(Pop());
                N_op += 2;
            }
            Pop(); N_op++;
            for (int i = tmp.Count() - 1; i >= 0; i--)
            {
                Push(tmp.Pop());
                N_op += 2;
            }
        }

        public void Print()
        {
            MyStack tmp = new MyStack(); N_op++;
            int temp = 0; N_op++;
            for (int i = Count; i > 0; i--)
            {
                temp = Pop(); N_op++;
                Console.WriteLine(temp); N_op++;
                tmp.Push(temp); N_op++;
            }
            for (int i = tmp.Count(); i > 0; i--)
            {
                Push(tmp.Pop()); N_op++;
            }
        }
        public void Sort()
        {
            int a, b = 0; N_op += 2;
            for (int i = 1; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    a = Get(i); N_op++;
                    b = Get(j); N_op++;
                    if (a > b)
                    {
                        Set(j, a); N_op++;
                        Set(i, b); N_op++;
                        Del(i + 1); N_op++;
                        Del(j + 1); N_op++;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Stopwatch stopwatch = new Stopwatch();
            MyStack mystack = new MyStack();
            int[] key = new int[3000];
            int N = 300;
            for (int i = 0; i < 3000; i++)
            {
                // Заполнение хранилища ключей случайными числами до 1000
                key[i] = rand.Next(1, 1000);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int z = N - 300; z < N; z++)
                {
                    mystack.Push(key[z]);
                }
                mystack.N_op = 0;
                stopwatch.Start();
                mystack.Sort();
                stopwatch.Stop();

                Console.WriteLine("Номер сортировки: " + (i + 1) + " Колличество отсортированных элементов: " + N + " Время сортировки (ms): " + stopwatch.ElapsedMilliseconds + " Колличество операций (N_op): " + mystack.N_op);
                N = N + 300;
            }
            Console.WriteLine();
            Console.WriteLine("Вывод стека");
            mystack.Print();
            Console.ReadKey();
        }
    }
}