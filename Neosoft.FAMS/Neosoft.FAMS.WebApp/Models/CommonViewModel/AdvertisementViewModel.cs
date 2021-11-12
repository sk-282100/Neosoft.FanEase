﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.CommonViewModel
{
    public class AdvertisementViewModel
    {
        public long AdvertisementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }


    }
}
