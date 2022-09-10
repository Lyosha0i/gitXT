using System;
using System.Diagnostics;
using System.Timers;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Task3._1._2
{
    class Program
    {
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine("****************************************");//"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");//"****************************************");
            //if (i % 2 == 0) Console.WriteLine("Э");
        }
        static void Main(string[] args)
        {
            Console.WriteLine((char)64);
            //string text = "Laminated composite and sandwich structures are lightweight structures that can be found in many diverse applications especially civil, mechanical and aerospace engineering".ToLower();
            string text = @"As sly as a fox, as strong as an ox//By Lenka
As fast as a hare, as brave as a bear
As free as a bird, as neat as a word
As quiet as a mouse, as big as a house
All
I wanna be
All
I wanna be
Oh - oh - oh, all
    I wanna be
Is everything
As mean as a wolf, as sharp as a tooth
As deep as a bite, as dark as the night
As sweet as a song, as right as a wrong
As long as a road, as ugly as a toad
As pretty as a picture hanging from a fixture
Strong like a family, strong as I wanna be
Bright as day, as light as play
As hard as nails, as grand as a whale
All
I wanna be
Oh - oh - oh, all
    I wanna be
Oh - oh - oh, all
    I wanna be
Is everything
Everything at once
Everything at once
Oh - oh - oh, everything at once
    As warm as the sun, as silly as fun
As cool as a tree, as scary as the sea
As hot as fire, cold as ice
Sweet as sugar and everything nice
As old as time, as straight as a line
As royal as a queen, as buzzed as a bee
As stealth as a tiger, smooth as a glider
Pure as a melody, pure as I wanna be
All
I wanna be
Oh - oh - oh, all
    I wanna be
Oh - oh - oh, all
    I wanna be
Is everything
Everything at once".ToLower();
            char[] div={' ',',','.',':',';','!','"','?','(',')','\n',(char)13};
            string[] words = text.Split(div,StringSplitOptions.RemoveEmptyEntries);
            SortedList<string, int> sortedWords = new SortedList<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if(sortedWords.Any(u=>u.Key==words[i]))
                    sortedWords[words[i]]++;
                else sortedWords.Add(words[i], 1);
                //try
                //{
                //    sortedWords.Add(words[i], 0);
                //}
                //catch (ArgumentException)
                //{
                //    sortedWords[words[i]]++;
                //}
                //if (sortedWords[words[i]] == 0)
                //    sortedWords[words[i]]++;
            }
            var moreThan2 = sortedWords.Where(u => u.Value > 2);
            if (moreThan2.Count()> 0)
                Console.WriteLine("You are so repetitive. Fix it.");
            foreach(var i in moreThan2)
                Console.WriteLine(i.Key+" "+i.Value);
            if (moreThan2.Count() == 0)
                Console.WriteLine("The check has completed successfully.\nYou are various.");
            Console.ReadKey(true);
        }
    }
}
