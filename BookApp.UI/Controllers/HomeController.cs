﻿// Copyright (c) 2020 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Diagnostics;
using BookApp.Persistence.EfCoreSql.Books;
using BookApp.UI.HelperExtensions;
using BookApp.UI.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookApp.UI.Controllers
{
    public class HomeController : BaseTraceController
    {

        public IActionResult Index([FromServices]BookDbContext context, [FromServices]BookAppSettings settings)
        {
            return View(new DatabaseStatsDto(settings.Title, context));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var isLocal = Request.IsLocal();
            return View(isLocal);
        }

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel
                { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}