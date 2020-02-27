using System;
using System.Threading;

namespace DiningPhilophers
{
    class Program
    {
        static readonly object _lock = new object();

        static void Main(string[] args)
        {
            Fork[] forks = new Fork[5];
            Spot[] spots = new Spot[5];
            Philosopher[] philosophers = new Philosopher[5];

            for (int i = 0; i < philosophers.Length; i++)
            {
                philosophers[i] = new Philosopher("Philosopher " + i);
            }

            for (int i = 0; i < forks.Length; i++)
            {
                forks[i] = new Fork(i);
            }

            for (int i = 0; i < spots.Length; i++)
            {
                // Check if the next spot is our of bouts
                // and if it is make it it to the first fork
                spots[i] = new Spot(forks[i], i + 1 == forks.Length ? forks[0] : forks[i + 1], i);
            }

            while (true)
            {
                for (int i = 0; i < philosophers.Length; i++)
                {
                    //philosophers[i].CheckIfCanEat(spots[i]);
                    //Thread.Sleep(100);

                    if (philosophers[i].IsAlive)
                    {
                        Monitor.TryEnter(_lock);
                        Thread thread = new Thread(philosophers[i].CheckIfCanEat);
                        thread.Start(spots[i]);

                        //ThreadPool.QueueUserWorkItem(philosophers[i].CheckIfCanEat, spots[i]);
                        Monitor.Exit(_lock);
                    }
                }
            }

            Console.ReadLine();
        }


    }
}
