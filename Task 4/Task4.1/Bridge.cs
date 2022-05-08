using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Task4._1
{
    class Bridge
    {
        public DateTime time;
        public static List<int> numbers = new List<int>();
        public static List<string> paths = new List<string>();
        public static List<DateTime> times = new List<DateTime>();
        public static FileInfo fileInfo;//=new FileInfo("0.txt");
        private int counter;
        private string path;
        private static Bridge _instance;
        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                if (value >= counter)
                    counter = value;
            }
        }
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value != "")//Maybe, there is a regex must be.
                    path = value;
            }
        }
        public static Bridge Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Bridge();// (0,null);
                return _instance;
            }
            set
            {
                if (_instance!=null)//&&_instance.counter == 0)
                    _instance = value;
            }
        }
        private Bridge()//(int number, Order order)
        {
            //this.number = number;
            //this.order = order;
            //NewOrder(order);
        }
        public static void ActionAllText()
        {
            if(_instance.counter<=1)
            {
                File.WriteAllText(@"backups.json", JsonConvert.SerializeObject(_instance));
                return;
            }
            File.AppendAllText(@"backups.json",Environment.NewLine+JsonConvert.SerializeObject(_instance));
        }
    }
}
