using System;
using System.Collections.Generic;
using VehicleDetails.Dal.Models;

namespace VehicleDetails.Dal.Interface
{
    public interface IVehicleDataAccess
    {
        List<VehicleModel> GetVehicles();
        VehicleModel GetVehicleById(int Id);
        int AddVehicle(VehicleModel vehicle);
        void UpdateVehicle(VehicleModel vehicle);
        void DeleteVehicle(int Id);
    }
}
