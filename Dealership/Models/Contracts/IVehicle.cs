﻿using Dealership.Models.Enums;

namespace Dealership.Models.Contracts
{
    public interface IVehicle:IPriceable
    {
        string Make { get; }

        string Model { get; }

        VehicleType Type { get; }

        int Wheels { get; }
    }
}
