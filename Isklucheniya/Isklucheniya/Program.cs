﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Isklucheniya
{
    
    public class Holidays
    {
        public int days;
        public Holidays(int days)
        {
            this.days = days;
        }
        public void ShowHolidays(int day)
        {
            days = day;

            if ((days % 7 == 0) || ((days + 1) % 7 == 0)||(days<3))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ура выходной!!!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (days > 31) { throw new ArgumentException(); }
            else throw new Exception();

        }


    }

        public class JobsDays : Holidays
        {
            public JobsDays(int days) : base(days)
            {
            }

            public void ShowDays()
            {
              
                try
                {
                    int temp;
                    temp = Int32.Parse(Console.ReadLine());
                    ShowHolidays(temp);
                }
                catch (Exception) when(days<32)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Иди работай! Выходные не за горами");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("В январе 31 день! Чем думаешь?");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

    public class MonthNow
    {
        int month;
        public MonthNow(int month)
        {
            this.month = month;
        }
        public void NowMonth(int months)
        {
            month = months;
            if (month == DateTime.Now.Month)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Угадал, молодец!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else throw new Exception();

        }
    }

    public class Months:MonthNow
    {
        int mont;
        public Months(int mont) : base(mont)
        {

        }
        public void Month()
        {
            try
            {
                int temp;
                temp = Int32.Parse(Console.ReadLine());
                NowMonth(temp);
            }
            catch (Exception) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Сейчас "+DateTime.Now.Month+" месяц!!! Иди проспись!");
                Console.ForegroundColor = ConsoleColor.White;
            }
           
        }
    }
        class Program
        {


            static void Main(string[] args)
            {
                

                //1.Перехватить исключение запроса к несуществующему веб ресурсу
                //и вывести сообщение о том, что произошла ошибка.
                //Программа должна завершиться без ошибок.

                #region
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите URL cайта ");
                Console.ForegroundColor = ConsoleColor.White;

                string site = Console.ReadLine();
                try
                {
                    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://www." + site);
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                    using (StreamReader stream = new StreamReader(
                         resp.GetResponseStream(), Encoding.UTF8))
                    {
                        string Text = stream.ReadToEnd();
                        Console.WriteLine(Text);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Нет такого сайта");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            #endregion
            Console.WriteLine();

            //2.Написать программу, которая обращается к элементам массива по индексу
            //и выходит за его пределы. 
            //После обработки исключения вывести в финальном блоке сообщение
            //о завершении обработки массива.
            #region
            int[] array = new int[10];
                Random rd = new Random();
                try
                {
                    for (int i = 0; i < 20; i++)
                    {
                        array[i] = rd.Next(10, 99);
                        Console.Write(array[i] + " ");
                    }
                    Console.WriteLine();


                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Error!! Индекс вышел за пределы массива");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            #endregion
            Console.WriteLine();

            //3.Реализовать несколько методов или классов с методами
            //и вызвать один метод из другого. 
            //В вызываемом методе сгенерировать исключение и «поднять» его в вызывающий метод.
            #region
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Праздники прошли, пора просыпаться...\n Давай определяться, какой сейчас месяц?\n Просто набери порядковый номер месяца -");

            Console.ForegroundColor = ConsoleColor.White;
            Months monthes = new Months(1);
            monthes.Month();

            Console.WriteLine();

            #endregion



            /*
4.	Реализовать несколько методов или классов с методами 
и вызвать один метод из другого. 
В вызываемом методе сгенерировать исключение и «поднять» его в вызывающий метод.
*/
            #region

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("В общем вот и январь! Введите сегодняшнее число ");
            Console.ForegroundColor = ConsoleColor.White;

            JobsDays journe = new JobsDays(1);
            journe.ShowDays();

            #endregion
        }
    }
    }

