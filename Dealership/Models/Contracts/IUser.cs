using System.Collections.Generic;
using Dealership.Models.Enums;

namespace Dealership.Models.Contracts
{
    public interface IUser
    {
        string Username { get; }

        string FirstName { get; }

        string LastName { get; }

        string Password { get; }

        Role Role { get; }

        IList<IMotorcycle> Vehicles { get; }

        void AddVehicle(IMotorcycle vehicle);

        void RemoveVehicle(IMotorcycle vehicle);

        void AddComment(IComment commentToAdd, IMotorcycle vehicleToAddComment);

        void RemoveComment(IComment commentToRemove, IMotorcycle vehicleToRemoveComment);

        string PrintVehicles();
    }
}
