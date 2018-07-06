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
            ProjectName = "unlocking-ep24-homework",
            ProjectTestPath = "ep24.web.tests",
            ProjectQueuename = "homework-queue-test"
        };
        
        public static ProjectInfo EP27 { get; set; } = new ProjectInfo
        {
            ProjectName = "unlocking-ep27",
            ProjectTestPath = "temperature.test",
            ProjectQueuename = "homework-queue-test"
        };
    }

    public class ProjectInfo
    {
        public string ProjectName { get; set; }
        public string ProjectTestPath { get; set; }
        public string ProjectQueuename { get; set; }
    }
}
