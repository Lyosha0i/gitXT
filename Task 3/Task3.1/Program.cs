using System;
using System.Collections.Generic;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<bool>people=new LinkedList<bool>();
            int j=0,n,counter=0,round=1,every;
            Console.WriteLine("Enter the number of people:");
            int.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("Enter what number person will be crossed out every round:");
            int.TryParse(Console.ReadLine(), out every);
            for (int i = 0; i < n; i++)
                people.AddLast(true);
            Console.WriteLine("A circle of people has been generated.");
            LinkedListNode<bool> node = people.First,temp;
            while (j < n-1&&n-round+1>=every)
            {
                //round++;
                while(node!=null)//for (int i = 0; node!=null&&i < people.Count; i++)
                {
                    if (node.Value)
                        counter++;//Every existing person.
                    if (counter % every == 0&& node.Value)
                    {
                        temp = node.Next;//Cross selected person out, and he won't exist.
                        people.Remove(node);
                        node = temp;
                        //node.Value = false;//Cross selected person out, and he won't exist.
                        j++;
                        Console.WriteLine("Round {0}. A person has been crossed out. Persons left: {1}",round,n-j);
                        round++;
                        //node = node.Next;
                    }
                    else if (node.Next != null)
                        node = node.Next;
                    else
                        break;
                    if (j==n-1)
                        break;
                }
                node = people.Last;
                people.RemoveLast();
                people.AddFirst(node);
                node=node.Next;
            }
            Console.WriteLine("Game over. It's impossible to cross more persons out.");
            for (; ; )break;
        }
    }
}
