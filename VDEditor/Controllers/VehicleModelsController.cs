using System.Linq;
using System.Web.Mvc;
using VDEditor.Code;
using VDEditor.Models;
using VDEditor.VDService;

namespace VDEditor.Controllers
{
    public class VehicleModelsController : Controller
    {
        // GET: /VehicleModels/
        public ActionResult List(int? id)
        {
            var model = new VehicleModelIndexModel();
            if (id.HasValue)
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleManufacturer(id.Value);
                if (response.ResultType != GetOperationResultType.Success)
                {
                    Helpers.AddPageMessage(response.ResultType);
                    return View(model);
                }

                model.Manufacturer = response.Content;
                model.VehicleManufacturerId = id.Value;
            }

            return View(model);
        }

        // POST: /VehicleModels/
        [HttpPost]
        public ActionResult List(VehicleModelIndexModel model)
        {
            var service = new VdServiceClient();
            var response = service.GetVehicleManufacturer(model.VehicleManufacturerId);
            if (response.ResultType != GetOperationResultType.Success)
            {
                Helpers.AddPageMessage(response.ResultType);
                return View(model);
            }

            model.Manufacturer = response.Content;
            return View(model);
        }

        // GET: /VehicleModels/Create
        public ActionResult Create(int? id)
        {
            var model = new VehicleModelCreateEditModel();

            if (id.HasValue)
            {
                // copying an existing VehicleModel.
                var service = new VdServiceClient();
                var response = service.GetVehicleModel(id.Value);
                if (response.ResultType != GetOperationResultType.Success)
                {
                    Helpers.AddPageMessage(response.ResultType);
                    return View(model);
                }

                var vm = response.Content;
                model.ManufacturerId = vm.ManufacturerId;
                model.TypeId = vm.Type.Id.ToString();
                model.Name = vm.Name;
                model.VariantName = vm.VariantName;
                model.EngineSizeCc = vm.EngineSizeCc.ToString();
                model.WikipediaId = vm.WikipediaId;
                
                if (vm.YearIntroduced.HasValue) model.YearIntroduced = vm.YearIntroduced.Value.ToString();
                if (vm.YearStopped.HasValue) model.YearStopped = vm.YearStopped.Value.ToString();
            }

            return View(model);
        }

        // POST: /VehicleModels/Create
        [HttpPost]
        public ActionResult Create(VehicleModelCreateEditModel model)
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

                var vm = new VehicleModel
                {
                    Type = typesResponse.Content.Single(q => q.Id == int.Parse(model.TypeId)),
                    ManufacturerId = model.ManufacturerId,
                    Name = model.Name,
                    VariantName = model.VariantName,
                    EngineSizeCc = int.Parse(model.EngineSizeCc),
                    WikipediaId = model.WikipediaId,
                };

                if (!string.IsNullOrEmpty(model.YearIntroduced)) vm.YearIntroduced = int.Parse(model.YearIntroduced);
                if (!string.IsNullOrEmpty(model.YearStopped)) vm.YearStopped = int.Parse(model.YearStopped);
                
                var response = service.UpdateVehicleModel(vm);
                Helpers.AddPageMessage(response.ResultType);
                if (response.ResultType != UpdateOperationResultType.Success)
                    return View(model);

                return RedirectToAction("List", new { id = model.ManufacturerId });
            }

            return View(model);
        }
        
        // GET: /VehicleModels/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new VdServiceClient();
            var response = service.GetVehicleModel(id);
            if (response.ResultType != GetOperationResultType.Success)
            {
                Helpers.AddPageMessage(response.ResultType);
                return RedirectToAction("List");
            }

            var vm = response.Content;
            var model = new VehicleModelCreateEditModel
            {
                VehicleModelId = vm.Id,
                ManufacturerId = vm.ManufacturerId,
                TypeId = vm.Type.Id.ToString(),
                Name = vm.Name,
                VariantName = vm.VariantName,
                EngineSizeCc = vm.EngineSizeCc.ToString(),
                WikipediaId = vm.WikipediaId
            };

            if (vm.YearIntroduced.HasValue) model.YearIntroduced = vm.YearIntroduced.Value.ToString();
            if (vm.YearStopped.HasValue) model.YearStopped = vm.YearStopped.Value.ToString();

            return View(model);
        }

        // POST: /VehicleModels/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleModelCreateEditModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleModel(id);
                if (response.ResultType != GetOperationResultType.Success)
                {
                    Helpers.AddPageMessage(response.ResultType);
                    return RedirectToAction("List");
                }

                var typesResponse = service.GetVehicleTypes();
                if (typesResponse.ResultType != GetOperationResultType.Success)
                {
                    Helpers.AddPageMessage(typesResponse.ResultType);
                    return View(model);
                }

                var vm = response.Content;
                vm.Type = typesResponse.Content.Single(q => q.Id == int.Parse(model.TypeId));
                vm.ManufacturerId = model.ManufacturerId;
                vm.Name = model.Name;
                vm.VariantName = model.VariantName;
                vm.EngineSizeCc = int.Parse(model.EngineSizeCc);
                vm.WikipediaId = model.WikipediaId;

                if (string.IsNullOrEmpty(model.YearIntroduced))
                    vm.YearIntroduced = null;
                else 
                    vm.YearIntroduced = int.Parse(model.YearIntroduced);

                if (string.IsNullOrEmpty(model.YearStopped))
                    vm.YearStopped = null;
                else
                    vm.YearStopped = int.Parse(model.YearStopped);

                var updateResponse = service.UpdateVehicleModel(vm);
                Helpers.AddPageMessage(updateResponse.ResultType);
                if (updateResponse.ResultType != UpdateOperationResultType.Success)
                    return View(model);
                
                return RedirectToAction("List", new { id = model.ManufacturerId });
            }

            return View(model);
        }

        // POST: /VehicleModels/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var modelId = id;
            var service = new VdServiceClient();
            var response = service.DeleteVehicleModel(id);
            Helpers.AddPageMessage(response.ResultType);
            return response.ResultType != DeleteOperationResultType.Success ? RedirectToAction("Edit", new {id = modelId}) : RedirectToAction("List");
        }
    }
}