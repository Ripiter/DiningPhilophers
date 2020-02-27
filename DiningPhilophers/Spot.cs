using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilophers
{
    class Spot
    {
        Fork forkLeft;
        Fork forkRight;
        int spotId;

        public int SpotId { get => spotId; set => spotId = value; }
        internal Fork ForkLeft { get => forkLeft; set => forkLeft = value; }
        internal Fork ForkRight { get => forkRight; set => forkRight = value; }

        public Spot(Fork forkLeft, Fork forkRight, int spotId)
        {
            this.ForkLeft = forkLeft;
            this.ForkRight = forkRight;
            this.SpotId = spotId;
        }


        public void SetForksIsTakenTo(bool status)
        {
            ForkLeft.IsTaken = status;
            ForkRight.IsTaken = status;
        }
    }
}
