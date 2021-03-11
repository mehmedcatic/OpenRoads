﻿using System;
using System.Collections.Generic;
using System.Text;

namespace openRoads.Model.Requests
{
    public class LoginDataInsertUpdateRequest
    {
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
