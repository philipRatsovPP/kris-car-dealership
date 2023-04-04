
using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar

    {
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        private int wheels = 4;

        private int seats;
        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            Seats = seats;
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

        public int Wheels
        {
            get => this.wheels;
            private set => this.wheels = value;
        }
        //ToDo TO STRING
    }
}
