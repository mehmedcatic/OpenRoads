using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class ReservationService : BaseCRUDService<ReservationModel, ReservationSearchRequest, Reservation, 
        ReservationInsertUpdateRequest, ReservationInsertUpdateRequest>
    {
        public ReservationService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override List<ReservationModel> Get(ReservationSearchRequest search)
        {
            var query = _context.Reservation.ToList();

            List<Reservation> reservationList = new List<Reservation>();

            if (search.InsuranceId.HasValue && search.VehicleId.HasValue)
            {
                foreach (var x in query)
                {
                    if(x.InsuranceId == search.InsuranceId && x.VehicleId == search.VehicleId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.InsuranceId.HasValue && search.VehicleId.HasValue == false)
            {
                foreach (var x in query)
                {
                    if (x.InsuranceId == search.InsuranceId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.InsuranceId.HasValue == false && search.VehicleId.HasValue)
            {
                foreach (var x in query)
                {
                    if (x.VehicleId == search.VehicleId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }


            var vehicles = _context.Vehicle.ToList();
            var vehicleManufacturers = _context.VehicleManufacturer.ToList();
            var vehicleModels = _context.VehicleModel.ToList();

            if (search.ReservationYear.HasValue && search.VehicleManufacturerId.HasValue)
            {
                foreach (var x in query)
                {
                    if (x.DateFrom.Year == search.ReservationYear)
                    {
                        foreach (var vehicle in vehicles)
                        {
                            if (vehicle.VehicleId == x.VehicleId)
                            {
                                foreach (var model in vehicleModels)
                                {
                                    if (model.VehicleModelId == vehicle.VehicleModelId &&
                                        model.VehicleManufacturerId == search.VehicleManufacturerId)
                                    {
                                        reservationList.Add(x);
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.ReservationYear.HasValue && search.VehicleManufacturerId.HasValue == false)
            {
                foreach (var x in query)
                {
                    if (x.DateFrom.Year == search.ReservationYear)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.ReservationYear.HasValue == false && search.VehicleManufacturerId.HasValue)
            {
                foreach (var x in query)
                {
                    foreach (var vehicle in vehicles)
                    {
                        if (vehicle.VehicleId == x.VehicleId)
                        {
                            foreach (var model in vehicleModels)
                            {
                                if (model.VehicleModelId == vehicle.VehicleModelId &&
                                    model.VehicleManufacturerId == search.VehicleManufacturerId)
                                {
                                    reservationList.Add(x);
                                    break;
                                }
                            }

                            break;
                        }
                    };
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }



            if (search.ClientId.HasValue)
            {
                foreach (var x in query)
                {
                    if(x.ClientId == search.ClientId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }


            return _mapper.Map<List<ReservationModel>>(query);
        }

        
    }
}
