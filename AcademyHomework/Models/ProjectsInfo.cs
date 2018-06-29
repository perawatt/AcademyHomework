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
            ProjectName = "DemoTestforAcademy-true",
            ProjectTestPath = "Training.TestDrivenDevelopement/TDD.TestProject",
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
