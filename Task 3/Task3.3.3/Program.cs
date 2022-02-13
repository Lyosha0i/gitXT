using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task3._3._3
{
    public delegate void ParameterizedThreadStart(object obj);
    class Program
    {
        static void Pizzas(object obj)
        {
            if (obj is Order order)
            {
                Thread.Sleep(order.Amount*1000);//A pizza is cooked within a second.
                order.IsReady = true;
            Console.WriteLine("#{0}! Your pizzas are ready!, {1}", order.Number, DateTime.Now);
            }
        }
        static void NewOrder(Order order)
        {
            Thread myThread3 = new Thread(Pizzas);
            myThread3.Start(order);
            Console.WriteLine("New order! Order #{0}, {1}", order.Number, DateTime.Now);
        }
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();//()!
            Random r= new Random();
            int time=1;
            //while(true)//for (int i = 0; true;)
            //{
                for (int j = 0; j < 100; j++)//100 orders.
                {
                    time = r.Next(1, 5);//From 1 to 5 seconds between orders.
                    //i += time;
                    orders.Add(new Order(r.Next(1,5)));//Random amount of pizzas.
                    orders[j].Number = j + 1;//This field is for the ParameterizedThreadStart with many parameters.
                Thread.Sleep(time*1000);
                    NewOrder(orders[j]);
                    for (int k = 0; k < j+1; k++)
                    {
                        if(j-k<=9)//Information about the last 10 orders.
                            if(!orders[k].IsReady)
                            Console.WriteLine("#{0} is in process",orders[k].Number);
                        else
                                Console.WriteLine("#{0} is ready", orders[k].Number);
                    }
                //}
                //break;
            }
            //Console.ReadKey(true);
        }
    }
}
