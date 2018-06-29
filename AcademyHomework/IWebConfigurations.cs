using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework
{
    public interface IWebConfigurations
    {
        string QueueStorageConnectionString { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string UserAgent { get; set; }
    }
}
