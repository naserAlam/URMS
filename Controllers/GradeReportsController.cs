using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using URMS.Data;
using URMS.Models;

namespace URMS.Controllers
{
    [Authorize]
    public class GradeReportsController : Controller
    {
        private readonly URMSDbContext _context;

        public GradeReportsController(URMSDbContext context)
        {
            _context = context;
        }

        // GET: GradeReports
        public async Task<IActionResult> Index()
        {
            var uRMSDbContext = _context.GradeReports.Include(g => g.URMSUser);
            return View(await uRMSDbContext.ToListAsync());
        }

        // GET: GradeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeReport = await _context.GradeReports
                .Include(g => g.URMSUser)
                .FirstOrDefaultAsync(m => m.GradeReportId == id);
            if (gradeReport == null)
            {
                return NotFound();
            }

            return View(gradeReport);
        }

        // GET: GradeReports/Create
        public IActionResult Create()
        {
            ViewData["URMSUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: GradeReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeReportId,Semester,URMSUserId")] GradeReport gradeReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["URMSUserId"] = new SelectList(_context.Users, "Id", "Id", gradeReport.URMSUserId);
            return View(gradeReport);
        }

        // GET: GradeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeReport = await _context.GradeReports.FindAsync(id);
            if (gradeReport == null)
            {
                return NotFound();
            }
            ViewData["URMSUserId"] = new SelectList(_context.Users, "Id", "Id", gradeReport.URMSUserId);
            return View(gradeReport);
        }

        // POST: GradeReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeReportId,Semester,URMSUserId")] GradeReport gradeReport)
        {
            if (id != gradeReport.GradeReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeReportExists(gradeReport.GradeReportId))
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
            ViewData["URMSUserId"] = new SelectList(_context.Users, "Id", "Id", gradeReport.URMSUserId);
            return View(gradeReport);
        }

        // GET: GradeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeReport = await _context.GradeReports
                .Include(g => g.URMSUser)
                .FirstOrDefaultAsync(m => m.GradeReportId == id);
            if (gradeReport == null)
            {
                return NotFound();
            }

            return View(gradeReport);
        }

        // POST: GradeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gradeReport = await _context.GradeReports.FindAsync(id);
            _context.GradeReports.Remove(gradeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeReportExists(int id)
        {
            return _context.GradeReports.Any(e => e.GradeReportId == id);
        }
    }
}
