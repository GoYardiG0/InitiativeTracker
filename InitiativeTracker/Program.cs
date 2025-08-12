using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class Program
    {
        public static List<CharInit> initiativeOrder = new List<CharInit>();
        public static List<InitEvent> initEvents = new List<InitEvent>();
        public static int currentTurn = 0;
        public static int round = 1;
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("press 1 to go to next turn" +
                    "\npress 2 to add by inititive." +
                    "\npress 3 to add by modifier" +
                    "\npress 4 for event" +
                    "\npress 5 for delete " +
                    "\npress 6 for cancel event");
                    int mode = 0;

                    mode = int.Parse(Console.ReadLine());
                    switch (mode)
                    {
                        case 1:
                            currentTurn++;
                            if (currentTurn >= initiativeOrder.Count)
                            {
                                currentTurn = 0;
                                round++;
                                foreach (InitEvent initEvent in new List<InitEvent>(initEvents))
                                {
                                    initEvent.rounds--;
                                }
                            }
                            foreach (InitEvent initEvent in new List<InitEvent>(initEvents))
                            {
                                if ((currentTurn != 0 && initEvent.rounds == 0 && initiativeOrder[currentTurn - 1].name == initEvent.charinit_name) || initEvent.rounds == -1)
                                    initEvents.Remove(initEvent);
                            }
                            break;
                        case 2:
                            Console.WriteLine("write name");
                            string name = Console.ReadLine();
                            Console.WriteLine("write inintinti");
                            int itnitnitni = int.Parse(Console.ReadLine());
                            initiativeOrder.Add(new CharInit(name, itnitnitni));
                            break;
                        case 3:
                            Console.WriteLine("write name");
                            string basename = Console.ReadLine();
                            Console.WriteLine("write modifer");
                            int modifier = int.Parse(Console.ReadLine());
                            Console.WriteLine("write amount");
                            int amount = int.Parse(Console.ReadLine());
                            AddByModifier(basename, modifier, amount);
                            break;
                        case 4:
                            Console.WriteLine("write name");
                            string eventname = Console.ReadLine();
                            Console.WriteLine("numbe of rounds");
                            int rounds = int.Parse(Console.ReadLine());
                            string initchar_name = initiativeOrder[currentTurn].name;
                            initEvents.Add(new InitEvent(eventname, rounds, initchar_name));
                            break;
                        case 5:
                            Console.WriteLine("write exact name for delete");
                            string deletename = Console.ReadLine();
                            initiativeOrder.Remove(initiativeOrder.Where(init => init.name == deletename).FirstOrDefault());
                            break;
                        case 6:
                            Console.Clear();
                            foreach (InitEvent initEvent in new List<InitEvent>(initEvents))
                            {
                                Console.WriteLine(initEvent.name + ": " + initEvent.rounds);
                            }
                            Console.WriteLine("write name of delete event");
                            string eventdelete = Console.ReadLine();
                            initEvents.Remove(initEvents.Where(e => e.name == eventdelete).FirstOrDefault());
                            break;
                        default:
                            Console.WriteLine("input not valid");
                            break;
                    }
                    InitiativeOrderToString();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public static void AddByModifier(string name, int modifier, int amount)
        {
            Random rnd = new Random();
            for (int i = 1; i <= amount; i++)
            {
                int samenameamount = 1;
                foreach (CharInit init in initiativeOrder)
                {
                    if (init.name.Contains(name))
                        samenameamount++;
                }
                initiativeOrder.Add(new CharInit(name + $" ({samenameamount})", rnd.Next(1, 21) + modifier));
                Thread.Sleep(500);
            }
        }
        public static void InitiativeOrderToString()
        {            
            initiativeOrder = new List<CharInit>(initiativeOrder.OrderByDescending(init => init.initiative));
            Console.Clear();
            Console.WriteLine("round: " + round);
            int tracker = 0;
            foreach (InitEvent initEvent in initEvents)
            {
                if (initEvent.rounds == 0)
                {
                    Console.WriteLine($"{initEvent.name} will end this round on {initEvent.charinit_name}'s turn");
                }
                    
            }
            foreach (CharInit init in initiativeOrder)
            {
                if (tracker == currentTurn)
                    Console.Write("-->");
                Console.WriteLine(init.ToString());
                tracker++;
            }
        }
    }
}
