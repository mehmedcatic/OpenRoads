using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Models;
using VehicleModel = openRoadsWebAPI.Models.VehicleModel;

namespace openRoadsWebAPI.Service
{
    public class VehicleModelService : BaseCRUDService<VehicleModelModel, VehicleModelSearchRequest, 
        VehicleModel, VehicleModelAddUpdateRequest, VehicleModelAddUpdateRequest>
    {
        public VehicleModelService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<VehicleModelModel> Get(VehicleModelSearchRequest search)
        {
            var vehicleModels = _context.VehicleModel.ToList();
            var filteredModels = new List<VehicleModel>();

            if (search.VehicleManufacturerId.HasValue)
            {
                foreach (var x in vehicleModels)
                {
                    if (x.VehicleManufacturerId == search.VehicleManufacturerId)
                    {
                        filteredModels.Add(new VehicleModel
                        {
                            Name = x.Name,
                            VehicleManufacturerId = x.VehicleManufacturerId,
                            VehicleModelId = x.VehicleModelId
                        });
                    }
                }

                return _mapper.Map<List<VehicleModelModel>>(filteredModels);
            }

            return _mapper.Map<List<VehicleModelModel>>(vehicleModels);
        }
    }
}
