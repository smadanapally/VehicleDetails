using System;
using System.Collections.Generic;
using VehicleDetails.Dal.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VehicleDetails.Bll
{
    public interface IVehicleAccess
    {
        List<VehicleModel> GetVehicles();
        VehicleModel GetVehicleById(int Id);        
        int AddVehicle(VehicleModel vehicle);
        void UpdateVehicle(VehicleModel vehicle);
        void DeleteVehicle(int Id);
    }
}
