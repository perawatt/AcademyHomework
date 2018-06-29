﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework
{
    public class WebConfigurations : IWebConfigurations
    {
        public string QueueStorageConnectionString { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserAgent { get; set; }
    }
}
