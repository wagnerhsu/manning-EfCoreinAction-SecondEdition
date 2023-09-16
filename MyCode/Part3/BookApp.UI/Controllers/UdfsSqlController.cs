﻿// Copyright (c) 2020 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using BookApp.Infrastructure.LoggingServices;
using BookApp.ServiceLayer.DefaultSql.Books;
using BookApp.ServiceLayer.DisplayCommon.Books;
using BookApp.ServiceLayer.DisplayCommon.Books.Dtos;
using BookApp.ServiceLayer.UdfsSql.Books;
using BookApp.ServiceLayer.UdfsSql.Books.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.UI.Controllers
{
    public class UdfsSqlController : BaseTraceController
    {
        public async Task<IActionResult> Index(SortFilterPageOptions options, [FromServices] IListUdfsBooksService service)
        {
            var bookList = await (await service.SortFilterPageAsync(options))
                .ToListAsync();

            SetupTraceInfo();

            return View(new UdfsBookListCombinedDto(options, bookList));
        }

        /// <summary>
        /// This provides the filter search dropdown content
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetFilterSearchContent(SortFilterPageOptions options, [FromServices] IBookFilterDropdownService service)
        {
            var traceIdent = HttpContext.TraceIdentifier;
            return Json(
                new TraceIndentGeneric<IEnumerable<DropdownTuple>>(
                    traceIdent,
                    service.GetFilterDropDownValues(
                        options.FilterBy)));
        }
    }
}