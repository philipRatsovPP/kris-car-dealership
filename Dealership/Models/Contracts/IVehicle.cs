﻿using Dealership.Models.Enums;

namespace Dealership.Models.Contracts
{
    public interface IVehicle : IPriceable, ICommentable
    {
        string Make { get; }

        string Model { get; }

        VehicleType Type { get; }

    }
}
