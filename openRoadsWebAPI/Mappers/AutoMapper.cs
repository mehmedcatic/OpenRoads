using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Models;
using VehicleModel = openRoadsWebAPI.Models.VehicleModel;

namespace openRoadsWebAPI.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Branch, BranchModel>().ReverseMap();
            CreateMap<BranchInsertUpdateRequest, Branch>().ReverseMap();


            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<ClientUpdateRequest, Client>().ReverseMap();


            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<CountryInsertRequest, Country>().ReverseMap();


            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<EmployeeInsertUpdateRequest, Employee>().ReverseMap();


            CreateMap<EmployeeEmployeeRoles, EmployeeEmployeeRolesModel>().ReverseMap();
            CreateMap<EmployeeRolesInsertUpdateRequest, EmployeeRoles>().ReverseMap();


            CreateMap<EmployeeRoles, EmployeeRolesModel>().ReverseMap();


            CreateMap<Insurance, InsuranceModel>().ReverseMap();
            CreateMap<InsuranceInsertUpdateRequest, Insurance>().ReverseMap();


            CreateMap<LoginData, LoginDataModel>().ReverseMap();


            CreateMap<Person, PersonModel>().ReverseMap();


            CreateMap<Rating, RatingModel>().ReverseMap();


            CreateMap<Reservation, ReservationModel>().ReverseMap();


            CreateMap<Vehicle, openRoads.Model.VehicleModel>().ReverseMap();
            CreateMap<VehicleInsertUpdateRequest, Vehicle>().ReverseMap();
            CreateMap<Vehicle, Vehicle>();


            CreateMap<VehicleCategory, VehicleCategoryModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleCategory>().ReverseMap();


            CreateMap<VehicleFuelType, VehicleFuelTypeModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleFuelType>().ReverseMap();


            CreateMap<VehicleManufacturer, VehicleManufacturerModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleManufacturer>().ReverseMap();


            CreateMap<VehicleModel, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelAddUpdateRequest, VehicleModel>().ReverseMap();


            CreateMap<VehicleTransmissionType, VehicleTransmissionTypeModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleTransmissionType>().ReverseMap();


            CreateMap<VehicleType, VehicleTypeModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleType>().ReverseMap();


        }
    }

}
