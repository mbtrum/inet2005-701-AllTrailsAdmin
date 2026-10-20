
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllTrailsAdmin.Models;
using AllTrailsAdmin.Services;

public class TrailsController : Controller
{
    private readonly AllTrailsAdminContext _context;
    private readonly AzureStorageService _azureStorage;

    // Constructor
    public TrailsController(AllTrailsAdminContext context, AzureStorageService azureStorage)
    {
        _context = context;
        _azureStorage = azureStorage;
    }

    // GET: TRAILS/Index
    public async Task<IActionResult> Index()
    {
        List<Trail> trails = await _context.Trail.ToListAsync();

        return View(trails); // display trails in the view
    }

    // GET: TRAILS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        // Is an Id included in URL?
        if (id == null)
        {
            return NotFound();            
        }

        var trail = await _context.Trail.FirstOrDefaultAsync(m => m.Id == id); // get trail from db where Id = 5

        // Was the row found in database?
        if (trail == null)
        {
            return NotFound();
        }

        return View(trail);
    }

    // GET: TRAILS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TRAILS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,Length,ElevationGain,Location,CreatedDate")] Trail trail, IFormFile? ImageUpload)
    {
        // Validate if Image File is missing
        if(ImageUpload == null)
        {
            // Add a validation error
            ModelState.AddModelError("ImageUpload", "Image file is required.");
        }

        if (ModelState.IsValid) // validate input
        {
            //
            // Upload file to Azure Stroage (after input validation occurs)
            //

            // Make a unique filename (GUID.ext)
            string extension = Path.GetExtension(ImageUpload!.FileName); // includes the leading dot, e.g. ".jpg"
            string newFileName = $"{Guid.NewGuid()}{extension}";

            // Upload file to Azure Storage
            string url = await _azureStorage.UploadFileAsync(ImageUpload, newFileName);

            // Set the image URL in trail record            
            trail.ImageUrl = url;

            //
            // Save trail in database
            //

            _context.Add(trail); // add new trail to context (db)
            await _context.SaveChangesAsync(); // save context changes in db

            return RedirectToAction(nameof(Index)); // re-direct to Trails/Index page
        }

        return View(trail);
    }

    // GET: TRAILS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var trail = await _context.Trail.FindAsync(id);

        if (trail == null)
        {
            return NotFound();
        }

        return View(trail);
    }

    // POST: TRAILS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Description,Length,ElevationGain,Location,CreatedDate,ImageUrl")] Trail trail)
    {
        if (id != trail.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(trail);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailExists(trail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(trail);
    }

    // GET: TRAILS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var trail = await _context.Trail
            .FirstOrDefaultAsync(m => m.Id == id);
        if (trail == null)
        {
            return NotFound();
        }

        return View(trail);
    }

    // POST: TRAILS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var trail = await _context.Trail.FindAsync(id);
        if (trail != null)
        {
            _context.Trail.Remove(trail);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TrailExists(int? id)
    {
        return _context.Trail.Any(e => e.Id == id);
    }
}
