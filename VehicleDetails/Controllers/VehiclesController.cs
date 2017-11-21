using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using VehicleDetails.Dal.Models;
using VehicleDetails.Bll;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http.Cors;

namespace VehicleDetails.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]    
    public class VehiclesController : ApiController
    {
        private readonly IVehicleAccess _vehicleAccess;
        MediaTypeFormatter myformatter = new JsonMediaTypeFormatter();
        public VehiclesController(IVehicleAccess vehicleAccess)

        {
            _vehicleAccess = vehicleAccess;
        }

        public VehiclesController() : this(new VehicleAccess())
        {

        }

       
        [HttpGet]               
        public HttpResponseMessage Get()
        {
            var vehicles = _vehicleAccess.GetVehicles();
            HttpResponseMessage response = Request.CreateResponse<List<VehicleModel>>(HttpStatusCode.OK, vehicles);
            response.Content = new ObjectContent<List<VehicleModel>>(vehicles, myformatter, "application/json");

            return response;
        }


        
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Data");
            }
            var vehicles = _vehicleAccess.GetVehicleById(id);
            HttpResponseMessage response = Request.CreateResponse<VehicleModel>(HttpStatusCode.OK, vehicles);
            response.Content = new ObjectContent<VehicleModel>(vehicles, myformatter, "application/json");

            return response;

        }     


        [HttpPost]
        public HttpResponseMessage Post(VehicleModel vehicle)  //send response //edit validation
        {
            vehicle.Id = 0;
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Data");
            }
            int identity = _vehicleAccess.AddVehicle(vehicle);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, "New Entry has been Added" + identity);

            return response;
        }


        [HttpPut]
        public HttpResponseMessage Put(VehicleModel vehicle)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Data");
            }
            _vehicleAccess.UpdateVehicle(vehicle);

            return Request.CreateResponse(HttpStatusCode.NoContent, "The record has been updated");

        }


        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _vehicleAccess.DeleteVehicle(id);

            return Request.CreateResponse(HttpStatusCode.NoContent, "The record has been Deleted"); ;
        }
    }
}
