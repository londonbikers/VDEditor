using System.Web.Mvc;
using VDEditor.Code;
using VDEditor.Models;
using VDEditor.VDService;

namespace VDEditor.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: /Manufacturers/
        public ActionResult Index()
        {
            var model = new VehicleManufacturersModel();
            return View(model);
        }

        // GET: /Manufacturers/Create
        public ActionResult Create()
        {
            var model = new VehicleManufacturerCreateEditModel();
            return View(model);
        } 

        // POST: /Manufacturers/Create
        [HttpPost]
        public ActionResult Create(VehicleManufacturerCreateEditModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new VdServiceClient();
                var m = new VehicleManufacturer { Name = model.Name, WikipediaId = model.WikipediaId };
                var response = service.UpdateVehicleManufacturer(m);
                Helpers.AddPageMessage(response.ResultType);
                if (response.ResultType == UpdateOperationResultType.Success)
                    return RedirectToAction("Index");
            }

            return View(model);
        }
        
        // GET: /Manufacturers/Edit/5
        public ActionResult Edit(int id)
        {
            var response = new VdServiceClient().GetVehicleManufacturer(id);
            if (response.ResultType != GetOperationResultType.Success)
            {
                Helpers.AddPageMessage(response.ResultType);
                return RedirectToAction("Index");
            }

            var manufacturer = response.Content;
            var model = new VehicleManufacturerCreateEditModel { Id = manufacturer.Id, Name = manufacturer.Name, WikipediaId = manufacturer.WikipediaId };
            return View(model);
        }

        // POST: /Manufacturers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleManufacturerCreateEditModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleManufacturer(id);
                Helpers.AddPageMessage(response.ResultType);

                if (response.ResultType != GetOperationResultType.Success)
                    return RedirectToAction("Index");

                var m = response.Content;
                m.Name = model.Name;
                m.WikipediaId = model.WikipediaId;
                var updateResponse = service.UpdateVehicleManufacturer(m);
                Helpers.AddPageMessage(updateResponse.ResultType);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // POST: /Manufacturers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var manufacturerId = id;
            var service = new VdServiceClient();
            var response = service.DeleteVehicleManufacturer(id);
            Helpers.AddPageMessage(response.ResultType);
            return response.ResultType != DeleteOperationResultType.Success ? RedirectToAction("Edit", new { id = manufacturerId }) : RedirectToAction("Index");
        }
    }
}
