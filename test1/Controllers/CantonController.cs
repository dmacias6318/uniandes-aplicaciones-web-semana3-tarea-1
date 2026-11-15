
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test1.Models;

public class CantonController : Controller
{
    private readonly ProvinciasDbContext _context;

    public CantonController(ProvinciasDbContext context)
    {
        _context = context;
    }

    // GET: CANTONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Cantones.Include(pr => pr.Provincia).ToListAsync());
    }

    // GET: CANTONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var canton = await _context.Cantones
            .FirstOrDefaultAsync(m => m.id == id);
        if (canton == null)
        {
            return NotFound();
        }

        return View(canton);
    }

    // GET: CANTONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CANTONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,nombre,extencion,numero_habitantes,ProvinciaId,Provincia")] Canton canton)
    {
        if (ModelState.IsValid)
        {
            _context.Add(canton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(canton);
    }

    // GET: CANTONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var canton = await _context.Cantones.FindAsync(id);
        if (canton == null)
        {
            return NotFound();
        }
        return View(canton);
    }

    // POST: CANTONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("id,nombre,extencion,numero_habitantes,ProvinciaId,Provincia")] Canton canton)
    {
        if (id != canton.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(canton);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(canton.id))
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
        return View(canton);
    }

    // GET: CANTONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var canton = await _context.Cantones
            .FirstOrDefaultAsync(m => m.id == id);
        if (canton == null)
        {
            return NotFound();
        }

        return View(canton);
    }

    // POST: CANTONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var canton = await _context.Cantones.FindAsync(id);
        if (canton != null)
        {
            _context.Cantones.Remove(canton);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CantonExists(int? id)
    {
        return _context.Cantones.Any(e => e.id == id);
    }
}
