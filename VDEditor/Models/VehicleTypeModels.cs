using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VDEditor.VDService;

namespace VDEditor.Models
{
    public class VehicleTypesModel
    {
        public List<VehicleType> VehicleTypes
        {
            get 
            { 
                var service = new VdServiceClient();
                var response = service.GetVehicleTypes();
                return response.ResultType == GetOperationResultType.Success ? response.Content : null;
            }
        }
    }

    public class VehicleTypeCreateEditModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}