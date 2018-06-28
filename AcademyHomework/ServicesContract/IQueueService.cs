using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.ServicesContract
{
    public interface IQueueService
    {
        /// <summary>
        /// เข้าคิวรอ web job มารับไปทำงาน
        /// </summary>
        /// <param name="message">ข้อความที่เข้าคิว</param>
        /// <param name="queueReference">ชื่อคิว</param>
        /// <returns></returns>
        Task<bool> EnQueue(string message, string queueReference);
    }
}
