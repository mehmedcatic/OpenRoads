﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using openRoads.Model;
using openRoads.Model.Requests;
using Xamarin.Forms;

namespace openRoads.Mobile.ViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _reservationService = new APIService("Reservation");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _ratingService = new APIService("Rating");

        private int? _reservationId;

        public class ReservationToDisplay
        {
            public int ReservationId { get; set; }
            public string DateFrom { get; set; }
            public string DateTo { get; set; }
            public string Price { get; set; }
            public string CreationDate { get; set; }
            public bool Active { get; set; }
            public int ClientId { get; set; }
            public string VehicleName { get; set; }
            public byte[] VehiclePicture { get; set; }
        }

        public class ReservationGrade
        {
            public int ReservationGradeId { get; set; }
            public int Grade { get; set; }
        }

        public ReviewViewModel()
        {
        }

        public ReviewViewModel(int reservationId)
        {
            _reservationId = reservationId;

            InitCommand = new Command(async () => await Init());
        }


        public ObservableCollection<ReservationToDisplay> ReservationModelToDisplay { get; set; } = new ObservableCollection<ReservationToDisplay>();
        public ObservableCollection<ReservationGrade> ReservationGradeList { get; set; } = new ObservableCollection<ReservationGrade>();

        private ReservationGrade _selectedReservationGrade = null;
        public ReservationGrade SelectedReservationGrade
        {
            get { return _selectedReservationGrade; }
            set
            {
                SetProperty(ref _selectedReservationGrade, value);
            }
        }

        string _reservationGrade;
        public string ReservationGradeModel
        {
            get { return _reservationGrade; }
            set { SetProperty(ref _reservationGrade, value); }
        }


        string _reservationComment;
        public string ReservationComment
        {
            get { return _reservationComment; }
            set { SetProperty(ref _reservationComment, value); }
        }



        int _reservationVehicleId;
        public int ReservationVehicleId
        {
            get { return _reservationVehicleId; }
            set { SetProperty(ref _reservationVehicleId, value); }
        }



        public ICommand InitCommand { get; set; }

        private async Task LoadReservations()
        {
            try
            {
                var client = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);

                var reservation = await _reservationService.GetById<ReservationModel>(_reservationId);

                var vehicleList = await _vehicleService.Get<List<Model.VehicleModel>>(null);
                var vehicleModelList = await _vehicleModelService.Get<List<Model.VehicleModelModel>>(null);
                var vehicleManufacturersList =
                    await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);

                ReservationToDisplay newFinishedRes = new ReservationToDisplay
                {
                    ReservationId = reservation.ReservationId,
                    ClientId = client.ClientId,
                    Active = reservation.Active,
                    CreationDate = reservation.CreationDate.ToString("dd.MM.yyyy"),
                    DateFrom = reservation.DateFrom.ToString("dd.MM.yyyy"),
                    DateTo = reservation.DateTo.ToString("dd.MM.yyyy"),
                    Price = reservation.Price + "KM"
                };

                foreach (var vehicle in vehicleList)
                {
                    if (reservation.VehicleId == vehicle.VehicleId)
                    {
                        foreach (var model in vehicleModelList)
                        {
                            if (vehicle.VehicleModelId == model.VehicleModelId)
                            {
                                foreach (var manufacturer in vehicleManufacturersList)
                                {
                                    if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                                    {
                                        newFinishedRes.VehicleName = manufacturer.Name + " " + model.Name;
                                        newFinishedRes.VehiclePicture = vehicle.Picture;
                                        ReservationVehicleId = vehicle.VehicleId;
                                        break;
                                    }
                                }

                                break;
                            }

                        }

                        break;
                    }
                }
                ReservationModelToDisplay.Clear();

                ReservationModelToDisplay.Add(newFinishedRes);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task LoadReview()
        {
            var ratingExists = false;

            var ratings = await _ratingService.Get<List<RatingModel>>(null);
            foreach (var x in ratings)
            {
                if (x.ReservationId == _reservationId)
                {
                    ratingExists = true;
                    ReservationGradeModel = x.RatingId.ToString();
                    ReservationComment = x.Comment;
                    break;
                }
            }

            if (!ratingExists)
            {
                if (ReservationGradeList.Count == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ReservationGradeList.Add(new ReservationGrade
                        {
                            ReservationGradeId = i + 1,
                            Grade = i + 1
                        });
                    }
                }
            }
           
        }

        public async Task Init()
        {
            await LoadReservations();
            await LoadReview();
        }
    }
}
