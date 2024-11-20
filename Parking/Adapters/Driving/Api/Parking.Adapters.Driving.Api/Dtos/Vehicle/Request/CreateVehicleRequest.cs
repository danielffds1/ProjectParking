﻿namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Request
{
    public class CreateVehicleRequest
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Owner { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string EmployerId { get; set; }
        public string VehicleType { get; set; }
    }
}
