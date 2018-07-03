using AcademyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.ServicesContract
{
    public interface ITableService
    {
        /// <summary>
        /// บันทึกข้อมูลลงฐานข้อมูล เพื่อรอให้ Webjob ดึงข้อมูล
        /// </summary>
        /// <param name="message">ข้อความที่เข้าบันทึกลงฐานข้อมูล</param>
        /// <param name="tableReference">ชื่อฐานข้อมูล</param>
        /// <returns></returns>
        Task<bool> Upload(GitInfo gitInfo, string tableReference);
    }
}
