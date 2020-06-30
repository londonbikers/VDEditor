using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VDEditor.VDService;
using VDEditor.Code;

namespace VDEditor.Models
{
    public class VehicleModelIndexModel
    {
        public int VehicleManufacturerId { get; set; }

        public SelectList Manufacturers
        {
            get
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleManufacturers();
                if (response.ResultType != GetOperationResultType.Success)
                    return Helpers.GetErrorSelectList();

                var list = new SelectList(response.Content, "Id", "Name");
                return list;
            }
        }

        public VehicleManufacturer Manufacturer { get; set; }

        public List<VehicleModel> Models
        {
            get
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleModelsByManufacturerId(Manufacturer.Id);
                if (response.ResultType != GetOperationResultType.Success)
                    return null;

                return response.Content;
            }
        }
    }

    public class VehicleModelCreateEditModel
    {
        public SelectList VehicleManufacturers
        {
            get
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleManufacturers();
                if (response.ResultType != GetOperationResultType.Success)
                    return Helpers.GetErrorSelectList();

                var list = new SelectList(response.Content, "Id", "Name");
                return list;
            }
        }

        public SelectList VehicleTypes
        {
            get
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleTypes();
                if (response.ResultType != GetOperationResultType.Success)
                    return Helpers.GetErrorSelectList();

                var list = new SelectList(response.Content, "Id", "Name");
                return list;
            }
        }

        public int VehicleModelId { get; set; }

        [Required]
        [Display(Name = "Choose a manufacturer")]
        public int ManufacturerId { get; set; }

        [Required]
        [Display(Name = "Choose a vehicle type")]
        public string TypeId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Variant name, i.e. 'R'")]
        public string VariantName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Engine size in CC.")]
        public string EngineSizeCc { get; set; }

        [Display(Name = "Wikipedia ID (last part in the url)")]
        [DataType(DataType.Text)]
        public string WikipediaId { get; set; }

        [Display(Name = "Year introduced, i.e. 2000")]
        [DataType(DataType.Text)]
        public string YearIntroduced { get; set; }

        [Display(Name = "Year stopped, i.e. 2004")]
        [DataType(DataType.Text)]
        public string YearStopped { get; set; }
    }
}