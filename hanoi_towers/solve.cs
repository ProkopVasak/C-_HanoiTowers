using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hanoi_towers
{
    class HanoiSolver
    {
        private int TotalDiscs { get; set; } = 0;
        private Stack<int> FirstPeg { get; set; } = new Stack<int>();
        private Stack<int> SecondPeg { get; set; } = new Stack<int>();
        private Stack<int> ThirdPeg { get; set; } = new Stack<int>();

        public HanoiSolver(int discs = 3)
        {
            TotalDiscs = discs;

            //Create list of items (discs)
            var discList = Enumerable.Range(1, TotalDiscs).Reverse();

            //Add items (discs) to first peg
            foreach (var d in discList)
            {
                FirstPeg.Push(d);
            }
        }

        
        public void Move()
        {
            for (int i = 1; i <= Math.Pow(2, TotalDiscs) - 1; i++)
            {
                if (TotalDiscs % 2 == 0)
                { 
                    if (i % 3 == 1)
                    { 
                        transfer(FirstPeg, SecondPeg,"source","auxiliary");
                    }
                    else if (i % 3 == 2)
                    {
                        transfer(FirstPeg, ThirdPeg, "source","destination");
                    }
                    else
                    { 
                        transfer(SecondPeg, ThirdPeg, "auxiliary", "destination");
                    }

                }
                else
                { 
                    if (i % 3 == 1)
                    { 
                        transfer(FirstPeg, ThirdPeg, "source", "destination");
                    }
                    else if (i % 3 == 2)
                    { 
                        transfer(FirstPeg, SecondPeg, "source", "auxiliary");
                    }
                    else
                    { 
                        transfer(ThirdPeg, SecondPeg, "destination", "auxiliary");
                    }
                }
            }
            PrintPegs();
        }

        private void transfer(Stack<int> s1, Stack<int> s2,string S1,string S2)
        {
            if (s1.Count() == 0)
            {
                
                int disk = s2.Pop();
                s1.Push(disk);
                Console.WriteLine ("Disk {0} moved from {1} to {2}", disk , S2,S1);
            }
            else if (s2.Count() == 0)
            {
                int disk = s1.Pop();
                s2.Push(disk);
                Console.WriteLine("Disk {0} moved from {1} to {2}", disk, S1, S2);
            }
            else
            {
                int disk1 = s1.Peek();
                int disk2 = s2.Peek(); if (disk1 < disk2)
                {
                    s1.Pop();
                    s2.Push(disk1);
                    Console.WriteLine("Disk {0} moved from {1} to {2}", disk1, S1, S2);
                }
                else
                {
                    s2.Pop();
                    s1.Push(disk2);
                    Console.WriteLine("Disk {0} moved from {1} to {2}", disk2, S2, S1);
                }
            }
        }
        private void PrintPegs()
        {
            var fp = FirstPeg.Select(x => x.ToString()).ToList();

            if (fp.Count < TotalDiscs)
            {
                fp.AddRange(Enumerable.Repeat(string.Empty, (TotalDiscs - fp.Count)));
            }

            var sp = SecondPeg.Select(x => x.ToString()).ToList();

            if (sp.Count < TotalDiscs)
            {
                sp.AddRange(Enumerable.Repeat(string.Empty, (TotalDiscs - sp.Count)));
            }

            var tp = ThirdPeg.Select(x => x.ToString()).ToList();

            if (tp.Count < TotalDiscs)
            {
                tp.AddRange(Enumerable.Repeat(string.Empty, (TotalDiscs - tp.Count)));
            }

            Console.WriteLine($"{"[source]",10}" + $"{"[auxiliary]",10}" + $"{"[destination]",10}");

            for (var i = 0; i < TotalDiscs; i++)
            {
                Console.WriteLine($"{fp[i],10}" +
                                  $"{sp[i],10}" +
                                  $"{tp[i],10}");
            }
        }
    }
}


