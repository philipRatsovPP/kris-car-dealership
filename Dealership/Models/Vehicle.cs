using Dealership.Models.Contracts;
using Dealership.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;

        private string make;
        private string model;
        private decimal price;
        private IList<IComment> comments = new List<IComment>();

        protected Vehicle(string make, string model, decimal price)
        {
            Make = make;
            Model = model;
            Price = price;
        }

        public string Make
        {
            get => this.make;

            private set
            {
                Validator.ValidateIntRange(value.Length, MakeMinLength, MakeMaxLength, "make");
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                Validator.ValidateIntRange(value.Length, ModelMinLength, ModelMaxLength, "model");
                this.model = value;
            }
        }

        public VehicleType Type { get; set; }

        public decimal Price
        {
            get => this.price;

            set
            {
                Validator.ValidateDecimalRange(value, MinPrice, MaxPrice, "price");
                this.price = value;
            }
        }

        public IList<IComment> Comments => throw new NotImplementedException();

        public void AddComment(IComment comment)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(IComment comment)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Price: ${Price}");
            return sb.ToString();
        }
    }
}
