﻿using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels.Meta;

namespace VegDex.Web.MVC.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class MetaController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<MetaController>();
    private readonly IMetaPageService _metaPageService;
    public MetaController(IMetaPageService metaPageService)
    {
        _metaPageService = metaPageService;
    }
    [HttpGet]
    [Route("About")]
    public AboutPageViewModel About()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var pageViewModel = _metaPageService.GetAboutPage().Result;
        return pageViewModel;
    }
    [HttpPost]
    [Route("About")]
    public StatusCodeResult EditAboutPage(AboutPageViewModel page)
    {
        if (!ModelState.IsValid) return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        _metaPageService.UpdateAboutPage(page.Content);
        return new StatusCodeResult((int)HttpStatusCode.OK);
    }
    [HttpPost]
    public StatusCodeResult EditHomePage(HomePageViewModel page)
    {
        if (!ModelState.IsValid) return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        _metaPageService.UpdateHomePage(page.Content);
        return new StatusCodeResult((int)HttpStatusCode.OK);
    }
    [HttpGet]
    public HomePageViewModel Index()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var pageViewModel = _metaPageService.GetHomePage().Result;
        return pageViewModel;
    }
}
