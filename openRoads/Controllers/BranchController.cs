﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Service;

namespace openRoadsWebAPI.Controllers
{
    public class BranchController : BaseCRUDController<BranchModel, BranchSearchRequest, BranchInsertUpdateRequest, BranchInsertUpdateRequest>
    {
        public BranchController(IBaseCRUDService<BranchModel, BranchSearchRequest, BranchInsertUpdateRequest, BranchInsertUpdateRequest> service) 
            : base(service)
        {
        }
    }
}