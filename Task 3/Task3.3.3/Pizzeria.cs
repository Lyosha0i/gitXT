using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task3._3._3
{
    class Pizzeria
    {
        public delegate void PizzaHandler(string push);
        public event PizzaHandler? OnNewOrder;
        public event PizzaHandler? OnPizzasAreReady;
        //private int number;
        //private Order order;
        private static Pizzeria _instance;
        public static Pizzeria Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Pizzeria();// (0,null);
                return _instance;
            }
        }
        private Pizzeria()//(int number, Order order)
        {
            //this.number = number;
            //this.order = order;
            //NewOrder(order);
        }
        private void Pizzas(object obj)
        {
            if (obj is Order order)
            {
                Thread.Sleep(order.Amount * 1000);//A pizza is cooked within a second.
                order.IsReady = true;
                OnPizzasAreReady?.Invoke($"#{order.Number}! Your pizzas are ready!, {DateTime.Now}");
                Console.WriteLine("#{0}! Your pizzas are ready!, {1}", order.Number, DateTime.Now);
            }
        }
        public void NewOrder(Order order)
        {
            Thread pizzaThread = new Thread(Pizzas);
            pizzaThread.Start(order);
            OnNewOrder?.Invoke($"New order! Order #{order.Number}, {DateTime.Now}");
            Console.WriteLine("New order! Order #{0}, {1}", order.Number, DateTime.Now);
        }
    }
}
