using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class LinksController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<LinksController>();
    private readonly ILinksPageService _linksPageService;
    public LinksController(ILinksPageService linksPageService)
    {
        _linksPageService =
            linksPageService ?? throw new ArgumentNullException(nameof(linksPageService));
    }
    public async Task<IActionResult> Create()
    {
        var linkCategories = await _linksPageService.GetLinkCategories();
        ViewData["LinkCategoryId"] = new SelectList(linkCategories, "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(LinkModel link)
    {
        if (ModelState.IsValid)
        {
            _linksPageService.CreateLink(link);
            return RedirectToAction("Index");
        }
        var linkCategories = await _linksPageService.GetLinkCategories();
        ViewData["LinkCategoryId"] = new SelectList(linkCategories, "Id", "Name");
        return View(link);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var link = await _linksPageService.GetLinkById(id.Value);
        if (link == null)
        {
            return NotFound();
        }
        return View(link);
    }
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var link = await _linksPageService.GetLinkById(id);
        if (link == null)
        {
            return NotFound();
        }
        await _linksPageService.DeleteLink(link);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var link = await _linksPageService.GetLinkById(id);
        if (link == null)
        {
            return NotFound();
        }
        ViewData["LinkCategoryId"] = new SelectList(
            await _linksPageService.GetLinkCategories(), "Id", "Name", link.LinkCategoryId);
        return View(link);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, LinkModel link)
    {
        if (id != link.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                await _linksPageService.UpdateLink(link);
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
            return RedirectToAction("Index");
        }
        ViewData["LinkCategoryId"] = new SelectList(
            await _linksPageService.GetLinkCategories(), "Id", "Name", link.LinkCategoryId);
        return View(link);
    }
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var linkCategoriesWithLinks = await _linksPageService.GetLinkCategoriesWithLinks();
        var viewModel = new LinkViewModel
        {
            LinkCategories = linkCategoriesWithLinks
        };
        return View(viewModel);
    }
    private bool LinkExists(int? id)
    {
        var link = _linksPageService.GetLinkById(id);
        return link != null;
    }
}
