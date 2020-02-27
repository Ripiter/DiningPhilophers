using System;
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


        public Philosopher(string _name)
        {
            this.Name = _name;
        }


        void Eat(Spot spot)
        {
            Console.WriteLine(Name + " is using forks with ids " + spot.ForkLeft.Id + " and " + spot.ForkRight.Id);
            Thread.Sleep(10000);
            Console.WriteLine("Done eating " + Name);
            spot.SetForksIsTakenTo(false);
        }

        public void CheckIfCanEat(object obj)
        {
            lock (_lock)
            {
                Spot spot = (Spot)obj;
                if (spot.ForkLeft.IsTaken == false && spot.ForkRight.IsTaken == false)
                {
                    spot.SetForksIsTakenTo(true);
                    Eat(spot);
                }
            }
        }
    }
}
