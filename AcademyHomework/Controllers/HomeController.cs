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
        ITableService tableSvc;
        public HomeController(IQueueService qSvc, IGitService gSvc, ITableService tableSvc)
        {
            this.qSvc = qSvc;
            this.gSvc = gSvc;
            this.tableSvc = tableSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("{url}")]
        public async Task<IActionResult> Index(string url)
        {
            try
            {
                var startIndex = url.ToLower().IndexOf("ep");
                var ep = url.Substring(startIndex, 4);

                var gitInfo = new GitInfo();
                if (ep == "ep24") gitInfo = await gSvc.GetGitInfo(url, ProjectsInfo.EP24.ProjectName, ProjectsInfo.EP24.ProjectTestPath);
                else if (ep == "ep27") gitInfo = await gSvc.GetGitInfo(url, ProjectsInfo.EP27.ProjectName, ProjectsInfo.EP27.ProjectTestPath);

                if (gitInfo != null)
                {
                    var msg = JsonConvert.SerializeObject(gitInfo);
                    var reasult = await qSvc.EnQueue(msg, ProjectsInfo.EP24.ProjectQueuename);

                    // Upload data to table
                    const string tableReference = "earntest";
                    await tableSvc.Upload(gitInfo, tableReference);

                    return RedirectToAction(nameof(Success));
                }
                else return RedirectToAction(nameof(Error), new { errorMsg = "เกิดข้อผิดพลาดในระหว่างดำเนินการ กรุณาลองอีกครั้ง" });
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { errorMsg = e.Message });
            }
        }


        //[HttpGet]
        //public IActionResult HomeWork1()
        //{
        //    return View();
        //}

        //[HttpPost("{url}")]
        //public async Task<IActionResult> HomeWork1(string url)
        //{
        //    try
        //    {
        //        var gitInfo = await gSvc.GetGitInfo(url, ProjectsInfo.EP24.ProjectName, ProjectsInfo.EP24.ProjectTestPath);
        //        if (gitInfo != null)
        //        {
        //            var msg = JsonConvert.SerializeObject(gitInfo);
        //            var reasult = await qSvc.EnQueue(msg, ProjectsInfo.EP24.ProjectQueuename);

        //            // Upload data to table
        //            const string tableReference = "earntest";
        //            await tableSvc.Upload(gitInfo, tableReference);

        //            return RedirectToAction(nameof(Success));
        //        }
        //        else return RedirectToAction(nameof(Error), new { errorMsg = "เกิดข้อผิดพลาดในระหว่างดำเนินการ กรุณาลองอีกครั้ง" });
        //    }
        //    catch (Exception e)
        //    {
        //        return RedirectToAction(nameof(Error), new { errorMsg = e.Message});
        //    }
        //}

        public IActionResult Error(string errorMsg)
        {
            ViewBag.ErrorMsg = errorMsg;
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
