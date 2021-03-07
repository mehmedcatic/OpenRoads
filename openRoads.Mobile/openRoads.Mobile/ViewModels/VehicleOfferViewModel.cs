using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using openRoads.Model;
using openRoads.Model.Requests;
using Xamarin.Forms;

namespace openRoads.Mobile.ViewModels
{
    

    public class VehicleOfferViewModel : BaseViewModel
    {
        public class VehicleToDisplay
        {
            public string VehicleName { get; set; }
            public int ManufacturedYear { get; set; }
            public string DailyPrice { get; set; }
            public string PowerHP { get; set; }
            public byte[] Picture { get; set; }
            public bool Available { get; set; }
        }


        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleTransmissionService = new APIService("VehicleTransmissionType");
        private readonly APIService _vehicleTypeService = new APIService("VehicleType");
        private readonly APIService _vehicleFuelService = new APIService("VehicleFuelType");
        private readonly APIService _vehicleCategoryService = new APIService("VehicleCategory");

        public VehicleOfferViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<VehicleToDisplay> VehicleList { get; set; } = new ObservableCollection<VehicleToDisplay>();
        public ObservableCollection<Model.VehicleFuelTypeModel> VehicleFuelTypeList { get; set; } =
            new ObservableCollection<Model.VehicleFuelTypeModel>();
        public ObservableCollection<Model.VehicleTransmissionTypeModel> VehicleTransmissionList { get; set; } =
            new ObservableCollection<VehicleTransmissionTypeModel>();


        VehicleFuelTypeModel _selectedFuelType = null;
        public VehicleFuelTypeModel SelectedFuelType
        {
            get { return _selectedFuelType; }
            set
            {
                SetProperty(ref _selectedFuelType, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        VehicleTransmissionTypeModel _selectedTransmissionType = null;
        public VehicleTransmissionTypeModel SelectedTransmissionType
        {
            get { return _selectedTransmissionType; }
            set
            {
                SetProperty(ref _selectedTransmissionType, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        public ICommand InitCommand { get; set; }


        private async Task LoadVehicles(VehicleSearchRequest request = null)
        {
            var vehicles = await _vehicleService.Get<List<Model.VehicleModel>>(request);
            var vehicleManufacturers = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);
            var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(null);

            VehicleList.Clear();
            foreach (var x in vehicles)
            {
                VehicleToDisplay newVehicle = new VehicleToDisplay();
                newVehicle.Available = x.Available;
                newVehicle.Picture = x.Picture;
                newVehicle.DailyPrice = x.PriceByDay + " KM";
                newVehicle.PowerHP = x.PowerInHp + " hp";
                newVehicle.ManufacturedYear = x.ManufacturedYear;

                foreach (var model in vehicleModels)
                {
                    if (x.VehicleModelId == model.VehicleModelId)
                    {
                        foreach (var manufacturer in vehicleManufacturers)
                        {
                            if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                            {
                                newVehicle.VehicleName = manufacturer.Name + " " + model.Name;
                                break;
                            }
                        }

                        break;
                    }
                }
                VehicleList.Add(newVehicle);
            }
        }

        public async Task Init()
        {
            
            if (VehicleFuelTypeList.Count == 0)
            {
                var vfList = await _vehicleFuelService.Get<List<VehicleFuelTypeModel>>(null);

                foreach (var x in vfList)
                {
                    VehicleFuelTypeList.Add(x);
                }
            }

            if (VehicleTransmissionList.Count == 0)
            {
                var vtList = await _vehicleTransmissionService.Get<List<VehicleTransmissionTypeModel>>(null);

                foreach (var x in vtList)
                {
                    VehicleTransmissionList.Add(x);
                }
            }


            if (SelectedFuelType != null || SelectedTransmissionType != null)
            {
                VehicleSearchRequest request = new VehicleSearchRequest();
                if(SelectedFuelType != null)
                    request.VehicleFuelTypeId = SelectedFuelType.VehicleFuelTypeId;
                if (SelectedTransmissionType != null)
                    request.VehicleTransmissionTypeId = SelectedTransmissionType.VehicleTransmissionTypeId;
               
                await LoadVehicles(request);
            }

            if (SelectedTransmissionType == null && SelectedTransmissionType == null)
                await LoadVehicles();


        }
    }
}
