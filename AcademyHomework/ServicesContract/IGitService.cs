﻿using AcademyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.ServicesContract
{
    public interface IGitService
    {
        /// <summary>
        /// ดึง username จาก url ของ Git
        /// </summary>
        /// <param name="url">url ของ Git</param>
        /// <returns></returns>
        Task<GitInfo> GetGitInfo(string url, string gitProjectname, string gitTestProjectPath);
    }
}
