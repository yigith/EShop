﻿using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public IReadOnlyList<Product> Products { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Brands { get; set; }
    }
}
