
using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar

    {
        public const int MinSeats = 1;
        public const int MaxSeats = 10;

        private int seats;
        public Car(string make, string model, int wheels, decimal price) : base(make, model, wheels, price)
        {
            Seats = this.seats;
            Type = Enums.VehicleType.Car;
        }

        public int Seats
        {
            get => this.seats;

            set
            {
                Validator.ValidateIntRangeSeats(value, MinSeats, MaxSeats, "seats");
                this.seats = value;
            }
        }
        //ToDo TO STRING
    }
}
