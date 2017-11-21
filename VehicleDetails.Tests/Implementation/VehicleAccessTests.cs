using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleDetails.Bll;
using Moq;
using VehicleDetails.Dal.Interface;
using VehicleDetails.Dal.Models;
using System.Collections.Generic;

namespace VehicleDetails.Tests.Implementation
{
    [TestClass]
    public class VehicleAccessTests
    {
        private VehicleAccess _vehicleAccess;

        private Mock<IVehicleDataAccess> _vehicleDataAccess;        
       
        [TestInitialize]
        public void setup()
        {
            _vehicleDataAccess = new Mock<IVehicleDataAccess>();
        }

        [TestMethod]
        public void GetVehicleById_Returns_Id_Test()

        {
            VehicleModel v1 = new VehicleModel();
            v1.Id = 1;
            v1.Year = 1990;
            v1.Make = "Sample";
            v1.Model = "Sample";

            _vehicleDataAccess.Setup(x => x.GetVehicleById(It.IsAny<int>())).Returns(v1);
            _vehicleAccess = new VehicleAccess(_vehicleDataAccess.Object);

            var result = _vehicleAccess.GetVehicleById(1);
            Assert.AreEqual(v1.Id, result.Id);

            
        }

        [TestMethod]
        public void Get_Vehicles_Returns_ListofVehicles_Test()

        {


            VehicleModel v1 = new VehicleModel();
            v1.Id = 1;
            v1.Year = 1990;
            v1.Make = "Sample";
            v1.Model = "Sample";

            VehicleModel v2 = new VehicleModel();
            v1.Id = 2;
            v1.Year = 1990;
            v1.Make = "Sample";
            v1.Model = "Sample";

            List<VehicleModel> test = new List<VehicleModel>();
            test.Add(v1);
            test.Add(v2);

            _vehicleDataAccess.Setup(x => x.GetVehicles()).Returns(test);
            _vehicleAccess = new VehicleAccess(_vehicleDataAccess.Object);

            var result = _vehicleAccess.GetVehicles();
            Assert.AreEqual(test, result);
        }

    }
}