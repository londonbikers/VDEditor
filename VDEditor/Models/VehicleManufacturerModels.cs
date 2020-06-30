using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VDEditor.VDService;

namespace VDEditor.Models
{
    public class VehicleManufacturersModel
    {
        public List<VehicleManufacturer> VehicleManufacturers
        {
            get
            {
                var service = new VdServiceClient();
                var response = service.GetVehicleManufacturers();
                return response.ResultType != GetOperationResultType.Success ? null : response.Content;
            }
        }
    }

    public class VehicleManufacturerCreateEditModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Wikipedia ID (last part in the url)")]
        [DataType(DataType.Text)]
        public string WikipediaId { get; set; }
    }
}