using AllTrailsAdmin;
using AllTrailsAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class HikerReviewsController : Controller
{
    private readonly AllTrailsAdminContext _context;

    // The logged in user
    private string? _userId;

    public HikerReviewsController(AllTrailsAdminContext context)
    {        
        _context = context;
    }

    // User object not available when constructor is called.
    // OnActionExecuting() runs after the controller is constructed, after model binding, and right before the action method runs, so everything is populated: HttpContext, RouteData, ModelState, User, bound action arguments, and so on.
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Controller is fully constructed; ControllerContext, HttpContext, etc. are set
        base.OnActionExecuting(context);

        _userId = User.GetUserId();
    }


    public async Task<IActionResult> Index()
    {
        // Get reviews that belong to the logged in user
        var trails = await _context.HikerReview
            .Where(m => m.CreatedBy == _userId)
            .Include(h => h.Trail)
            .ToListAsync();

        return View(trails);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hikerReview = await _context.HikerReview
            .Include(h => h.Trail)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hikerReview == null)
        {
            return NotFound();
        }

        return View(hikerReview);
    }

    public IActionResult Create()
    {
        ViewData["TrailId"] = new SelectList(_context.Trail, "Id", "Title");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,TrailId,Description,Rating,IsPublished")] HikerReview hikerReview)
    {
        // Assign userId to record
        hikerReview.CreatedBy = _userId;

        if (ModelState.IsValid)
        {
            _context.Add(hikerReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["TrailId"] = new SelectList(_context.Trail, "Id", "Title", hikerReview.TrailId);
        return View(hikerReview);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hikerReview = await _context.HikerReview.FindAsync(id);
        if (hikerReview == null)
        {
            return NotFound();
        }

        ViewData["TrailId"] = new SelectList(_context.Trail, "Id", "Title", hikerReview.TrailId);
        return View(hikerReview);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,TrailId,Description,Rating,IsPublished,CreatedBy,CreatedDate")] HikerReview hikerReview)
    {
        if (id != hikerReview.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(hikerReview);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HikerReviewExists(hikerReview.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["TrailId"] = new SelectList(_context.Trail, "Id", "Title", hikerReview.TrailId);
        return View(hikerReview);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hikerReview = await _context.HikerReview
            .Include(h => h.Trail)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hikerReview == null)
        {
            return NotFound();
        }

        return View(hikerReview);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var hikerReview = await _context.HikerReview.FindAsync(id);
        if (hikerReview != null)
        {
            _context.HikerReview.Remove(hikerReview);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HikerReviewExists(int id)
    {
        return _context.HikerReview.Any(e => e.Id == id);
    }
}
