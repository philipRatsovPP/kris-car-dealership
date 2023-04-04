
using Dealership.Models.Contracts;
using Dealership.Models.Enums;
using System.Security.Cryptography;

namespace Dealership.Models
{
    public class Motorcycle:Vehicle, IMotorcycle
    {        
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        private int wheels = 2;
        
        private string category;
        public Motorcycle(string make, string model, decimal price, string category) : base(make, model, price)
        {
            Category = this.category;
            Type = VehicleType.Motorcycle;
        }

        public string Category
        {
            get => this.category;

            set
            {
                Validator.ValidateIntRangeCategory(value.Length, CategoryMinLength, CategoryMaxLength, "category");
                this.category = value;
            }
        }

        public int Wheels
        {
            get => this.wheels;
            private set => this.wheels = value;
        }

        // TO DO TO STRING
    }
}
