using System;
using System.Collections.Generic;
using System.Text;

namespace Task3._3._3
{
    class Order
    {
        public bool IsReady = false;
        private int amount;
        //public int time;
        private int number;
        public Order(int amount)//,int time)
        {
            this.amount = amount;
            //this.time = time;
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value > 0)
                    amount = value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 0)
                    number = value;
            }
        }
    }
}
