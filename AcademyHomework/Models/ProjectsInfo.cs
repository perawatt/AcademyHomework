using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.Models
{
    public class ProjectsInfo
    {
        public static ProjectInfo EP24 { get; set; } = new ProjectInfo
        {
            ProjectName = "",
            ProjectTestPath = ""
        };
    }

    public class ProjectInfo
    {
        public string ProjectName { get; set; }
        public string ProjectTestPath { get; set; }
    }
}
