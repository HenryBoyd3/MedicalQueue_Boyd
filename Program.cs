using System;

namespace MedicalQueue_Boyd
{
    class Program
    {
        static void Main(string[] args)
        {
            ERQueue que = new ERQueue();
            bool Looper = true;
            while(Looper == true)
            {
                Console.WriteLine(" (A)dd Patient  (P)rocess Current Patient  (L)ist All in Queue  (Q)uit");
                ConsoleKey userKey = Console.ReadKey().Key;
                Console.Clear();
                if (userKey == ConsoleKey.A)
                {
                    Console.WriteLine("add the name of your person");
                    string name = Console.ReadLine();
                    Console.WriteLine("add their priority");
                    int priority =Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine( "current people in queue "+ que.Enqueue(name, priority));
 
                }
                else if (userKey == ConsoleKey.P)
                {
                   
                    Console.WriteLine("this person was removed "+que.Dequeue());
                }
                else if (userKey == ConsoleKey.L)
                {

                    Console.WriteLine("here is the list of all Patients in line \n"+que.ToString());
                }
                else if (userKey == ConsoleKey.Q)
                {
                    Console.WriteLine("You have quit the program.");
                        Looper = false;
                    break;
                }
                else 
                {
                    Console.WriteLine("you didn't enter the right key.");
                }
            }
        }
    }
}
