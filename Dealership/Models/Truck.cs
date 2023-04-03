
using Dealership.Models.Contracts;
using Dealership.Models.Enums;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        
        private int weightCapacity;
        public Truck(string make, string model, int wheels, decimal price, int weightCapacity) : base(make, model, wheels, price)
        {
            WeightCapacity = weightCapacity;
            Type = VehicleType.Truck;
        }

        public int WeightCapacity
        {
            get => this.weightCapacity;
            private set
            {
                Validator.ValidateIntRangeWeightCapacity(value, MinCapacity, MaxCapacity, "weightCapacity");
                this.weightCapacity = value;
            }
        }



        //ToDo TO STRING
    }
}
