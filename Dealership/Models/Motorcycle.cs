
using Dealership.Models.Contracts;
using Dealership.Models.Enums;
using System.Security.Cryptography;

namespace Dealership.Models
{
    public class Motorcycle:Vehicle, IMotorcycle
    {        
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        
        private string category;
        public Motorcycle(string make, string model, int wheels, decimal price, string category) : base(make, model, wheels, price)
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

        // TO DO TO STRING
    }
}
