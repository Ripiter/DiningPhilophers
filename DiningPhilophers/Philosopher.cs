using System;
using System.Diagnostics;
using System.Threading;

namespace DiningPhilophers
{
    class Philosopher
    {

        Stopwatch stopwatch = new Stopwatch();
        readonly object _lock = new object();
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool isAlive;

        public bool IsAlive
        {
            get
            {
                if (isAlive == true)
                    CheckIfItsAlive();
                return isAlive;
            }
            private set { isAlive = value; }
        }


        void CheckIfItsAlive()
        {
            if (stopwatch.Elapsed.TotalSeconds > 15)
            {
                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Name + " i dieded");
                    Console.ForegroundColor = ConsoleColor.White;
                    IsAlive = false;
                    stopwatch.Stop();
                }
            }
        }

        public Philosopher(string _name)
        {
            this.Name = _name;
            this.IsAlive = true;
            stopwatch.Start();
        }


        void Eat(Spot spot)
        {
            Console.WriteLine(Name + " is using forks with ids " + spot.ForkLeft.Id + " and " + spot.ForkRight.Id);
            Thread.Sleep(5000);
            Console.WriteLine("Done eating " + Name);
        }


        public void CheckIfCanEat(object obj)
        {
            Spot spot = (Spot)obj;

            if (spot.ForkLeft.IsTaken == false && spot.ForkRight.IsTaken == false)
            {
                stopwatch.Reset();
                spot.SetForksIsTakenTo(true);
                Eat(spot);
                spot.SetForksIsTakenTo(false);
                stopwatch.Reset();
            }
        }
    }
}
