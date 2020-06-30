using System.Linq;
using System.Web.Mvc;
using VDEditor.Code;
using VDEditor.Models;
using VDEditor.VDService;

namespace VDEditor.Controllers
{
    public class VehicleTypesController : Controller
    {
        // GET: /VehicleTypes/
        public ActionResult Index()
        {
            var m = new VehicleTypesModel();
            return View(m);
        }

        // GET: /VehicleTypes/Create
        public ActionResult Create()
        {
            var m = new VehicleTypeCreateEditModel();
            return View(m);
        } 

        // POST: /VehicleTypes/Create
        [HttpPost]
        public ActionResult Create(VehicleTypeCreateEditModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new VdServiceClient();
                var vt = new VehicleType {Name = model.Name};
                var response = service.UpdateVehicleType(vt);
                Helpers.AddPageMessage(response.ResultType);
                if (response.ResultType == UpdateOperationResultType.Success)
                    return RedirectToAction("Index");
            }

            // invalid object.
            return View(model);
        }
        
        // GET: /VehicleTypes/Edit/5
        public ActionResult Edit(int id)
        {
            var response = new VdServiceClient().GetVehicleTypes();
            if (response.ResultType != GetOperationResultType.Success)
            {
                Helpers.AddPageMessage(response.ResultType);
                return RedirectToAction("Index");
            }

            var vt = response.Content.Single(q => q.Id == id);
            var m = new VehicleTypeCreateEditModel { Id = vt.Id, Name = vt.Name };
            return View(m);
        }

        // POST: /VehicleTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleTypeCreateEditModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new VdServiceClient();
                var typesResponse = service.GetVehicleTypes();
                if (typesResponse.ResultType != GetOperationResultType.Success)
                {
                    Helpers.AddPageMessage(typesResponse.ResultType);
                    return View(model);
                }

                var vt = typesResponse.Content.Single(q => q.Id == id);
                vt.Name = model.Name;
                var response = service.UpdateVehicleType(vt);
                Helpers.AddPageMessage(response.ResultType);

                if (response.ResultType != UpdateOperationResultType.Success)
                    return View(model);
                
                return RedirectToAction("Index");
            }

            // invalid object.
            return View(model);
        }

        // POST: /VehicleTypes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var typeId = id;
            var service = new VdServiceClient();
            var response = service.DeleteVehicleType(id);
            Helpers.AddPageMessage(response.ResultType);
            return response.ResultType != DeleteOperationResultType.Success ? RedirectToAction("Edit", new { id = typeId }) : RedirectToAction("Index");
        }
    }
}
