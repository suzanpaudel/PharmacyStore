using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyStore.Data;
using PharmacyStore.Models;

namespace PharmacyStore.Controllers
{
    public class PurchaseDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseDetail.Include(p => p.Product).Include(p => p.Purchase);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetail
                .Include(p => p.Product)
                .Include(p => p.Purchase)
                .FirstOrDefaultAsync(m => m.PurchaseDetailID == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName");
            ViewData["PurchaseID"] = new SelectList(_context.Purchase, "PurchaseID", "VendorName");
            return View();
        }

        // POST: PurchaseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseDetailID,ProductID,PurchaseID,Quantity,PurchasePrice,ManufacturedDate,ExpiryDate,Remarks")] PurchaseDetail purchaseDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", purchaseDetail.ProductID);
            ViewData["PurchaseID"] = new SelectList(_context.Purchase, "PurchaseID", "VendorName", purchaseDetail.PurchaseID);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetail.FindAsync(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", purchaseDetail.ProductID);
            ViewData["PurchaseID"] = new SelectList(_context.Purchase, "PurchaseID", "VendorName", purchaseDetail.PurchaseID);
            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseDetailID,ProductID,PurchaseID,Quantity,PurchasePrice,ManufacturedDate,ExpiryDate,Remarks")] PurchaseDetail purchaseDetail)
        {
            if (id != purchaseDetail.PurchaseDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseDetailExists(purchaseDetail.PurchaseDetailID))
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
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", purchaseDetail.ProductID);
            ViewData["PurchaseID"] = new SelectList(_context.Purchase, "PurchaseID", "VendorName", purchaseDetail.PurchaseID);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetail
                .Include(p => p.Product)
                .Include(p => p.Purchase)
                .FirstOrDefaultAsync(m => m.PurchaseDetailID == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseDetail = await _context.PurchaseDetail.FindAsync(id);
            _context.PurchaseDetail.Remove(purchaseDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseDetailExists(int id)
        {
            return _context.PurchaseDetail.Any(e => e.PurchaseDetailID == id);
        }
    }
}
