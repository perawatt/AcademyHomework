using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyHomework.Models;
using AcademyHomework.ServicesContract;
using Newtonsoft.Json;

namespace AcademyHomework.Controllers
{
    public class HomeController : Controller
    {
        IQueueService qSvc;
        IGitService gSvc;
        public HomeController(IQueueService qSvc, IGitService gSvc)
        {
            this.qSvc = qSvc;
            this.gSvc = gSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HomeWork1()
        {
            return View();
        }

        [HttpPost("{url}")]
        public async Task<IActionResult> HomeWork1(string url)
        {
            var projectName = "Unlocking-ep24-homework";
            var gitInfo = await gSvc.GetGitInfo(url, projectName);
            if (gitInfo != null)
            {
                var msg = JsonConvert.SerializeObject(gitInfo);
                var reasult = await qSvc.EnQueue(msg, "homework-queue-test");
                return RedirectToAction(nameof(Success));
            }
            return RedirectToAction(nameof(Error));
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
