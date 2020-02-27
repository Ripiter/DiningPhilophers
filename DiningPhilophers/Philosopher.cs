using System;
using System.Diagnostics;
using System.Threading;

namespace DiningPhilophers
{
    class Philosopher
    {
        readonly object _lock = new object();
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsAlive { get => isAlive; set => isAlive = value; }

        public Philosopher(string _name)
        {
            this.Name = _name;
            stopwatch.Start();
        }


        void Eat(object obj)
        {
            lock (_lock)
            {
                Spot spot = (Spot)obj;
                Console.WriteLine(Name + " is using forks with ids " + spot.ForkLeft.Id + " and " + spot.ForkRight.Id);
                Thread.Sleep(5000);
                Console.WriteLine("Done eating " + Name);
                spot.SetForksIsTakenTo(false);
                stopwatch.Reset();
            }
        }
        bool isAlive = true;
        Stopwatch stopwatch = new Stopwatch();
        public void CheckIfCanEat(object obj)
        {
            if (stopwatch.Elapsed.TotalSeconds >= 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Name + " is close to diying [Time]" + stopwatch.Elapsed.TotalSeconds);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (stopwatch.Elapsed.TotalSeconds > 15)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Name + " i dieded");
                Console.ForegroundColor = ConsoleColor.White;
                IsAlive = false;
                stopwatch.Stop();
                return;
            }

            Spot spot = (Spot)obj;
            if (spot.ForkLeft.IsTaken == false && spot.ForkRight.IsTaken == false)
            {
                stopwatch.Reset();
                ThreadPool.QueueUserWorkItem(Eat, spot);
                spot.SetForksIsTakenTo(true);
            }

        }
    }
}
