﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework
{
    public interface IWebConfigurations
    {
        string QueueStorageConnectionString { get; set; }
        string GitToken { get; set; }
        string UserAgent { get; set; }
    }
}