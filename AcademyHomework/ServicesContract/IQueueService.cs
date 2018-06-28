using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.ServicesContract
{
    public interface IQueueService
    {
        Task<bool> EnQueue(string message);
    }
}
