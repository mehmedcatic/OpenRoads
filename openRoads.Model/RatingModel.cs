﻿using System;
using System.Collections.Generic;
using System.Text;

namespace openRoads.Model
{
    public class RatingModel
    {
        public int RatingId { get; set; }
        public int RatingInt { get; set; }
        public string RatingString { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public int ReservationId { get; set; }
    }
}
