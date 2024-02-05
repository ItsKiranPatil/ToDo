using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoDemo.Context;
using ToDoDemo.Models;

namespace ToDoDemo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        // GET: ToDo
        public async Task<IActionResult> Index()
        {
            var toDoContext = _context.ToDos.Include(t => t.Category).Include(t => t.Status);
            return View(await toDoContext.ToListAsync());
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .Include(t => t.Category)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            //ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID");
            //ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID");

            ViewBag.Categories = _context.Categorys.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            var task = new ToDo { StatusID = 1};
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,DueDate,CategoryID,StatusID")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categorys.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID", toDo.CategoryID);
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID", toDo.StatusID);
            return View(toDo);
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categorys.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID", toDo.CategoryID);
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID", toDo.StatusID);
            return View(toDo);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,DueDate,CategoryID,StatusID")] ToDo toDo)
        {
            if (id != toDo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.ID))
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
            ViewBag.Categories = _context.Categorys.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "CategoryID", toDo.CategoryID);
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID", toDo.StatusID);
            return View(toDo);
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .Include(t => t.Category)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDos == null)
            {
                return Problem("Entity set 'ToDoContext.ToDos'  is null.");
            }
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
          return (_context.ToDos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
