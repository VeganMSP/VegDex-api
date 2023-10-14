using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LinksController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<LinksController>();
    private readonly ILinksPageService _linksPageService;
    public LinksController(ILinksPageService linksPageService)
    {
        _linksPageService =
            linksPageService ?? throw new ArgumentNullException(nameof(linksPageService));
    }
    [HttpPost]
    public StatusCodeResult Create(LinkModel link)
    {
        if (ModelState.IsValid)
        {
            _linksPageService.CreateLink(link);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost]
    [Route("Links/Category/Create")]
    public StatusCodeResult CreateLinkCategory(LinkCategoryModel linkCategoryModel)
    {
        if (!ModelState.IsValid) return BadRequest();
        _linksPageService.CreateLinkCategory(linkCategoryModel);
        return Ok();
    }
    [HttpDelete]
    [ActionName("Delete")]
    public StatusCodeResult DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var link = _linksPageService.GetLinkById(id).Result;
        if (link == null)
        {
            return NotFound();
        }
        _linksPageService.DeleteLink(link);
        return Ok();
    }
    [HttpDelete]
    [Route("Links/Category/Delete")]
    public StatusCodeResult DeleteLinkCategoryConfirmed(int? id)
    {
        if (id == null)
            return NotFound();
        var linkCategory = _linksPageService.GetLinkCategoryById(id.Value).Result;
        if (linkCategory == null)
            return NotFound();
        _linksPageService.DeleteLinkCategory(linkCategory);
        return Ok();
    }
    [HttpPut]
    [ValidateAntiForgeryToken]
    public StatusCodeResult Edit(int? id, LinkModel link)
    {
        if (id != link.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _linksPageService.UpdateLink(link);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(link.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut]
    [Route("Links/Category/Edit")]
    [ValidateAntiForgeryToken]
    public StatusCodeResult EditLinkCategory(int? id, LinkCategoryModel linkCategoryModel)
    {
        if (id != linkCategoryModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _linksPageService.UpdateLinkCategory(linkCategoryModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkCategoryExists(linkCategoryModel.Id))
                    return NotFound();
                throw;
            }
            return Ok();
        }
        return BadRequest();
    }
    // GET
    [HttpGet]
    public LinkViewModel Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var linkCategoriesWithLinks = _linksPageService.GetLinkCategoriesWithLinks().Result;
        var viewModel = new LinkViewModel
        { LinkCategories = linkCategoriesWithLinks };
        return viewModel;
    }
    [HttpGet]
    [Route("Links/Categories")]
    public IEnumerable<LinkCategoryViewModel> LinkCategoriesIndex()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var linkCategories = _linksPageService.GetLinkCategories().Result;
        return linkCategories;
    }
    private bool LinkCategoryExists(int id)
    {
        var linkCategory = _linksPageService.GetLinkCategoryById(id).Result;
        return linkCategory != null;
    }
    private bool LinkExists(int? id)
    {
        var link = _linksPageService.GetLinkById(id).Result;
        return link != null;
    }
}
