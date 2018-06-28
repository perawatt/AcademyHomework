﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyHomework.Models;
using AcademyHomework.ServicesContract;

namespace AcademyHomework.Controllers
{
    public class HomeController : Controller
    {
        IQueueService qSvc; 
        public HomeController(IQueueService qSvc)
        {
            this.qSvc = qSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

[HttpGet]public async Task<IActionResult> HomeWork1()        {
            return View();
        }

        [HttpPost("{url}")]
        public IActionResult HomeWork1(string url)
        {

            return View();
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
