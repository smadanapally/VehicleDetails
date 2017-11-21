using System;
using System.Collections.Generic;
using VehicleDetails.Dal.Implementation;
using VehicleDetails.Dal.Interface;
using VehicleDetails.Dal.Models;

namespace VehicleDetails.Bll
{
    public class VehicleAccess : IVehicleAccess
    {
        public VehicleAccess() : this(new VehicleDataAccess())
        {

        }

        public VehicleAccess(IVehicleDataAccess vehicleDataAccess)
        {
            this._vehicleDataAccess = vehicleDataAccess;
        }

        private IVehicleDataAccess _vehicleDataAccess;


        public void DeleteVehicle(int Id)
        {
            _vehicleDataAccess.DeleteVehicle(Id);
        }


        public VehicleModel GetVehicleById(int Id)
        {
            var vehicles = _vehicleDataAccess.GetVehicleById(Id);
            return vehicles;
        }

        public List<VehicleModel> GetVehicles()
        {
            var vehicles = _vehicleDataAccess.GetVehicles();

            return vehicles;
        }

        public void UpdateVehicle(VehicleModel vehicle)
        {
            _vehicleDataAccess.UpdateVehicle(vehicle);
        }

        public int AddVehicle(VehicleModel vehicle)
        {
            return _vehicleDataAccess.AddVehicle(vehicle);

        }

      
    }
}
