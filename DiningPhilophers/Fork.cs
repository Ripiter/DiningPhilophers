using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilophers
{
    class Fork
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private bool isTaken = false;

        public bool IsTaken
        {
            get { return isTaken; }
            set { isTaken = value; }
        }


        public Fork(int id)
        {
            this.Id = id;
        }

    }
}
